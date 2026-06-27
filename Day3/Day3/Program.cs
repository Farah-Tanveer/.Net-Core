Console.Write("Enter your marks (0-100): ");
int marks = int.Parse(Console.ReadLine());

if(marks >= 90)
{
    Console.WriteLine("A");
}
else if(marks >=80)
{
    Console.WriteLine("B");
}
else if (marks >= 70)
{
    Console.WriteLine("C");
}
else if (marks >= 60)
{
    Console.WriteLine("D");
}
else
{
    Console.WriteLine("F");
}
string msg = (marks >= 50) ? "Pass" : "Fail";
Console.WriteLine(msg);

//Switch Statement
string grade = marks switch
{
    >= 90 and <= 100 => "A",
    >= 80 and < 90 => "B",
    >= 70 and < 80 => "C",
    >= 60 and < 70 => "D",
    >= 0 and < 60 => "F",
    _ => "Invalid Score"
};
Console.WriteLine(grade);