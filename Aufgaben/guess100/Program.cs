var randoms = new Random();
var random = randoms.Next(0, 100);
var won = false;
var answers = new List<string>();
var input = "";
var couldParse = false;

Console.WriteLine("Guess a number between 0 and 100");

do {
	input = Console.ReadLine()!;  // ! assumes that input is not null
	answers.Add(input);
	couldParse = int.TryParse(input, out int guess);

	if (couldParse is false) {
		Console.WriteLine("Not a number");
	} else if (guess < 0 || guess > 99) {
		Console.WriteLine("Outside of allowed range");
	} else if (guess == random) {
		Console.WriteLine("Correct, yeah");
		won = true;
	} else if (guess < random) {
		Console.WriteLine("Too low... LOL");
	} else if (guess > random) {
		Console.WriteLine("Too high... rofl");
	}

	/* alternative with switch statement
		switch (couldParse) {
			case false:
				Console.WriteLine("Not a number");
				break;
			case true when guess < 0 || guess > 99:
				Console.WriteLine("Outside of allowed range");
				break;
			case true when guess < random:
				Console.WriteLine("Too low... LOL");
				break;
			case true when guess > random:
				Console.WriteLine("Too high... rofl");
				break;
			default:
				Console.WriteLine("Correct, yeah");
				won = true;
				break;
		}
	*/

	/* alternative with switch expression:
		var msg = "";
		(won, msg) = couldParse switch {
			false => (false, "Not a number"),
			true when guess < 0 || guess > 99 => (false, "Outside of allowed range"),
			true when guess < random => (false, "Too low... LOL"),
		 	true when guess > random => (false, "Too high... rofl"),
			_ => (true, "Correct, yeah"),
		};
		Console.WriteLine(msg);
	*/

} while (won is false);

Console.WriteLine($"Your tries: {answers.Count}");
Console.Write($"Your guesses where: ");
foreach (var answer in answers) {
	Console.Write($"{answer} ");
}
Console.WriteLine();
