var first = 1;
var second = 1;
var pattern = "{0} ";

Console.Write(pattern, first);
Console.Write(pattern, second);

for (var i = 2; i < 20; ++i) {
	var third = first + second;
	Console.Write(pattern, third);
	first = second;
	second = third;
}
Console.WriteLine();
