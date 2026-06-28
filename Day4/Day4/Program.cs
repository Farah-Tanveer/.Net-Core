// Exercise 1: print numbers 1-10, even numbers only
for(int i=0;i<=10; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}

// Exercise 2: ask user for numbers in a loop, stop when they type 0, print the sum
int sum = 0;
while (true)
{
    Console.WriteLine("Enter numbers (press 0 to stop): ");
    int number = Convert.ToInt32(Console.ReadLine());
    if (number == 0)
    {
        break;
    }
    sum += number;
}
Console.WriteLine($"Sum of all numbers: ");

// Exercise 3: FizzBuzz — 1 to 50
//   divisible by 3 → "Fizz"
//   divisible by 5 → "Buzz"  
//   divisible by both → "FizzBuzz"
//   otherwise → just the number
for(int i = 1; i <= 50; i++)
{
    if (i % 3 == 0)
        Console.WriteLine("Fizz");
    else if (i % 5 == 0)
        Console.WriteLine("Buzz");
}
