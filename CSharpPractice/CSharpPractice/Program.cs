string name = "Ali";
int age = 18;
double gpa = 3.4;
bool isStudent = true;

Console.Write($"Name: {name}\n");
Console.Write($"Age: {age}\n");
Console.Write($"GPA: {gpa} \n");
Console.Write($"isStudent: {isStudent} \n");

Console.Write("Enter your name: ");
string n = Console.ReadLine();
Console.Write($"Hello {n} , Welcome to C#!\n");

Console.Write("\nEnter your name: ");
string N = Console.ReadLine();
Console.Write("Enter your age: ");
int a = int.Parse(Console.ReadLine());
Console.Write($"Hello {N}, You are {a} years old");