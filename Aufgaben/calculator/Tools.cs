using System.Text.RegularExpressions;

public static class Tools {
	private static readonly string[] priorityOps = { "*", "/", "^", "r" };
	private static float Op(float a, string op, float b) {
		return op switch {
			"+" => a + b,
			"-" => a - b,
			"*" => a * b,
			"/" => a / b,
			"^" => MathF.Pow(a, b),
			"r" => MathF.Pow(b, 1f / a),
			_ => throw new NotImplementedException($"Operation '{op}' not implemented"),
		};
	}

	private static int IndexOfClosingBracket(string[] items, int start) {
		var opens = 0;
		var found = false;
		for (var i = start; i < items.Length; i++) {
			var item = items[i];
			if (item is "(") {
				++opens;
			}
			if (item is ")") {
				found = true;
				--opens;
			}
			if (found && opens < 0) {
				return i;
			}
		}
		return -1;
	}

	private static (float number, string[] remaining) PreComputeBrackets(string[] items) {
		var closeIndex = Tools.IndexOfClosingBracket(items, 2);
		return (
			Tools.Calculate(items[2..closeIndex]),
			items[(closeIndex + 1)..]
		);
	}

	private static (string op, float number, string[] remaining) Next(string prepend, string[] items) {
		var prepended = new string[items.Length + 1];
		prepended[0] = prepend;
		for (var i = 0; i < items.Length; i++) {
			prepended[i + 1] = items[i];
		}
		return Tools.Next(prepended);
	}

	private static (string op, float number, string[] remaining) Next(string[] items) {
		if (items[0] is "(" || float.TryParse(items[0], out _)) {
			return Tools.Next("+", items);
		}

		var op = items[0];
		var (number, remainder) = items[1] is "("
				? Tools.PreComputeBrackets(items)
				: (float.Parse(items[1]), items[2..]);

		if (remainder.Length > 0 && Tools.priorityOps.Contains(remainder[0])) {
			(var nextOp, var nextNumber, remainder) = Tools.Next(remainder);
			number = Tools.Op(number, nextOp, nextNumber);
		}

		return (op, number, remainder);
	}

	private static IEnumerable<(string, float)> PreCompute(string[] items) {
		while (items.Length > 0) {
			(var op, var number, items) = Tools.Next(items);
			yield return (op, number);
		}
	}

	private static float Calculate(string[] items) {
		var result = 0f;
		foreach (var (op, number) in Tools.PreCompute(items)) {
			result = Tools.Op(result, op, number);
		}
		return result;
	}


	public static float Calculate(string expression) {
		var items = Regex
			.Split(expression, @"([r()+\-*/\^])")
			.Where(item => !string.IsNullOrWhiteSpace(item))
			.ToArray();
		return Tools.Calculate(items);
	}
}
