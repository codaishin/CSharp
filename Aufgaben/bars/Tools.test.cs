using NUnit.Framework;

[TestFixture]
public class TestNumberToBars {
	[Test]
	[Ignore("TODO")]
	public void NoBars() {
		var bars = Tools.NumberToBars(0);

		Assert.That(bars, Is.EqualTo(""));
	}

	[Test]
	[Ignore("TODO")]
	public void FiveBars() {
		var bars = Tools.NumberToBars(5);

		Assert.That(bars, Is.EqualTo("|||||"));
	}

	[Test]
	[Ignore("TODO")]
	public void SevenBars() {
		var bars = Tools.NumberToBars(7);

		Assert.That(bars, Is.EqualTo("|||||||"));
	}
}
