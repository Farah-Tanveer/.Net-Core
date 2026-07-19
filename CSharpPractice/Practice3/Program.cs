//Write a C# Sharp program to calculate profit and loss on a transaction.
//Test Data :
//500 700
//Expected Output :
//You can book your profit amount : 200
Console.WriteLine("\nExercise 1");

Console.Write("Input Cost Price: ");
int costPrice = Convert.ToInt32(Console.ReadLine());

Console.Write("Input Selling Price: ");
int sellingPrice = Convert.ToInt32(Console.ReadLine());

if (sellingPrice > costPrice)
{
    int profit = sellingPrice - costPrice;
    Console.WriteLine($"You can book your profit amount : {profit}");
}
else if (costPrice > sellingPrice)
{
    int loss = costPrice - sellingPrice;
    Console.WriteLine($"You incurred a loss amount of : {loss}");
}
else
{
    Console.WriteLine("No profit, no loss.");
}

// Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.
//Test Data :4
//Expected Output :
//Thursday

Console.WriteLine("\nExercise 2");
Console.Write("Input day number: ");
int dayNumber = Convert.ToInt32(Console.ReadLine());

switch (dayNumber)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    case 4:
        Console.WriteLine("Thursday");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    case 6:
        Console.WriteLine("Saturday");
        break;
    case 7:
        Console.WriteLine("Sunday");
        break;
    default:
        Console.WriteLine("Invalid day number! Please enter a number between 1 and 7.");
        break;
}

//Write a program in C# Sharp to read any Month Number in integer and display the number of days for this month.
//Test Data :7
//Expected Output:
//Month have 31 days

Console.WriteLine("\nExercise 3");
Console.Write("Input Month No : ");
int monthNumber = Convert.ToInt32(Console.ReadLine());

switch (monthNumber)
{
    case 1:
    case 3:
    case 5:
    case 7:
    case 8:
    case 10:
    case 12:
        Console.WriteLine("Month have 31 days");
        break;
    case 4:
    case 6:
    case 9:
    case 11:
        Console.WriteLine("Month have 30 days");
        break;
    case 2:
        Console.WriteLine("Month have 28 or 29 days");
        break;
    default:
        Console.WriteLine("Invalid Month number. Please enter a number between 1 and 12.");
        break;
}


//Write a program in C# Sharp to read any digit, display in the word.
//Test Data :4
//Expected Output :
//Four

Console.WriteLine("\nExercise 4");
Console.Write("Input digit: ");
int digit = Convert.ToInt32(Console.ReadLine());

switch (digit)
{
    case 0:
        Console.WriteLine("Zero");
        break;
    case 1:
        Console.WriteLine("One");
        break;
    case 2:
        Console.WriteLine("Two");
        break;
    case 3:
        Console.WriteLine("Three");
        break;
    case 4:
        Console.WriteLine("Four");
        break;
    case 5:
        Console.WriteLine("Five");
        break;
    case 6:
        Console.WriteLine("Six");
        break;
    case 7:
        Console.WriteLine("Seven");
        break;
    case 8:
        Console.WriteLine("Eight");
        break;
    case 9:
        Console.WriteLine("Nine");
        break;
    default:
        Console.WriteLine("Not a single digit! Please enter a number between 0 and 9.");
        break;
}

//Write C# Sharp program to read any Month Number in integer and display Month name.
//Test Data :
//4
//Expected Output:
//April
Console.WriteLine("Exercise 5");
Console.Write("Input Month No : ");
int monthNum = Convert.ToInt32(Console.ReadLine());

switch (monthNum)
{
    case 1:
        Console.WriteLine("January");
        break;
    case 2:
        Console.WriteLine("February");
        break;
    case 3:
        Console.WriteLine("March");
        break;
    case 4:
        Console.WriteLine("April");
        break;
    case 5:
        Console.WriteLine("May");
        break;
    case 6:
        Console.WriteLine("June");
        break;
    case 7:
        Console.WriteLine("July");
        break;
    case 8:
        Console.WriteLine("August");
        break;
    case 9:
        Console.WriteLine("September");
        break;
    case 10:
        Console.WriteLine("October");
        break;
    case 11:
        Console.WriteLine("November");
        break;
    case 12:
    Console.WriteLine("December");
    break;
default:
    Console.WriteLine("Invalid Month number. Please enter a number between 1 and 12.");
    break;
}

//Write a C# Sharp program to find out whether a given year is a leap year or not.
//Test Data : 2016
//Expected Output :
//2016 is a leap year.

Console.WriteLine("\nExercise 6");
Console.Write("Input Year : ");
int year = Convert.ToInt32(Console.ReadLine());

if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
{
    Console.WriteLine($"{year} is a leap year.");
}
else
{
    Console.WriteLine($"{year} is not a leap year.");
}

//Write a C# Sharp program to swap two numbers.
//Test Data:
//Input the First Number : 5
//Input the Second Number : 6
//Expected Output:
//After Swapping :
//First Number : 6
//Second Number : 5
Console.WriteLine("\nExercise 7");
Console.Write("Input the First Number : ");
int num1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Input the Second Number : ");
int num2 = Convert.ToInt32(Console.ReadLine());

int temp = num1;
num1 = num2;
num2 = temp;

Console.WriteLine("After Swapping :");
Console.WriteLine($"First Number : {num1}");
Console.WriteLine($"Second Number : {num2}");

Console.WriteLine("\nExercise 8");
//Write a C# program that removes a specified character from a non-empty string using the index of a character.
//Test Data:
//w3resource
//Sample Output:
//wresource
//w3resourc
//3resource

string text = "w3resource";

Console.WriteLine(text.Remove(1, 1));
Console.WriteLine(text.Remove(9, 1));
Console.WriteLine(text.Remove(0, 1));

Console.WriteLine("\nExercise 9");
//Write a C# program to create a new string from a given string where the first and last characters change their positions.
//Test Data:
//w3resource
//Python
//Sample Output:
//e3resourcw
//nythoP
//x

Console.Write("Input a string : ");
string input = Console.ReadLine();

if (string.IsNullOrEmpty(input) || input.Length <= 1)
{
    Console.WriteLine(input);
}
else
{
    string result = input[input.Length - 1] + input.Substring(1, input.Length - 2) + input[0];
Console.WriteLine(result);
}

Console.WriteLine("\nExercise 10");
//Write a C# program to create a string from a given string (length 1 or more) with the first character added at the front and back.
//Sample Output:
//Input a string : The quick brown fox jumps over the lazy dog.
//TThe quick brown fox jumps over the lazy dog.T

Console.Write("Input a string : ");
string inputt = Console.ReadLine();

if (!string.IsNullOrEmpty(inputt))
{
    char firstChar = inputt[0];
    string result = firstChar + inputt + firstChar;
    Console.WriteLine(result);
}