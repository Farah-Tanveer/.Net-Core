// Inheritance
//Inheritance lets one class acquire the properties and methods of another. 
//It models real-world "is-a" relationships — a Student IS A Person, a Dog IS AN Animal. 
//You write shared code once in a parent class and reuse it everywhere.

// ===================== TEST CODE =====================

// Notes example — Student/Person
Student s = new Student("Farah", 20, "Lahore", "PUCIT", new List<int>());
s.Introduce();
s.Study();

// Exercise 1 — Vehicle
Car myCar = new Car("Toyota", 120, 4);
Motorcycle myBike = new Motorcycle("Harley-Davidson", 80, false);
myCar.Move();
myBike.Move();

// Exercise 2 — Employee
Manager mgr = new Manager("Alice", 5000);
Developer dev = new Developer("Bob", 4000);
Console.WriteLine($"Name: {mgr.Name}, Total Salary: ${mgr.GetTotalSalary():N2}");
Console.WriteLine($"Name: {dev.Name}, Total Salary: ${dev.GetTotalSalary():N2}");

// Exercise 3 — Person hierarchy
Console.WriteLine("--- Base Person Objects ---");
Person person1 = new Person("Alice", 28, "London");
Person person2 = new Person("Bob", 34, "New York");
Person person3 = new Person("John", 22, "Tokyo");
person1.Greet();
person2.Greet();
person3.Greet();
Console.WriteLine();

List<int> studentMarks = new List<int> { 90, 85, 92, 78 };
Student student = new Student("Charlie", 20, "Boston", "MIT", studentMarks);
Teacher teacher = new Teacher("Mr. Smith", 42, "Chicago", "Mathematics", 15);
Admin admin = new Admin("Diana", 35, "Austin", "Human Resources");

student.Introduce();
Console.WriteLine();
teacher.Introduce();
Console.WriteLine();
admin.Introduce();
Console.WriteLine();

// Exercise 4 — Shapes
List<Shape> shapes = new List<Shape>
{
    new Circle(5),
    new Rectangle(4, 6),
    new Triangle(3, 4, 5)
};

foreach (Shape shape in shapes)
{
    shape.Describe();
}


// ===================== CLASS DEFINITIONS =====================

// Person — single class covering notes + Exercise 3
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
        Console.WriteLine($"Hi I am {Name}, {Age} years old, from {City}");
    }

    public virtual void Introduce()
    {
        Greet();
    }
}

// Student — single class covering notes + Exercise 3
class Student : Person
{
    public string University { get; set; }
    public List<int> Marks { get; set; }

    public Student(string name, int age, string city, string university, List<int> marks)
        : base(name, age, city)
    {
        University = university;
        Marks = marks ?? new List<int>();
    }

    public double GetAverage()
    {
        if (Marks == null || Marks.Count == 0) return 0;
        return Marks.Average();
    }

    public void Study()
    {
        Console.WriteLine($"{Name} is studying at {University}");
    }

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine($"I study at {University} and my average mark is {GetAverage():F1}.");
    }
}

// Teacher
class Teacher : Person
{
    public string Subject { get; set; }
    public int YearsOfExperience { get; set; }

    public Teacher(string name, int age, string city, string subject, int yearsOfExperience)
        : base(name, age, city)
    {
        Subject = subject;
        YearsOfExperience = yearsOfExperience;
    }

    public string GetBio()
    {
        return $"{Name} has been teaching {Subject} for {YearsOfExperience} years.";
    }

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine($"I teach {Subject} and I have {YearsOfExperience} years of experience.");
    }
}

// Admin
class Admin : Person
{
    public string Department { get; set; }

    public Admin(string name, int age, string city, string department)
        : base(name, age, city)
    {
        Department = department;
    }

    public string GetRole()
    {
        return $"Administrator in the {Department} department.";
    }

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine($"I work as an administrator in the {Department} department.");
    }
}

// Vehicle
class Vehicle
{
    public string Brand { get; set; }
    public int Speed { get; set; }

    public Vehicle(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Brand} is moving at {Speed} km/h");
    }
}

class Car : Vehicle
{
    public int Doors { get; set; }

    public Car(string brand, int speed, int doors) : base(brand, speed)
    {
        Doors = doors;
    }

    public override void Move()
    {
        Console.WriteLine($"Car {Brand} driving at {Speed} km/h");
    }
}

class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motorcycle(string brand, int speed, bool hasSidecar) : base(brand, speed)
    {
        HasSidecar = hasSidecar;
    }

    public override void Move()
    {
        string sidecarStatus = HasSidecar ? "with a sidecar" : "without a sidecar";
        Console.WriteLine($"Motorcycle {Brand} cruising at {Speed} km/h {sidecarStatus}");
    }
}

// Employee — abstract
abstract class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public Employee(string name, double baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    public abstract double GetBonus();

    public double GetTotalSalary()
    {
        return BaseSalary + GetBonus();
    }
}

// ✅ Manager and Developer are now TOP-LEVEL classes, not nested inside Employee
class Manager : Employee
{
    public Manager(string name, double baseSalary) : base(name, baseSalary) { }

    public override double GetBonus()
    {
        return BaseSalary * 0.20;
    }
}

class Developer : Employee
{
    public Developer(string name, double baseSalary) : base(name, baseSalary) { }

    public override double GetBonus()
    {
        return BaseSalary * 0.15;
    }
}

// Shape — abstract
abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();

    public void Describe()
    {
        string className = this.GetType().Name;
        Console.WriteLine($"This {className} has area {GetArea():F2} and perimeter {GetPerimeter():F2}");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
}

class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public override double GetArea()
    {
        double s = GetPerimeter() / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override double GetPerimeter()
    {
        return SideA + SideB + SideC;
    }
}
