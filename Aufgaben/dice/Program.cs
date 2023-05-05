static DiceGroup[]? ToDiceGroups(string[] groups) {
	DiceGroup AssertNotNull(DiceGroup? diceGroup) {
		return diceGroup ?? throw new NullReferenceException();
	}

	try {
		return groups
			.Select(ToDiceGroup)
			.Select(AssertNotNull)
			.ToArray();
	} catch (NullReferenceException) {
		return null;
	}
}

static DiceGroup? ToDiceGroup(string group) {
	var diceData = group.Split("d");
	return diceData.Length > 2 ||
		!int.TryParse(diceData[0], out var count) || count < 1 ||
		!int.TryParse(diceData[1], out var sides) || sides < 1
		? null
		: new DiceGroup { count = count, sides = sides };
}

static int[][] Roll(DiceGroup[] dice, Random random) {
	int[] getRolls(DiceGroup diceGroup) {
		IEnumerable<int> infiniteRolls() {
			while (true) {
				yield return random.Next(1, diceGroup.sides + 1);
			}
		}
		return infiniteRolls()
			.Take(diceGroup.count)
			.ToArray();
	}

	return dice
		.Select(getRolls)
		.ToArray();
}

static int Sum(int[][] rolls) {
	return rolls
		.SelectMany(g => g)
		.Sum();
}

static string ToString(int[][] rolls) {
	string groupResult(int[] group) {
		return $"[{string.Join(", ", group)}]";
	}

	return string.Join(" ", rolls.Select(groupResult));
}


Console.WriteLine("gimme some dice");

var random = new Random();
var input = Console.ReadLine()!;
var dice = ToDiceGroups(input.Split(" "));
if (dice is null) {
	Console.WriteLine("use input like: 2d4");
	return;
}
var results = Roll(dice, random);
var sum = Sum(results);
var resultStr = ToString(results);

Console.WriteLine(resultStr);
Console.WriteLine(sum);
