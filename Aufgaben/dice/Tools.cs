public static class Tools {
	public static (uint count, uint sides) ParseDice(string value) {
		throw new NotImplementedException("Make me do stuff, please");
	}

	public delegate uint GetRandomFunc(uint min, uint maxExclusive);

	public static IEnumerable<uint> Roll((uint count, uint sides) dice, GetRandomFunc getRandom) {
		throw new NotImplementedException("Make me do stuff, please");
	}

	public static string RollsToString(IEnumerable<IEnumerable<uint>> rolls) {
		throw new NotImplementedException("Make me do stuff, please");
	}

	public static uint Sum(IEnumerable<IEnumerable<uint>> rolls) {
		throw new NotImplementedException("Make me do stuff, please");
	}
}
