// What a class is:
//A class is a blueprint. It describes what an object looks like (properties) and what it can do (methods).
//An object is a real instance created from that blueprint.


// ===================== TEST CODE — runs on startup =====================

// Basic Student (notes example)
Student s1 = new Student("Farah");
s1.AddMark(85);
s1.AddMark(90);
Console.WriteLine($"Student: {s1.Name}");
Console.WriteLine($"Average: {s1.GetAverage():F2}");
Console.WriteLine($"Grade: {s1.GetGrade()}");

// Person
Person p1 = new Person("Farah", 20, "Lahore");
Person p2 = new Person("Sara", 22, "Karachi");
Person p3 = new Person("Zara", 19, "Islamabad");
p1.Greet();
p2.Greet();
p3.Greet();

// Rectangle
Rectangle r1 = new Rectangle(5, 10);
Rectangle r2 = new Rectangle(7, 7);
Console.WriteLine(r1.GetArea());
Console.WriteLine(r1.GetPerimeter());
Console.WriteLine(r1.IsSquare());
Console.WriteLine(r2.IsSquare());

// BankAccount
BankAccount account = new BankAccount("Alice", 500.00);
account.Deposit(150.50);
Console.WriteLine($"Balance after deposit: {account.GetBalance()}");
account.Withdraw(200.00);
Console.WriteLine($"Balance after withdrawal: {account.GetBalance()}");
account.Withdraw(600.00); // should print Insufficient funds

// Exercise 4 — Student with marks
Student student1 = new Student("Bob");
student1.AddMark(85);
student1.AddMark(90);
student1.AddMark(78);
student1.AddMark(92);
student1.AddMark(88);
Console.WriteLine($"\nStudent: {student1.Name}");
Console.WriteLine($"Average Mark: {student1.GetAverage():F2}");
Console.WriteLine($"Highest Mark: {student1.GetHighest()}");
Console.WriteLine($"Final Grade: {student1.GetGrade()}");

Student student2 = new Student("Charlie");
student2.AddMark(60);
student2.AddMark(72);
student2.AddMark(65);
student2.AddMark(58);
student2.AddMark(70);
Console.WriteLine($"\nStudent: {student2.Name}");
Console.WriteLine($"Average Mark: {student2.GetAverage():F2}");
Console.WriteLine($"Highest Mark: {student2.GetHighest()}");
Console.WriteLine($"Final Grade: {student2.GetGrade()}");


// ===================== CLASS DEFINITIONS — always at the bottom =====================

// Student class — Exercise 4 version (removed duplicate basic version)
class Student
{
    public string Name { get; set; }
    public List<int> Marks { get; set; }

    public Student(string name)
    {
        Name = name;
        Marks = new List<int>();
    }

    public void AddMark(int mark)
    {
        Marks.Add(mark);
    }

    public double GetAverage()
    {
        if (Marks.Count == 0) return 0;
        return Marks.Average();
    }

    public int GetHighest()
    {
        if (Marks.Count == 0) return 0;
        return Marks.Max();
    }

    public char GetGrade()
    {
        double avg = GetAverage();
        if (avg >= 90) return 'A';
        if (avg >= 80) return 'B';
        if (avg >= 70) return 'C';
        if (avg >= 60) return 'D';
        return 'F';
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }

    public Person(string name, int age, string city)
    {
        Name = name;
        Age = age;
        City = city;
    }

    public void Greet()
    {
        Console.WriteLine($"Hi, I am {Name}, {Age} years old, from {City}");
    }
}

class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int GetArea()
    {
        return Width * Height;
    }

    public int GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public bool IsSquare()
    {
        return Width == Height;
    }
}

class BankAccount
{
    public string OwnerName { get; set; }
    private double Balance { get; set; }

    public BankAccount(string ownerName, double startingBalance)
    {
        OwnerName = ownerName;
        Balance = startingBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
            Balance -= amount;
        else
            Console.WriteLine("Insufficient funds");
    }

    public double GetBalance()
    {
        return Balance;
    }
}
