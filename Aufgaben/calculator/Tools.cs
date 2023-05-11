public static class Tools {

	private static string[] GetParts(string expression) {
		var operations = new[] { '+', '-', '*', '/' };
		for (var i = 0; i < expression.Length; i++) {
			if (operations.Contains(expression[i])) {
				return new[] {
					expression[..i],
					expression[i].ToString(),
					expression[(i+1)..],
				};
			}
		}
		return new[] { expression };
	}

	private static float Op(float a, string operation, float b) {
		return operation switch {
			"+" => a + b,
			"-" => a - b,
			"*" => a * b,
			"/" => a / b,
			_ => throw new NotImplementedException(operation),
		};
	}

	public static float Calculate(string expression) {
		var parts = Tools.GetParts(expression);

		if (parts.Length is 3) {
			var num1 = float.Parse(parts[0]);
			var num2 = float.Parse(parts[2]);
			return Tools.Op(num1, parts[1], num2);
		}

		return float.Parse(parts[0]);
	}
}
