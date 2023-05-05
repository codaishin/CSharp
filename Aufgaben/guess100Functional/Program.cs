IEnumerable<string> GetInputs() {
	string? input;
	while ((input = Console.ReadLine()) is not null) {
		yield return input;
	}
}

Func<string, string> AddTo(List<string> valueStorage) {
	return (string value) => {
		valueStorage.Add(value);
		return value;
	};
}

int? ParseToNumber(string value) {
	return int.TryParse(value, out var number)
		? number
		: null;
}

Func<int?, Result> ValueMatches(int targetNumber) {
	return (int? number) => {
		return number switch {
			null => Result.NotANumber,
			int guess when guess is < 0 or > 99 => Result.NotInRange,
			int guess when guess < targetNumber => Result.TooLow,
			int guess when guess > targetNumber => Result.TooHigh,
			_ => Result.Success,
		};
	};
}

bool NotWon(Result result) {
	return result is not Result.Success;
}

string ToString(Result result) {
	return result switch {
		Result.NotANumber => "use only one single number",
		Result.NotInRange => "Outside allowed range",
		Result.TooHigh => "Too high",
		Result.TooLow => "Too low",
		Result.Success => "you got it, champ",
		_ => "unknown result type",
	};
}

void Output(IEnumerable<string> results, List<string> answers) {
	Console.WriteLine($"Guess a number");
	foreach (var result in results) {
		Console.WriteLine(result);
	}
	Console.WriteLine($"You took {answers.Count} tries");
	Console.WriteLine($"You guessed:");
	foreach (var answer in answers) {
		Console.WriteLine($"\t{answer}");
	}
}

var randomNumberGenerator = new Random();
var log = new List<string>();
var results = GetInputs()
	.Select(AddTo(log))
	.Select(ParseToNumber)
	.Select(ValueMatches(randomNumberGenerator.Next(0, 100)))
	.TakeWhile(NotWon)
	.Append(Result.Success)
	.Select(ToString);

Output(results, log);

public enum Result {
	NotANumber,
	NotInRange,
	TooHigh,
	TooLow,
	Success,
}
