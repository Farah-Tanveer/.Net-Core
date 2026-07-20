using System;

public class Program
{
    public static void Main()
    {
        Exercise1();
        Exercise2();
        Exercise3();
        Exercise4();
        Exercise5();
        Exercise6();
        Exercise7();
        Exercise8();
        Exercise9();
        Exercise10();
    }

    public static void Exercise1()
    {
        Console.WriteLine("Exercise 1");
        Console.Write("Hexadecimal number: ");
        string hexNumber = Console.ReadLine();

        int decimalNumber = Convert.ToInt32(hexNumber, 16);

        Console.WriteLine("Convert to-");
        Console.WriteLine($"Decimal number: {decimalNumber}\n");
    }

    public static void Exercise2()
    {
        Console.WriteLine("Exercise 2");
        Console.Write("Enter a string to test consecutive letters: ");
        string text = Console.ReadLine();

        bool hasConsecutive = false;
        for (int i = 0; i < text.Length - 1; i++)
        {
            if (text[i] == text[i + 1])
            {
                hasConsecutive = true;
                break;
            }
        }

        Console.WriteLine($"Original string: {text}");
        Console.WriteLine($"Test for consecutive similar letters! {hasConsecutive}\n");
    }

    public static void Exercise3()
    {
        Console.WriteLine("Exercise 3");
        int[] nums = { 1, 2, 3, 5, 4, 2, 3, 4 };
        int[] nums1 = { 2, 4, 2, 6, 4, 8 };

        PrintAverageResult(nums);
        PrintAverageResult(nums1);
        Console.WriteLine();
    }

    private static void PrintAverageResult(int[] array)
    {
        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }

        bool isWholeNumber = (sum % array.Length == 0);
        Console.WriteLine($"nums = {{ {string.Join(", ", array)} }}");
        Console.WriteLine($"Check the average value of the said array is a whole number or not: {isWholeNumber}");
    }

    public static void Exercise4()
    {
        Console.WriteLine("Exercise 4");
        string[] inputs = { "PHP", "javascript", "python" };

        foreach (string text in inputs)
        {
            char[] characters = text.ToCharArray();
            Array.Sort(characters);
            string sortedText = new string(characters);

            Console.WriteLine($"Original string: {text}");
            Console.WriteLine($"Convert the letters of the said string into alphabetical order: {sortedText}");
        }
        Console.WriteLine();
    }

    public static void Exercise5()
    {
        Console.WriteLine("Exercise 5");
        string[] inputs = { "PHP", "javascript", "python" };

        foreach (string text in inputs)
        {
            string result = (text.Length % 2 != 0) ? "Odd length" : "Even length";

            Console.WriteLine($"Original string: {text}");
            Console.WriteLine($"Convert the letters of the said string into alphabetical order: {result}");
        }
        Console.WriteLine();
    }

    public static void Exercise6()
    {
        Console.WriteLine("Exercise 6");
        int[] positions = { 1, 2, 4, 100 };
        string[] suffixes = { "st", "nd", "th", "th" };

        for (int i = 0; i < positions.Length; i++)
        {
            int n = positions[i];
            int nthOdd = (2 * n) - 1;
            Console.WriteLine($"{n}{suffixes[i]} odd number: {nthOdd}");
        }
        Console.WriteLine();
    }

    public static void Exercise7()
    {
        Console.WriteLine("Exercise 7");
        char[] characters = { '1', 'A', 'a', '#' };

        foreach (char ch in characters)
        {
            int asciiValue = (int)ch;
            Console.WriteLine($"Ascii value of {ch} is: {asciiValue}");
        }
        Console.WriteLine();
    }

    public static void Exercise8()
    {
        Console.WriteLine("Exercise 8");
        string[] words = { "Exercise", "Exercises", "Books", "Book" };

        foreach (string word in words)
        {
            bool isPlural = word.EndsWith("s", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Is '{word}' is plural? {isPlural}");
        }
        Console.WriteLine();
    }

    public static void Exercise9()
    {
        Console.WriteLine("Exercise 9");

        string initialString = "50";
        Console.WriteLine($"Original value and type: {initialString}, {initialString.GetType()}");
        Console.WriteLine("Convert string to integer:");
        int convertedInt = Convert.ToInt32(initialString);
        Console.WriteLine($"Return value and type: {convertedInt}, {convertedInt.GetType()}");

        int initialInt = 122;
        Console.WriteLine($"Original value and type: {initialInt}, {initialInt.GetType()}");
        Console.WriteLine("Convert integer to string:");
        string convertedString = initialInt.ToString();
        Console.WriteLine($"Return value and type: {convertedString}, {convertedString.GetType()}\n");
    }

    public static void Exercise10()
    {
        Console.WriteLine("Exercise 10");
        Console.Write("Input an integer value: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number >= 10 && number <= 99)
        {
            int tens = number / 10;
            int ones = number % 10;
            int swappedNumber = (ones * 10) + tens;

            bool isGreater = number > swappedNumber;
            Console.WriteLine($"Check whether the said value is greater than its swap value: {isGreater}\n");
        }
        else
        {
            Console.WriteLine("Please input a valid two-digit integer.\n");
        }
    }
}
