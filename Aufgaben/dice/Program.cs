Console.WriteLine("what dice should I roll?");

var random = new Random();
var rolledGroups = Console
	.ReadLine()!
	.Split(" ")
	.Select(Tools.ParseDice)
	.Select(RollDice)
	.ToArray();
var rollResults = Tools.RollsToString(rolledGroups);
var sum = Tools.Sum(rolledGroups);

Console.WriteLine($"dice: {rollResults}");
Console.WriteLine($"sum: {sum}");

uint[] RollDice((uint, uint) dice) {
	uint NextRandom(uint min, uint maxExclusive) {
		return (uint)random.Next((int)min, (int)maxExclusive);
	}
	return Tools.Roll(dice, NextRandom).ToArray();
}
