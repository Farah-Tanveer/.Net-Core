//Arrays have fixed size, same type
int[] marks = { 90, 85, 78, 92, 60 };
Console.WriteLine(marks[0]);
Console.WriteLine(marks.Length);

// Loop through array
for (int i = 0; i < marks.Length; i++)
{
    Console.WriteLine(marks[i]);
}

//forEach
foreach (int i in marks)
{
    Console.WriteLine(i);
}

//LISTS - dynamic size , more flexible
List<string> students = new List<string>();
students.Add("Farah");
students.Add("Zarah");
students.Add("Zobia");
students.Remove("Zobia");

Console.WriteLine(students.Count);
Console.WriteLine(students[0]);
Console.WriteLine(students.Contains("Zarah"));

//Loop through list
foreach (string name in students)
{
    Console.WriteLine(name);
}
// Exercise 1
// Create an array of 5 subject names
// Print each one using a for loop
String[] subjects = { "Math", "Urdu", "English", "Physics" ,"Statistics"};
foreach (string subject in subjects)
{
    Console.WriteLine(subject);
}

// Exercise 2
// Create a list of integers
// Add numbers 1 to 10 using a loop
// Print only the ones greater than 5

List<int> ints = new List<int>();
for (int i = 1; i <= 10; i++)
{
    ints.Add(i);
    if (i > 5)
    {
        Console.WriteLine(i);
    }
}

// Exercise 3
// Create a list of student names
// Ask the user to enter 5 names one by one
// Store them in the list
// Then print all names and the total count

List<string> names = new List<string>();
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine("Enter a name: ");
    string name = Console.ReadLine();
    names.Add(name);
}
foreach (string name in names)
{
    Console.WriteLine(name);
}
Console.WriteLine("Total count is " + names.Count);

// Exercise 4 (challenge)
// Create an array of 5 exam scores
// Calculate and print the highest, lowest, and average score
// Hint: look up Math.Max(), Math.Min(), and keep a running total for average
int[] marks1 = { 90, 85, 78, 65, 88 };
int avg = 0;
int max = marks1[0];
int min = marks1[0];
for (int i = 0; i < marks1.Length; i++)
{
    max = Math.Max(max, marks1[i]);
    min = Math.Min(min, marks1[i]);

    avg += marks1[i];
}
Console.WriteLine("Maximum: " + max);
Console.WriteLine("Minimum: " + min);
Console.WriteLine("Average: " + (double)avg / marks1.Length);

