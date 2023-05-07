Console.WriteLine("Write numbers to turn to bars:");
var numbers = Console
	.ReadLine()!
	.Split(" ")
	.Select(number => uint.Parse(number));
foreach (var number in numbers) {
	Console.WriteLine(Tools.NumberToBars(number));
}
