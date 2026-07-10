Console.Write("Enter a sentence: ");
string s = Console.ReadLine();
int count = 0;

Console.WriteLine($"UpperCase:{s.ToUpper()}");
Console.WriteLine($"Lowercase: {s.ToLower()}");
Console.WriteLine($"Length:{s.Length}");
Console.WriteLine($"Contains Pakistan: {s.Contains("pakistan")}");
Console.WriteLine($"Replace with lahore: {s.Replace("pakistan", "lahore")}");
Console.WriteLine($"Trim sentence: {s.Trim()}");

string[] words = s.Split(' ');
Console.Write($"No. of words {words.Length}");
Console.WriteLine($"First word: {words[0]}");

