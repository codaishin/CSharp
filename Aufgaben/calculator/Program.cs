Console.Write("Enter calculation: ");
var expression = Console.ReadLine()!;
var result = Tools.Calculate(expression);
Console.WriteLine($"Result: {result}");
