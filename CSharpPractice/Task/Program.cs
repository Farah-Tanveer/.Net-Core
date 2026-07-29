//Console App
using Microsoft.Data.SqlClient;
string connectionString =
    "Server=FARAH-TANVEER;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";



List<Student> students = new List<Student>();
bool running = true;

while (running)
{
    Console.WriteLine("WELCOME TO---");
    Console.WriteLine("--Student Management System--");
    Console.WriteLine("1. Add student");
    Console.WriteLine("2. Display alls tudents");
    Console.WriteLine("3. Search students by name");
    Console.WriteLine("4. Generate Report");
    Console.WriteLine("5. Exit");
    Console.WriteLine("\nEnter Your choice: ");

    int choice;
    bool validChoice = int.TryParse(Console.ReadLine(), out choice);

    if (!validChoice)
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            AddStudent();
            break;
        case 2:
            DisplayAllStudents();
            break;
        case 3:
            SearchStudentByName();
            break;
        case 4:
            GenerateReport();
            break;
        case 5:
            running = false;
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid choice. Please select 1-5.");
            break;

    }
}

void AddStudent()
{
    Console.WriteLine("Enter student name: ");
    string name = Console.ReadLine();

    Console.Write("Enter class: ");
    string studentClass = Console.ReadLine();

    Console.Write("Enter section: ");
    string section = Console.ReadLine();

    string[] subjects =
    {
        "Math",
        "Physics",
        "Chemistry",
        "English",
        "Computer"
    };

    double[] grades = new double[subjects.Length];

    Console.WriteLine("\nEnter grades for each subject (0-100):");

    for (int i = 0; i < subjects.Length; i++)
    {
        grades[i] = GetValidGrade(subjects[i]);
    }

    // Insert student into Students table
    string studentQuery = @"
        INSERT INTO Students (Name, Class, Section)
        OUTPUT INSERTED.StudentId
        VALUES (@Name, @Class, @Section);
    ";

    int studentId;

    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(studentQuery, connection))
    {
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Class", studentClass);
        command.Parameters.AddWithValue("@Section", section);

        connection.Open();

        studentId = (int)command.ExecuteScalar();
    }

    // Insert grades into StudentGrades table
    string gradeQuery = @"
        INSERT INTO StudentGrades (StudentId, SubjectId, Grade)
        VALUES (@StudentId, @SubjectId, @Grade);
    ";

    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(gradeQuery, connection))
    {
        connection.Open();

        for (int i = 0; i < subjects.Length; i++)
        {
            command.Parameters.Clear();

            command.Parameters.AddWithValue("@StudentId", studentId);
            command.Parameters.AddWithValue("@SubjectId", i + 1);
            command.Parameters.AddWithValue("@Grade", grades[i]);

            command.ExecuteNonQuery();
        }
    }

    Console.WriteLine($"\nStudent {name} added. Student ID: {studentId}");
}
void DisplayAllStudents()
{
    string query = @"
        SELECT
            s.StudentId,
            s.Name,
            s.Class,
            s.Section,
            sub.SubjectName,
            sg.Grade
        FROM Students s
        INNER JOIN StudentGrades sg
            ON s.StudentId = sg.StudentId
        INNER JOIN Subjects sub
            ON sg.SubjectId = sub.SubjectId
        ORDER BY s.StudentId, sub.SubjectId;
    ";

    using SqlConnection connection = new SqlConnection(connectionString);
    using SqlCommand command = new SqlCommand(query, connection);

    connection.Open();

    using SqlDataReader reader = command.ExecuteReader();

    Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();
    
    while (reader.Read())
    {
        int studentId = Convert.ToInt32(reader["StudentId"]);

        if (!studentDictionary.ContainsKey(studentId))
        {
            studentDictionary[studentId] = new Student(
                reader["Name"].ToString(),
                reader["Class"].ToString(),
                reader["Section"].ToString(),
                new string[0],
                new double[0]
            );
        }

        Student student = studentDictionary[studentId];

        // Add the subject and grade from this row
        student.AddGrade(
            reader["SubjectName"].ToString(),
            Convert.ToDouble(reader["Grade"])
        );
    }

    if (studentDictionary.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }

    foreach (Student student in studentDictionary.Values)
    {
        student.DisplayInfo();
    }
}
void SearchStudentByName()
{
    Console.Write("\nEnter name to search: ");
    string searchName = Console.ReadLine();

    string query = @"
        SELECT
            s.StudentId,
            s.Name,
            s.Class,
            s.Section,
            sub.SubjectName,
            sg.Grade
        FROM Students s
        INNER JOIN StudentGrades sg
            ON s.StudentId = sg.StudentId
        INNER JOIN Subjects sub
            ON sg.SubjectId = sub.SubjectId
        WHERE s.Name LIKE @Name
        ORDER BY s.StudentId, sub.SubjectId;
    ";

    using SqlConnection connection = new SqlConnection(connectionString);
    using SqlCommand command = new SqlCommand(query, connection);

    command.Parameters.AddWithValue("@Name", "%" + searchName + "%");

    connection.Open();

    using SqlDataReader reader = command.ExecuteReader();

    Dictionary<int, Student> studentDictionary =
        new Dictionary<int, Student>();

    while (reader.Read())
    {
        int studentId = Convert.ToInt32(reader["StudentId"]);

        if (!studentDictionary.ContainsKey(studentId))
        {
            studentDictionary[studentId] = new Student(
                reader["Name"].ToString(),
                reader["Class"].ToString(),
                reader["Section"].ToString(),
                new string[0],
                new double[0]
            );
        }

        Student student = studentDictionary[studentId];

        student.AddGrade(
            reader["SubjectName"].ToString(),
            Convert.ToDouble(reader["Grade"])
        );
    }

    if (studentDictionary.Count == 0)
    {
        Console.WriteLine("No student found.");
        return;
    }

    foreach (Student student in studentDictionary.Values)
    {
        student.DisplayInfo();
    }
}
void GenerateReport()
{
    Console.WriteLine("\n------------ GRADE REPORT -------------");

    string query = @"
        SELECT
            s.StudentId,
            s.Name,
            AVG(sg.Grade) AS Average
        FROM Students s
        INNER JOIN StudentGrades sg
            ON s.StudentId = sg.StudentId
        GROUP BY
            s.StudentId,
            s.Name
        ORDER BY s.StudentId;
    ";

    using SqlConnection connection =
        new SqlConnection(connectionString);

    using SqlCommand command =
        new SqlCommand(query, connection);

    connection.Open();

    using SqlDataReader reader =
        command.ExecuteReader();

    bool found = false;

    int totalStudents = 0;
    int passed = 0;
    int failed = 0;

    double classTotal = 0;

    Console.WriteLine(
        $"{"ID",-8}{"Name",-15}{"Average",-12}{"Grade",-10}{"Status"}"
    );

    Console.WriteLine(new string('-', 60));

    while (reader.Read())
    {
        found = true;

        int studentId = Convert.ToInt32(reader["StudentId"]);
        string name = reader["Name"].ToString();
        double average = Convert.ToDouble(reader["Average"]);

        string grade;

        if (average >= 90)
            grade = "A";
        else if (average >= 80)
            grade = "B";
        else if (average >= 70)
            grade = "C";
        else if (average >= 40)
            grade = "D";
        else
            grade = "F";

        string status = average >= 40 ? "PASS" : "FAIL";

        Console.WriteLine(
            $"{studentId,-8}{name,-15}{average,-12:F2}{grade,-10}{status}"
        );

        totalStudents++;

        if (status == "PASS")
            passed++;
        else
            failed++;

        classTotal += average;
    }

    if (!found)
    {
        Console.WriteLine("No students found.");
        return;
    }

    Console.WriteLine(new string('-', 60));

    Console.WriteLine($"Total Students : {totalStudents}");
    Console.WriteLine($"Passed         : {passed}");
    Console.WriteLine($"Failed         : {failed}");
    Console.WriteLine($"Class Average  : {classTotal / totalStudents:F2}");
}
double GetValidGrade(string subjectName)
{
    double grade;
    bool valid = false;

    do
    {
        Console.Write($"{subjectName}: ");
        bool parsed = double.TryParse(Console.ReadLine(), out grade);

        if (parsed && grade >= 0 && grade <= 100)
            valid = true;
        else
            Console.WriteLine("Invalid. Enter a value between 0 and 100.");

    } while (!valid);

    return grade;
}
