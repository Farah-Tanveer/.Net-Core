// What an interface is:
//An interface is a contract. It says "any class that implements me MUST have these methods."
//It has no code inside — just method signatures. Think of it as abstract class but even stricter, and a class can implement multiple interfaces unlike inheritance.
// Define the contract

Dog d = new Dog("Max");
Cat c = new Cat("Luna");

d.MakeSound(); // Max barks
c.MakeSound(); // Luna meows
interface IAnimal
{
    void MakeSound();     // no body — just the signature
    string GetName();
}

// Class MUST implement all interface methods
class Dog : IAnimal
{
    public string Name { get; set; }
    public Dog(string name) { Name = name; }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} barks");
    }

    public string GetName()
    {
        return Name;
    }
}

class Cat : IAnimal
{
    public string Name { get; set; }
    public Cat(string name) { Name = name; }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} meows");
    }

    public string GetName()
    {
        return Name;
    }
}
// Create an interface called IPayable with:
// Method CalculatePay() returning double
// Method GetPaymentDetails() returning string
interface IPayable
{
    public double CalculatePay();
}
// Implement it in three classes:
// FullTimeEmployee — has Name and MonthlySalary
//   CalculatePay() returns MonthlySalary
//   GetPaymentDetails() returns "FullTime: [Name] — Rs.[salary]/month"

// PartTimeEmployee — has Name, HourlyRate, HoursWorked
//   CalculatePay() returns HourlyRate * HoursWorked
//   GetPaymentDetails() returns "PartTime: [Name] — Rs.[total] this month"

// Freelancer — has Name, ProjectFee, and CompletionBonus
//   CalculatePay() returns ProjectFee + CompletionBonus
//   GetPaymentDetails() returns "Freelancer: [Name] — Rs.[total] this project"

// Store all three in a List<IPayable>
// Loop through and print GetPaymentDetails() and CalculatePay() for each