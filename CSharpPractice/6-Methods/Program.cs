static void Greet(string name)
{
    Console.WriteLine($"Hello {name}!");
}
Greet("Farah");
static int Add(int a, int b)
{
    return a + b;
}
int result = Add(10, 3);
Console.WriteLine(result);
static void Register(string name, int age = 18)
{
    Console.WriteLine($"{name} is {age} years old");
}
Register("Farah");
static List<string> GetPassedStudents(List<string> names, List<int> marks)
{
    List<string> passed = new List<string>();
    for (int i = 0; i < names.Count; i++)
    {
        if (marks[i] >= 50)
            passed.Add(names[i]);
    }
    return passed;
}
// Exercise 1
// Write a method IsEven(int number) that returns true if even, false if odd
// Test it with 5 different numbers in a loop
static bool IsEven(int x)
{
    if (x % 2 == 0)
    {
        return true;
    }
    return false;
}
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(IsEven(i));
}
//Exercise 2
// Write a method GetGrade(int marks) that returns a grade as string
// 90+ = "A"
// 80+ = "B"
// 70+ = "C"
// 60+ = "D"
// below 60 = "F"
// Test it with marks: 95, 83, 72, 61, 45
static string GetGrade(int marks)
{
    if (marks >= 90 && marks<= 100)
    {
        return ("A");
    }
    else if (marks >= 80)
    {
        return ("B");
    }
    else if (marks >= 70)
    {
        return ("C");
    }
    else if (marks >= 60)
    {
        return ("D");
    }
    else
    {
        return ("F");
    }
}
Console.WriteLine(GetGrade(95));
Console.WriteLine(GetGrade(83));
Console.WriteLine(GetGrade(72));
Console.WriteLine(GetGrade(61));
Console.WriteLine(GetGrade(45));


// Exercise 3
// Write a method FindLargest(int a, int b, int c) 
// that returns the largest of three numbers
// without using Math.Max()
static int FindLargest(int a, int b, int c)
{
    if (a > b)
    {
        if (a > c)
        {
            return a;
        }
        else
        {
            return c;
        }
    }
    else
    {
        if (b > c) { return b; }
        else { return c; }
    }
}
int res = FindLargest(10, 30, 40);
Console.WriteLine(res);

// Exercise 4
// Write a method Reverse(string text) 
// that returns the string reversed
// Example: Reverse("Farah") returns "haraF"
static string Reverse(string input)
{
    char[] result = new char[input.Length];
    for (int i = 0; i < input.Length; i++)
    {
        result[i] = input[input.Length - 1 - i];
    }
    return new string(result);
}
Console.WriteLine(Reverse("Farah"));

// Exercise 5 (challenge)
// Write a method IsPalindrome(string text)
// that returns true if the word reads the same forwards and backwards
// Example: "madam" → true, "farah" → false
// Hint: use your Reverse method from Exercise 4
static bool IsPalindrome(string text)
{
    if(text.ToLower() == Reverse(text.ToLower()))
    {
        return true;
    }
    return false;
}
Console.WriteLine(IsPalindrome("madam"));