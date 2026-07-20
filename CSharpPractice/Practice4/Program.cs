

Console.WriteLine("\nExercise 1");
//Write a C# program to find the longest word in a string.
//Test  Data: Write a C# Sharp Program to display the following pattern using the alphabet.
//Sample Output:
//following
Console.Write("Input a string: ");
string input = Console.ReadLine();

string[] words = input.Split(' ');
string longestWord = "";

foreach (string word in words)
{
    if (word.Length > longestWord.Length)
    {
        longestWord = word;
    }
}

Console.WriteLine(longestWord);


Console.WriteLine("\nExercise 2");
//Write a C# program to convert a given string into lowercase.
//Sample Output:
//write a c# sharp program to display the following pattern using the alphabet.
string inputString = "Write a C# Sharp Program to display the following pattern using the alphabet.";
string lowercaseString = inputString.ToLower();
Console.WriteLine(lowercaseString);

Console.WriteLine("Exercise 3");
//Write a C# program to check if a string starts with a specified word.
//Note: Suppose the sentence starts with "Hello"
//Sample Data: string1 = "Hello how are you?"
//Result: Hello.
//Sample Output:
//Input a string : Hello how are you?
//True
Console.Write("Input a string : ");
string inputString1 = Console.ReadLine();

bool result = inputString1.StartsWith("Hello");

Console.WriteLine(result);

Console.WriteLine("\nExercise 4");
//Write a C# program to check if "HP" appears at the second position in a string and return the string without "HP".
//Test Data: PHP Tutorial
//Sample Output:
//P Tutorial
string input2 = "PHP Tutorial";

if (input.Length >= 3 && input2.Substring(1, 2) == "HP")
{
    string result1 = input2.Substring(0, 1) + input2.Substring(3);
    Console.WriteLine(result1);
}
else
{
    Console.WriteLine(input2);
}

Console.WriteLine("\nExercise 5");
//Write a C# program to create a string where the first 4 characters are in lower case. If the string is less than 4 letters, make the whole string in upper case.
//Test Data:
//Input a string: w3r
//Sample Output
//W3R
Console.Write("Input a string: ");
string input1 = Console.ReadLine();

if (input1.Length < 4)
{
    Console.WriteLine(input1.ToUpper());
}
else
{
    string result2 = input1.Substring(0, 4).ToLower() + input1.Substring(4);
    Console.WriteLine(result2);
}


Console.WriteLine("\nExercise 6");
//Write a C# program that checks if the first element and the last element of an array of integers are equal. The array length is 1 or more.
//Test Data:
//Array1: [1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 1]
//Sample Output
//True
//avoid hard coding
int[] array1 = { 1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 1 };

bool areEqual = array1[0] == array1[array1.Length - 1];

Console.WriteLine(areEqual);


Console.WriteLine("\nExercise 7");
//Write a C# program to get the largest value between the first and last element of an array (length 3) of integers.
//Test Data:
//Array1: [1, 2, 5, 7, 8]
//Highest value between first and last values of the said array: 8
int[] arr = { 1, 2, 5, 7, 8 };

int highestValue = Math.Max(arr[0], arr[arr.Length - 1]);

Console.WriteLine($"Highest value between first and last values of the said array: {highestValue}");


Console.WriteLine("\nExercise 8");
//Write a C# program to get the century of a year.
Console.Write("Input a year: ");
int year = Convert.ToInt32(Console.ReadLine());

int century = (year + 99) / 100;

Console.WriteLine($"Century: {century}");

Console.WriteLine("\nExercise 9");
//Write a C# program to find the pair of adjacent elements that has the largest product of the given array.
int[] array = { 1, 3, -4, 2, 5, -1 };

int maxProduct = array[0] * array[1];

for (int i = 1; i < array.Length - 1; i++)
{
    int currentProduct = array[i] * array[i + 1];
    maxProduct = Math.Max(maxProduct, currentProduct);
}

Console.WriteLine($"Largest product of adjacent elements: {maxProduct}");


Console.WriteLine("\nExercise 10");
//Write a C# program to check if a given string is a palindrome or not.
//Sample Example:
//For 'aaa' the output should be true
//For 'abcd' the output should be false
string[] testStrings = { "aaa", "abcd" };

foreach (string text in testStrings)
{
    char[] charArray = text.ToCharArray();
    Array.Reverse(charArray);
    string reversedText = new string(charArray);

    bool isPalindrome = text == reversedText;
    Console.WriteLine($"For '{text}' the output(Palindrome) should be {isPalindrome.ToString().ToLower()}");
}
