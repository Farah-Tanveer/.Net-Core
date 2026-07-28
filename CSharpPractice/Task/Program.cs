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
    string query = "SELECT * FROM Students";

    using SqlConnection connection = new SqlConnection(connectionString);
    using SqlCommand command = new SqlCommand(query, connection);

    connection.Open();

    using SqlDataReader reader = command.ExecuteReader();

    bool found = false;

    while (reader.Read())
    {
        found = true;
        Console.WriteLine("\n-----------------------");
        Console.WriteLine($"Student ID : {reader["StudentId"]}");
        Console.WriteLine($"Name       :{reader["Name"]}");
        Console.WriteLine($"Class      : {reader["Class"]}");
        Console.WriteLine($"Section    : {reader["Section"]}");
    }

    if (!found)
    {
        Console.WriteLine("No students found.");
    }
}


void SearchStudentByName()
{
    Console.Write("\nEnter name to search: ");
    string searchName = Console.ReadLine().ToLower();
    bool found = false;

    foreach (Student s in students)
    {
        if (s.Name.ToLower().Contains(searchName))
        {
            s.DisplayInfo();
            found = true;
        }
    }

    if (!found)
        Console.WriteLine("No student found.");
}

void GenerateReport()
{
    Console.WriteLine("\n------------ GRADE REPORT -------------");

    if (students.Count == 0)
    {
        Console.WriteLine("No students to report.");
        return;
    }

    int passed = 0;
    int failed = 0;
    double classTotal = 0;

    Console.WriteLine($"{"Roll#    "} {"Name       "} {"Average    "} {"Grade  "} {"Status "}");
    Console.WriteLine(new string('-', 58));

    foreach (Student s in students)
    {
        double avg = s.CalculateAverage();
        string grade = s.GetLetterGrade();
        string status = s.HasPassed() ? "PASS" : "FAIL";

        if (s.HasPassed()) passed++;
        else failed++;

        classTotal += avg;

        Console.WriteLine($"{s.Name}         {avg:F2}         {grade}       {status}");
    }

    Console.WriteLine(new string('-', 58));
    Console.WriteLine($"Total Students : {students.Count}");
    Console.WriteLine($"Passed         : {passed}");
    Console.WriteLine($"Failed         : {failed}");
    Console.WriteLine($"Class Average  : {classTotal / students.Count:F2}");
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
