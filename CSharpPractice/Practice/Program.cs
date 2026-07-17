// Write a C# program to convert Celsius degrees to Kelvin and Fahrenheit.

//Test Data:
//Enter the amount of celsius: 30
//Expected Output:
//Kelvin = 303
//Fahrenheit = 86

using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Exercise 1");
Console.WriteLine("Enter the amount of celsius: ");
double celsius = Convert.ToDouble(Console.ReadLine());
double f = (celsius * 9 / 5) + 32;
double k = celsius + 273.15;
Console.WriteLine($"Kelvin: {k}\nFahrenheit: {f}");


//Write a C# program to check if an integer (from the two given integers) is in the range -10 to 10.
//Sample Output:
//Input a first number: -5
//Input a second number: 8
//True
Console.WriteLine("\nExercise 2");
Console.WriteLine("Check range [-10,10]: ");
int num = Convert.ToInt32(Console.ReadLine());
if (num >= -10 && num <= 10)
{
    Console.WriteLine("Number is in range");
}
else
{
    Console.WriteLine("Number is not in range");
}
//Write a C# program to count a specified number in a given array of integers.
//Test Data:
//Input an integer: 5
//Sample Output
//Number of 5 present in the said array: 2

Console.WriteLine("\nExercise 3");
int count = 0;
Console.WriteLine("Enter an integer: ");
int integer = Convert.ToInt32(Console.ReadLine());
int[] arr = { 0, 5, 78, 90, 43, 27, 27, 5, 0, 90 };
foreach (int i in arr)
{
    if (i == integer)
    {
        count++;
    }
}
Console.WriteLine($"Number of {integer} present in the said array: {count}");

//Write a C# program to multiply the corresponding elements of two integer arrays.
//Sample Output:
//Array1: [1, 3, -5, 4]
//Array2: [1, 4, -5, -2]
//Multiply corresponding elements of two arrays:
//1 12 25 - 8
Console.WriteLine("\nExercise 4");
int[] arr1 = { 1, 3, -5, 4 };
int[] arr2 = { 1, 4, -5, -2 };
for (int i = 0; i < arr1.Length; i++)
{
    int result = arr1[i] * arr2[i];
    Console.WriteLine(result);
}

//Write a C# program to rotate an array (length 3) of integers in the left direction.
//Test Data:
//Array1: [1, 2, 8]
//After rotating array becomes: [2, 8, 1]Write a C# program to rotate an array (length 3) of integers in the left direction.
//Test Data:
//Array1: [1, 2, 8]
//After rotating array becomes: [2, 8, 1]
Console.WriteLine("\nExercise 5");
int[] a = { 1, 2, 8 };
if(a.Length > 1)
{
    int firstele = a[0];
    for(int  i=0; i < a.Length - 1; i++)
    {
        a[i] = a[i + 1];
    }
    a[a.Length - 1] = firstele;
}
Console.WriteLine($"After left rotation {string.Join(",", a)}");

//39.Largest and Lowest of Three Integers

//Write a C# program to find the largest and lowest values from three integer values.
//Test Data:
//Input first integer:
//15
//Input second integer:
//25
//Input third integer:
//30
//Sample Output
//Largest of three: 30
//Lowest of three: 15
Console.WriteLine("\nExercise 6");
Console.WriteLine("Find largest and lowest\nEnter first integer: ");
int x = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter second integer: ");
int y = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter third integer: ");
int z = Convert.ToInt32(Console.ReadLine());
int largest, lowest;
if (x > y)
{
    if (x > z)
    {
        largest = x;
    }
    else
    {
        largest = z;
    }

}
else
{
    if (y > z)
    {
        largest = y;
    }
    else
    {
        largest = z;
    }
}
Console.WriteLine("Largest of three: " + largest);

if (x < y)
{
    if (x < z)
    {
        lowest = x;
    }
    else
    {
        lowest = z;
    }

}
else
{
    if (y < z)
    {
        lowest = y;
    }
    else
    {
        lowest = z;
    }
}
Console.WriteLine("Lowest of three: " + lowest);

//Write a C# program that checks the nearest value of 20 of two given integers and return 0 if two numbers are same.
//Test Data:
//Input first integer:
//15
//Input second integer:
//12
//Sample Output
//15

Console.WriteLine("\nExercise 7");

Console.WriteLine("Find nearest to 20\nInput first integer:");
int first = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Input second integer:");
int second = Convert.ToInt32(Console.ReadLine());
if (first == second)
{
    Console.WriteLine(0);
}
else
{
    int distance1 = Math.Abs(20 - first);
    int distance2 = Math.Abs(20 - second);

    if (distance1 < distance2)
    {
        Console.WriteLine(first);
    }
    else
    {
        Console.WriteLine(second);
    }
}
//Count Specific Character in String
//Write a C# Sharp program to count a specified character
//(both cases) in a given string.

Console.WriteLine("\nExercise 8");
Console.WriteLine("Input a string: ");
string inputString = Console.ReadLine();

Console.WriteLine("Input a character to count: ");
char targetChar = Convert.ToChar(Console.ReadLine());

char lowerTarget = char.ToLower(targetChar);
int count1 = inputString.Count(c => char.ToLower(c) == lowerTarget);

Console.WriteLine($"Number of '{targetChar}' (both cases) present in the string: {count1}");

Console.WriteLine("\nCount Ones and Zeros in Binary");
//Write a C# Sharp program to count the number of ones and zeros in the binary representation of a given integer.
//Sample Output:
//Original number: 12
//Number of ones and zeros in the binary representation of the said number:
//Number of ones: 2
//Number of zeros: 2
//Original number: 1234
//Number of ones and zeros in the binary representation of the said number:
//Number of ones: 5
//Number of zeros: 6
Console.WriteLine("\nExercise 9");
Console.WriteLine("Enter an integer: ");
int number = Convert.ToInt32(Console.ReadLine());
string binaryStr = Convert.ToString(number, 2);

int onesCount = binaryStr.Count(c => c == '1');
int zerosCount = binaryStr.Count(c => c == '0');

Console.WriteLine($"Original number: {number}");
Console.WriteLine($"Number of ones: {onesCount}");
Console.WriteLine($"Number of zeros: {zerosCount}");


Console.WriteLine("\nCount Letters and Digits in String\nExercise 10");
//Write a C# Sharp program to get the number of letters and digits in a given string.
//Sample Output:
//Original string:: Python 3.0
//Number of letters: 6 Number of digits: 2
//Original string:: dsfkaso230samdm2423sa
//Number of letters: 14 Number of digits: 7

Console.WriteLine("Enter a string: ");
string text = Console.ReadLine();
int letterCount = text.Count(c => char.IsLetter(c));
int digitCount = text.Count(c => char.IsDigit(c));

// Output results in the specified format
Console.WriteLine($"Original string:: {text}");
Console.WriteLine($"Number of letters: {letterCount} Number of digits: {digitCount}");