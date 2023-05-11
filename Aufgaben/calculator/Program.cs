Console.WriteLine("Hello, World!");

var expression = "1+30-4*6" + "?";
var elements = new List<string>();


for (int i = 0, j = 0; i < expression.Length; i++) {
	if (expression[i] is '+' or '-' or '*') {
		elements.Add(expression[j..i]);
		elements.Add(expression[i].ToString());
		j = i + 1;
	}
	if (expression[i] is '?') {
		elements.Add(expression[j..i]);
	}
}

Console.WriteLine(string.Join(" | ", elements));
