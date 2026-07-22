//Console App
using System.Diagnostics;

List<Student> students = new List<Student>();
int roll = 1;
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

    string[] subjects = { "Math", "Physics", "Chemistry", "English", "Computer" };
    double[] grades = new double[subjects.Length];

    Console.WriteLine("\nEnter grades for each subject (0-100):");

    for (int i = 0; i < subjects.Length; i++)
    {
        grades[i] = GetValidGrade(subjects[i]);
    }
    Student student = new Student(roll++, name, studentClass, section, subjects, grades);
    students.Add(student);

    Console.WriteLine($"\nStudent {name} added. Roll Number: {student.RollNumber}");
}
void DisplayAllStudents()
{

    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }

    foreach (Student s in students)
    {
        s.DisplayInfo();
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

        Console.WriteLine($"{s.RollNumber}         {s.Name}         {avg:F2}         {grade}       {status}");
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
class Student
{
    public string Name { get; set; }
    public int RollNumber { get; set; }

    public string Class { get; set; }
    public string Section { get; set; }
    public double[] Grades { get; private set; }

    public string[] Subject { get; private set; }

    public Student(int rollNumber, string name, string Sclass, string section, string[] subject, double[] grades)
    {
        RollNumber = rollNumber;
        Name = name;
        Class = Sclass;
        Section = section;
        Grades = grades;
        Subject = subject;

    }
    public double CalculateAverage()
    {
        if (Grades.Length == 0) return 0;
        double sum = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Length;
    }

    public string GetLetterGrade()
    {

        double avg = CalculateAverage();
        if (avg < 0 || avg > 100) return "Invalid Grade";
        if (avg >= 90 && avg <= 100) return "A";
        if (avg >= 80 && avg < 90) return "B";
        if (avg >= 70 && avg < 80) return "C";
        if (avg >= 40 && avg < 70) return "D";
        return "F";
    }

    public bool HasPassed()
    {
        return CalculateAverage() >= 40;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"\nRoll Number : {RollNumber}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Class       : {Class} - {Section}");
        Console.WriteLine($"Average     : {CalculateAverage():F2}");
        Console.WriteLine($"Grade       : {GetLetterGrade()}");
        Console.WriteLine($"Status      : {(HasPassed() ? "PASS" : "FAIL")}");

        Console.WriteLine("Subject Grades:");
        for (int i = 0; i < Subject.Length; i++)
            Console.WriteLine($"  {Subject[i],-12}: {Grades[i]}");
    }
}