// Write a program in C# Sharp which is a menu-driven program to perform simple calculations.

//Test Date and Expected Output
//Enter the first Integer :10
//Enter the second Integer :2

//Here are the options :
//1 - Addition.
//2 - Substraction.
//3 - Multiplication.
//4 - Division.
//5 - Exit.

//Input your choice :3
//The Multiplication of 10 and 2 is: 200

Console.WriteLine("\nExercise 1");
Console.Write("Enter the first Integer : ");
int num1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the second Integer : ");
int num2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nHere are the options :");
Console.WriteLine("1 - Addition.");
Console.WriteLine("2 - Substraction.");
Console.WriteLine("3 - Multiplication.");
Console.WriteLine("4 - Division.");
Console.WriteLine("5 - Exit.");

Console.Write("\nInput your choice : ");
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine($"The Addition of {num1} and {num2} is: {num1 + num2}");
        break;
    case 2:
        Console.WriteLine($"The Substraction of {num1} and {num2} is: {num1 - num2}");
        break;
    case 3:
        Console.WriteLine($"The Multiplication of {num1} and {num2} is: {num1 * num2}");
        break;
    case 4:
        if (num2 == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        else
        {
            double divisionResult = (double)num1 / num2;
            Console.WriteLine($"The Division of {num1} and {num2} is: {divisionResult}");
        }
        break;
    case 5:
        Console.WriteLine("Exiting the program.");
        break;
    default:
        Console.WriteLine("Invalid choice! Please select an option between 1 and 5.");
        break;
}
// Write a C# Sharp program that calculates the area of geometrical shapes using a menu-driven approach.

//Test Data :
//Input your choice : 1
//Input radius of the circle : 5

//Expected Output :
//The area is : 78.500000

Console.WriteLine("\nExercise 2");
Console.WriteLine("Input your choice :");
Console.WriteLine("1 - Circle");
Console.WriteLine("2 - Rectangle");
Console.WriteLine("3 - Triangle");
Console.WriteLine("4 - Exit");

Console.Write("\nInput your choice : ");
int choice1 = Convert.ToInt32(Console.ReadLine());

switch (choice1)
{
    case 1:
        Console.Write("Input radius of the circle : ");
        double radius = Convert.ToDouble(Console.ReadLine());

        double circleArea = Math.PI * radius * radius;

        Console.WriteLine($"The area is : {circleArea:F6}");
        break;

    case 2:
        Console.Write("Input length of the rectangle : ");
        double length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Input width of the rectangle : ");
        double width = Convert.ToDouble(Console.ReadLine());

        double rectangleArea = length * width;
        Console.WriteLine($"The area is : {rectangleArea:F6}");
        break;

    case 3:
        Console.Write("Input base of the triangle : ");
        double baseLength = Convert.ToDouble(Console.ReadLine());
        Console.Write("Input height of the triangle : ");
        double height = Convert.ToDouble(Console.ReadLine());

        double triangleArea = 0.5 * baseLength * height;
        Console.WriteLine($"The area is : {triangleArea:F6}");
        break;

    case 4:
        Console.WriteLine("Exiting the program.");
        break;

    default:
        Console.WriteLine("Invalid choice! Please select an option between 1 and 4.");
        break;
}

//Write a C# Sharp program to read 10 numbers and find their average and sum.
//Test Data :
//Input the 10 numbers :
//Number - 1 :2...
//Number - 10 :2
//Expected Output :
//The sum of 10 no is : 51
//The Average is : 5.100000

Console.WriteLine("\nExercise 3");
Console.WriteLine("You have to provide 10 no to sum and average");
int sum = 0;
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Enter number: ");
    int num = Convert.ToInt32(Console.ReadLine());
    sum += num;
}
Console.WriteLine($"Sum: {sum}  Average: {sum / 10}");


//Write a C# Sharp program to display the cube of an integer up to given number.
//Test Data :
//Input number of terms : 5
//Expected Output :
//Number is : 1 and cube of the 1 is :1
//Number is : 2 and cube of the 2 is :8
//Number is : 3 and cube of the 3 is :27
//Number is : 4 and cube of the 4 is :64
//Number is : 5 and cube of the 5 is :125

Console.WriteLine("\nExercise 4");
Console.WriteLine("Input the number of terms: ");
int cube = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= cube; i++)
{
    Console.WriteLine($"Number is : {i} and cube of the {i} is :{Math.Pow(i, 3)}");
}

//Write a C# Sharp program to display the n terms of odd natural numbers and their sums.
//Test Data
//Input number of terms : 10
//Expected Output :
//The odd numbers are :1 3 5 7 9 11 13 15 17 19
//The Sum of odd Natural Number upto 10 terms : 100

//Console.WriteLine("\nExercise 5");
Console.WriteLine("Input the number of terms: ");
int term = Convert.ToInt32(Console.ReadLine());
int sum2 = 0;
Console.WriteLine($"The odd numbers are :");
for (int i = 1; i <= 2 * term; i++)
{
    if (i % 2 != 0)
    {
        Console.WriteLine(i);
        sum2 += i;
    }

}
Console.WriteLine($"The Sum of odd Natural Number upto {term} terms :{sum}");

//Write a C# Sharp program to accept a coordinate point in an XY coordinate system and determine in which quadrant the coordinate point lies.
//Test Data :
//Input the value for X coordinate :7
//Input the value for Y coordinate :9
//Expected Output :
//The coordinate point (7,9) lies in the First quadrant.
Console.WriteLine("Exercise 6");
Console.WriteLine("Input the value for X coordinate :");
int a1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Input the value for Y coordinate :");
int b1 = Convert.ToInt32(Console.ReadLine());
if (a1 > 0 && b1 > 0)
{
    Console.WriteLine($"The coordinate point ({a1},{b1}) lies in the First quadrant.");
}
if (a1 < 0 && b1 > 0)
{
    Console.WriteLine($"The coordinate point ({a1},{b1}) lies in the Second quadrant.");
}
if (a1 < 0 && b1 < 0)
{
    Console.WriteLine($"The coordinate point ({a1},{b1}) lies in the Third quadrant.");
}
if (a1 > 0 && b1 < 0)
{
    Console.WriteLine($"The coordinate point ({a1},{b1}) lies in the Fourth quadrant.");
}

//Write a C# Sharp program to determine the eligibility for admission to a professional course based on the following criteria:
//Marks in Maths >=65
//Marks in Phy >=55
//Marks in Chem>=50
//Total in all three subject >=180
//or
//Total in Math and Subjects >=140 Scripting Languages

//Test Data :
//Input the marks obtained in Physics :65
//Input the marks obtained in Chemistry :51
//Input the marks obtained in Mathematics :72
//Expected Output :
//The candidate is eligible for admission.

Console.WriteLine("Exercise 7");
int physics, chemistry, maths;
Console.Write("Input the marks obtained in Physics : ");
physics = Convert.ToInt32(Console.ReadLine());

Console.Write("Input the marks obtained in Chemistry : ");
chemistry = Convert.ToInt32(Console.ReadLine());

Console.Write("Input the marks obtained in Mathematics : ");
maths = Convert.ToInt32(Console.ReadLine());

int totalThreeSubjects = maths + physics + chemistry;
int totalMathAndPhysics = maths + physics;

Console.WriteLine($"\nTotal marks of Maths, Physics and Chemistry : {totalThreeSubjects}");
Console.WriteLine($"Total marks of Maths and Physics : {totalMathAndPhysics}");

if (maths >= 65 && physics >= 55 && chemistry >= 50)
{
    if (totalThreeSubjects >= 180 || totalMathAndPhysics >= 140)
    {
        Console.WriteLine("The candidate is eligible for admission.\n");
    }
    else
    {
        Console.WriteLine("The candidate is not eligible for admission.\n");
    }
}
else
{
    Console.WriteLine("The candidate is not eligible for admission.\n");
}

//Write a C# Sharp program to calculate the root of a quadratic equation.
//Test Data :
//Input the value of a : 1
//Input the value of b : 5
//Input the value of c : 7
//Expected Output :
//Root are imaginary;
//No Solution.

Console.Write("\nExercise 8");
Console.Write("\nInput the value of a : ");
double a = Convert.ToDouble(Console.ReadLine());

Console.Write("Input the value of b : ");
double b = Convert.ToDouble(Console.ReadLine());

Console.Write("Input the value of c : ");
double c = Convert.ToDouble(Console.ReadLine());

double d = (b * b) - (4 * a * c);

if (d > 0)
{
    double r1 = (-b + Math.Sqrt(d)) / (2 * a);
    double r2 = (-b - Math.Sqrt(d)) / (2 * a);
    Console.WriteLine("The roots are real and distinct.");
    Console.WriteLine($"First Root = {r1}");
    Console.WriteLine($"Second Root = {r2}");
}
else if (d == 0)
{
    double r1 = -b / (2 * a);
    Console.WriteLine("The roots are real and equal.");
    Console.WriteLine($"Root = {r1}");
}
else
{
    Console.WriteLine("Root are imaginary;");
    Console.WriteLine("No Solution.");
}

//Write a C# Sharp program to check whether a triangle can be formed by the given angles value.
//Test Data :
//40 55 65
//Expected Output :
//The triangle is not valid.

Console.Write("\nExercise 9");
Console.Write("Input first angle: ");
int angle1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Input second angle: ");
int angle2 = Convert.ToInt32(Console.ReadLine());

Console.Write("Input third angle: ");
int angle3 = Convert.ToInt32(Console.ReadLine());

int sum1 = angle1 + angle2 + angle3;

if (sum1 == 180 && angle1 > 0 && angle2 > 0 && angle3 > 0)
{
    Console.WriteLine("The triangle is valid.");
}
else
{
    Console.WriteLine("The triangle is not valid.");
}

//Write a C# Sharp program to check whether an alphabet letter is a vowel or a consonant.
//Test Data :k
//Expected Output :
//The alphabet is a consonant.

Console.Write("\nExercise 10");
Console.Write("\nInput an alphabet letter: ");
char ch = Char.ToLower(Convert.ToChar(Console.ReadLine()));

if ((ch >= 'a' && ch <= 'z'))
{
    if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
    {
        Console.WriteLine("The alphabet is a vowel.");
    }
    else
    {
        Console.WriteLine("The alphabet is a consonant.");
    }
}
else
{
    Console.WriteLine("The input is not a valid alphabet letter.");
}
