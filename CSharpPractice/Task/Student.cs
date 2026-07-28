public class Student
{
    public string Name { get; set; }

    public string Class { get; set; }
    public string Section { get; set; }
    public double[] Grades { get; private set; }

    public string[] Subject { get; private set; }

    public Student( string name, string Sclass, string section, string[] subject, double[] grades)
    {
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
