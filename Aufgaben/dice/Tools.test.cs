using Moq;
using NUnit.Framework;

[TestFixture]
public class TestParseDice {
	[Test]
	[Ignore("TODO")]
	public void Dice1d4() {
		var dice = Tools.ParseDice("1d4");
		Assert.That(dice, Is.EqualTo((1, 4)));
	}

	[Test]
	[Ignore("TODO")]
	public void Dice2d8() {
		var dice = Tools.ParseDice("2d8");
		Assert.That(dice, Is.EqualTo((2, 8)));
	}
}

[TestFixture]
public class TestRoll {
	private Tools.GetRandomFunc getRandom = (_, _) => 1u;

	[SetUp]
	public void SetUp() {
		this.getRandom = Mock.Of<Tools.GetRandomFunc>();

		Mock
			.Get(this.getRandom)
			.SetReturnsDefault<uint>(1);
	}

	[Test]
	[Ignore("TODO")]
	public void Dice1d4GetRandomArgs() {
		_ = Tools
			.Roll((1u, 4u), this.getRandom)
			.ToArray();

		Mock
			.Get(this.getRandom)
			.Verify(nextRandomNumber => nextRandomNumber(1u, 5u), Times.Once);
	}

	[Test]
	[Ignore("TODO")]
	public void Dice1d4UseResult() {
		_ = Mock
			.Get(this.getRandom)
			.Setup(nextRandomNumber => nextRandomNumber(It.IsAny<uint>(), It.IsAny<uint>()))
			.Returns(4u);

		var results = Tools
			.Roll((1u, 4u), this.getRandom)
			.ToArray();

		Assert.That(results, Is.EqualTo(new[] { 4u, }));
	}

	[Test]
	[Ignore("TODO")]
	public void Dice2d8GetRandomArgs() {
		_ = Tools
			.Roll((2u, 8u), this.getRandom)
			.ToArray(); ;

		Mock
			.Get(this.getRandom)
			.Verify(nextRandomNumber => nextRandomNumber(1u, 9u), Times.Exactly(2));
	}

	[Test]
	[Ignore("TODO")]
	public void Dice2d8UseResult() {
		_ = Mock
			.Get(this.getRandom)
			.SetupSequence(nextRandomNumber => nextRandomNumber(It.IsAny<uint>(), It.IsAny<uint>()))
			.Returns(3u)
			.Returns(2u);

		var results = Tools
			.Roll((2u, 8u), this.getRandom)
			.ToArray();

		Assert.That(results, Is.EqualTo(new[] { 3u, 2u, }));
	}
}

[TestFixture]
public class TestRollsToString {
	[Test]
	[Ignore("TODO")]
	public void OneRoll() {
		var rolls = new[] { new[] { 4u, } };
		var str = Tools.RollsToString(rolls);

		Assert.That(str, Is.EqualTo("[4]"));
	}

	[Test]
	[Ignore("TODO")]
	public void SeveralRolls() {
		var rolls = new[] { new[] { 8u, 6u, 12u, } };
		var str = Tools.RollsToString(rolls);

		Assert.That(str, Is.EqualTo("[8, 6, 12]"));
	}

	[Test]
	[Ignore("TODO")]
	public void SeveralRollsWithMultipleGroups() {
		var rolls = new[] {
			new[] { 8u, 6u, 12u },
			new[] { 2u, },
			new[] { 9u, 2u, 1u },
			new[] { 3u, 3u },
		};
		var str = Tools.RollsToString(rolls);

		Assert.That(str, Is.EqualTo("[8, 6, 12] [2] [9, 2, 1] [3, 3]"));
	}
}

[TestFixture]
public class TestSum {
	[Test]
	[Ignore("TODO")]
	public void OneRoll() {
		var rolls = new[] { new[] { 4u, } };
		var sum = Tools.Sum(rolls);

		Assert.That(sum, Is.EqualTo(4u));
	}

	[Test]
	[Ignore("TODO")]
	public void SeveralRolls() {
		var rolls = new[] { new[] { 8u, 6u, 12u, } };
		var sum = Tools.Sum(rolls);

		Assert.That(sum, Is.EqualTo(26u));
	}

	[Test]
	[Ignore("TODO")]
	public void SeveralRollsWithMultipleGroups() {
		var rolls = new[] {
			new[] { 8u, 6u, 12u },
			new[] { 2u, },
			new[] { 9u, 2u, 1u },
			new[] { 3u, 3u },
		};
		var sum = Tools.Sum(rolls);

		Assert.That(sum, Is.EqualTo(46u));
	}
}
