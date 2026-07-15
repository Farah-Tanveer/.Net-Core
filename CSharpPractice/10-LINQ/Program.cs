// LINQ- Language integrated Query
// Build a Student Report System
// Create a list of at least 6 students with Name, Age, and GPA
// Then using LINQ only (no manual loops) produce:

// 1. List of students with GPA above 3.5 — print names
// 2. Student with highest GPA — print name and GPA
// 3. Average GPA of all students — print formatted to 2 decimal places
// 4. Students ordered by GPA descending — print each name and GPA
// 5. Count of students with GPA below 3.0
// 6. Names of all students aged 20 — as a comma-separated string
//    Hint: string.Join(", ", collection)
List<Student> students = new List<Student>
{
    new Student("Farah", 20, 3.8),
    new Student("Sara", 22, 2.9),
    new Student("Zara", 19, 3.5),
    new Student("Hina", 21, 3.1),
    new Student("Noor", 20, 3.9),
    new Student("Tania", 21, 3.1)
};
var achievers= students.Where(s => s.GPA > 3.5).Select(s => s.Name).ToList();
var Average= students.Average(s=>s.GPA).ToString("F2");
var Order = students.OrderByDescending(s => s.GPA).Select(s => new { s.Name, s.GPA });
var LowGPA= students.Where(s=>s.GPA<3.0).Count();
var aged20=students.Where(s=>s.Age==20).Select(s=>s.Name).ToList();
var agestring = string.Join(", ", aged20);
var topStudent = students.MaxBy(s => s.GPA);


Console.WriteLine($"Aged 20: {agestring}");

Console.WriteLine($"Highest GPA: {topStudent.Name} — {topStudent.GPA}");

Console.WriteLine($"Achievers (GPA > 3.5): {string.Join(", ", achievers)}");


Console.WriteLine($"Average GPA: {Average}");


Console.WriteLine("Ordered Collection:");
foreach (var student in Order)
{
    Console.WriteLine($"  - {student.Name}: {student.GPA}");
}


Console.WriteLine($"Count of students with low GPA (< 3.0): {LowGPA}");

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA {  get; set; }
    public Student(string name, int age, double gpa)
    {
        Name = name;
        Age = age;
        GPA = gpa;
    }
}

