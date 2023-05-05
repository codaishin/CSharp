var randoms = new Random();
var random = randoms.Next(0, 100);
var answers = new List<string>();

Console.WriteLine("Guess a number between 0 and 100");

bool won;
do {
	var input = Console.ReadLine()!;
	answers.Add(input);
	var couldParse = int.TryParse(input, out var guess);
	(won, var msg) = couldParse switch {
		false => (false, "Not a number"),
		true when guess is < 0 or > 99 => (false, "Outside of allowed range"),
		true when guess < random => (false, "Too low... LOL"),
		true when guess > random => (false, "Too high... rofl"),
		_ => (true, "Correct, yeah"),
	};
	Console.WriteLine(msg);
} while (won is false);

Console.WriteLine($"Your tries: {answers.Count}");
Console.Write($"Your guesses where: ");
foreach (var answer in answers) {
	Console.Write($"{answer} ");
}
Console.WriteLine();
