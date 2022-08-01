class Program {
	static int[]? ToInts(string[] values) {
		var ints = new int[values.Length];
		for (var c = 0; c < values.Length; c++) {
			var success = int.TryParse(values[c], out int converted);
			if (!success || converted < 0) {
				return null;
			};
			ints[c] = converted;
		}
		return ints;
	}

	static string[] ToBars(int[] barSizes) {
		string[] bars = new string[barSizes.Length];
		for (var c = 0; c < barSizes.Length; c++) {
			bars[c] = new String('|', barSizes[c]);
		}
		return bars;
	}

	static void Print(string[] values) {
		foreach (var element in values) {
			Console.WriteLine(element);
		}
	}

	public static void Main() {
		Console.WriteLine("Write numbers to turn to bars");
		var input = Console.ReadLine()!;
		var numbers = input.Trim().Split(" ");

		var intNumbers = Program.ToInts(numbers);
		if (intNumbers is null) {
			Console.WriteLine("use like: 1 2 3 4");
			return;
		}
		var bars = Program.ToBars(intNumbers);
		Program.Print(bars);
	}
}
