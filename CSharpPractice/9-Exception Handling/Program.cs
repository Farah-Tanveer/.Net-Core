//Exception Handling in C#
//When something goes wrong at runtime — dividing by zero, accessing a null object, reading a file that doesn't exist — C# throws an exception.
//Without handling it, your program crashes. Exception handling lets you catch the problem, respond gracefully, and keep running.

//built in exceptions
try
{
    Console.WriteLine("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine()); // throws FormatException if not a number
    int[] arr = new int[5];
    arr[number] = 100; // throws IndexOutOfRangeException if number > 4
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid input: {ex.Message}");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Index out of range: {ex.Message}");
}
catch (Exception ex) // catches anything else — always last
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
finally
{
    // Runs whether exception happened or not
    // Used for cleanup — closing files, database connections etc.
    Console.WriteLine("Finally block always runs");
}

//manually throw an exception
static double Divide(int a, int b)
{
    if (b == 0)
        throw new ArgumentException("Cannot divide by zero");
    return (double)a / b;
}

try
{
    Console.WriteLine(Divide(10, 0));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

//throw and catch custom exceptions

BankAccount acc = new BankAccount(500);
try
{
    acc.Withdraw(200);
    Console.WriteLine($"Balance: {acc.GetBalance()}"); // 300
    acc.Withdraw(1000); // throws InsufficientFundsException
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Custom error: {ex.Message}");
}
class InsufficientFundsException : Exception
{
    public double Amount { get; }

    public InsufficientFundsException(double amount)
        : base($"Insufficient funds. Tried to withdraw {amount}")
    {
        Amount = amount;
    }
}

class BankAccount
{
    private double balance;

    public BankAccount(double startingBalance)
    {
        balance = startingBalance;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
            throw new InsufficientFundsException(amount);
        balance -= amount;
    }

    public double GetBalance() => balance;
}
