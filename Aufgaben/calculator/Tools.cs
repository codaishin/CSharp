using System.Text.RegularExpressions;

public static class Tools {
	private static readonly Dictionary<string, Func<float, float, float>> operations = new() {
		{"+", (a, b) => a + b},
		{"-", (a, b) => a - b},
		{"*", (a, b) => a * b},
		{"/", (a, b) => a / b},
		{"^", (a, b) => MathF.Pow(a, b)},
	};
	private static readonly string splitCharacters = @"()+\-*/\^";
	private static readonly string splitRegex = $"([{Tools.splitCharacters}])";


	private static bool ShouldForwardCalculate(string[] items) {
		return items.Length > 1 && items[1] is "*" or "/" or "^";
	}

	private static int IndexOfClosingBracket(string[] items, int start) {
		var openCounter = 0;
		var found = false;
		for (var index = start; index < items.Length; index++) {
			var item = items[index];
			if (item is "(") {
				++openCounter;
			}
			if (item is ")") {
				found = true;
				--openCounter;
			}
			if (found && openCounter < 0) {
				return index;
			}
		}
		return -1;
	}

	private static IEnumerable<string> PreComputeBrackets(this IEnumerable<string> itemsLazy) {
		var items = itemsLazy.ToArray();
		for (var index = 0; index < items.Length; ++index) {
			var item = items[index];
			if (item is "(") {
				var indexBracketClose = Tools.IndexOfClosingBracket(items, ++index);
				var expressionInBrackets = string.Join("", items[index..indexBracketClose]);
				var result = Tools.Calculate(expressionInBrackets);
				index = indexBracketClose;
				item = result.ToString();
			}
			yield return item;
		}
	}

	private static (float, string, int) ApplyOperation(float a, float b, string operationKey, string[] items) {
		var offset = 0;
		var apply = Tools.operations[operationKey];
		if (Tools.ShouldForwardCalculate(items)) {
			(offset, b) = Tools.Calculate(items[1..], b);
		}

		return (apply(a, b), operationKey, offset + 1);
	}

	private static (int, float) Calculate(string[] items, float result = 0f) {
		var operationKey = "+";
		var index = 0;

		while (index < items.Length) {
			(result, operationKey, var offset) = float.TryParse(items[index], out var number)
				? Tools.ApplyOperation(result, number, operationKey, items[index..])
				: (result, items[index], 1);
			index += offset;
		}

		return (index, result);
	}

	public static float Calculate(string expression) {
		var items = Regex
			.Split(expression, Tools.splitRegex)
			.Select(e => e.Trim())
			.Where(e => e.Length > 0)
			.PreComputeBrackets()
			.ToArray();
		var (_, result) = Tools.Calculate(items);

		return result;
	}
}
