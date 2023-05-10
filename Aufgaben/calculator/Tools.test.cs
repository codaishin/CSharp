using System.Globalization;
using NUnit.Framework;

[TestFixture]
public class TestCalculate {
	[Test]
	public void Number() {
		var result = Tools.Calculate("42");

		Assert.That(result, Is.EqualTo(42f));
	}

	[Test]
	public void OtherNumber() {
		var result = Tools.Calculate("46");

		Assert.That(result, Is.EqualTo(46f));
	}

	[Test]
	public void Add() {
		var result = Tools.Calculate("4+2");

		Assert.That(result, Is.EqualTo(6f));
	}

	[Test]
	public void Subtract() {
		var result = Tools.Calculate("4-3");

		Assert.That(result, Is.EqualTo(1f));
	}

	[Test]
	public void Multiply() {
		var result = Tools.Calculate("4*3");

		Assert.That(result, Is.EqualTo(12f));
	}

	[Test]
	public void Divide() {
		var result = Tools.Calculate("4/3");

		Assert.That(result, Is.EqualTo(4f / 3f));
	}

	[Test]
	public void Multiple() {
		var result = Tools.Calculate("2*4-6");

		Assert.That(result, Is.EqualTo((2f * 4f) - 6f));
	}

	[Test]
	public void MultipleOrder() {
		var result = Tools.Calculate("2+4*6");

		Assert.That(result, Is.EqualTo(2f + (4f * 6f)));
	}

	[Test]
	public void DivisionOrder() {
		var result = Tools.Calculate("2+4/6");

		Assert.That(result, Is.EqualTo(2f + (4f / 6f)));
	}

	[Test]
	public void BracketsOrder() {
		var result = Tools.Calculate("2*(4+2)");

		Assert.That(result, Is.EqualTo(2f * (4f + 2f)));
	}

	[Test]
	public void OpAfterBrackets() {
		var result = Tools.Calculate("2*(4+2)+1");

		Assert.That(result, Is.EqualTo((2f * (4f + 2f)) + 1f));
	}

	[Test]
	public void NestedBrackets() {
		var result = Tools.Calculate("2*((4+2)*3)");

		Assert.That(result, Is.EqualTo(2f * ((4f + 2f) * 3)));
	}

	[Test]
	public void FirstPositiveAdd() {
		var result = Tools.Calculate("+2+3");

		Assert.That(result, Is.EqualTo(5f));
	}

	[Test]
	public void FirstPositiveMultiply() {
		var result = Tools.Calculate("+2*3");

		Assert.That(result, Is.EqualTo(6f));
	}

	[Test]
	public void Power() {
		var result = Tools.Calculate("2^3");

		Assert.That(result, Is.EqualTo(8f));
	}

	[Test]
	public void PowerOrder() {
		var result = Tools.Calculate("3+2^3");

		Assert.That(result, Is.EqualTo(3f + 8f));
	}

	[Test]
	public void Root() {
		var result = Tools.Calculate("2r4");

		Assert.That(result, Is.EqualTo(MathF.Pow(4, 1f / 2f)));
	}

	[Test]
	public void RootOrder() {
		var result = Tools.Calculate("3+2r4");

		Assert.That(result, Is.EqualTo(3f + MathF.Pow(4f, 1f / 2f)));
	}

	[Test]
	public void Complex() {
		var dot_or_comma = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
		var result = Tools.Calculate($"-2 + ((-15{dot_or_comma}4 + 6) * (1 + (-7))) + 10 ^ (2 * 3)");

		Assert.That(result, Is.EqualTo(-2f + ((-15.4f + 6f) * (1f + (-7f))) + MathF.Pow(10f, 2f * 3f)));
	}
}
