public static class Tools {
	public static (uint count, uint sides) ParseDice(string value) {
		var split = value.Split("d").Select(e => uint.Parse(e)).ToArray();
		var count = split[0];
		var sides = split[1];
		return (count, sides);
	}

	public delegate uint GetRandomFunc(uint min, uint maxExclusive);

	public static IEnumerable<uint> Roll((uint count, uint sides) dice, GetRandomFunc getRandom) {
		for (var c = 0; c < dice.count; ++c) {
			yield return getRandom(1, dice.sides + 1);
		}
	}

	public static string RollsToString(IEnumerable<IEnumerable<uint>> rolls) {
		static string JoinRollGroup(IEnumerable<uint> group) {
			return $"[{string.Join(", ", group)}]";
		}

		return string.Join(" ", rolls.Select(JoinRollGroup));
	}

	public static uint Sum(IEnumerable<IEnumerable<uint>> rolls) {
		return rolls
			.SelectMany(grp => grp)
			.Aggregate(0u, (sum, roll) => sum + roll);
	}
}
