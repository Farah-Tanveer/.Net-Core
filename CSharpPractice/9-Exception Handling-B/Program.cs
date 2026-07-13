// Exception Handling
//One Exercise — Smart BankAccount
//Build on your BankAccount class from Day 7/8 and add proper exception handling throughout:

BankAccount acc = new BankAccount("Farah", 1000);

// Test 1 — valid deposit
try
{
    acc.Deposit(500);
    Console.WriteLine($"Balance after deposit: {acc.GetBalance()}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Deposit error: {ex.Message}");
}

// Test 2 — invalid deposit (negative amount)
try
{
    acc.Deposit(-200);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Deposit error: {ex.Message}");
}

// Test 3 — valid withdrawal
try
{
    acc.Withdraw(300);
    Console.WriteLine($"Balance after withdrawal: {acc.GetBalance()}");
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Withdrawal error: {ex.Message}");
}

// Test 4 — withdrawal more than balance
try
{
    acc.Withdraw(5000);
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Withdrawal error: {ex.Message}");
}

// Test 5 — invalid starting balance
try
{
    BankAccount badAcc = new BankAccount("Sara", -500);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Account creation error: {ex.Message}");
}


// ===================== CLASS DEFINITIONS =====================

class InsufficientFundsException : Exception
{
    public double Amount { get; }

    public InsufficientFundsException(double amount)
        : base($"Insufficient funds. Cannot withdraw {amount}. Check your balance.")
    {
        Amount = amount;
    }
}

class BankAccount
{
    public string OwnerName { get; set; }
    private double Balance { get; set; }

    public BankAccount(string ownerName, double startingBalance)
    {
        if (startingBalance < 0)
            throw new ArgumentException("Starting balance cannot be negative");

        OwnerName = ownerName;
        Balance = startingBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero");
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > Balance)
            throw new InsufficientFundsException(amount);
        Balance -= amount;
    }

    public double GetBalance()
    {
        return Balance;
    }
}