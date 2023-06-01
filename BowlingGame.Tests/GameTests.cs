using BowlingGame.Domain;

namespace BowlingGame.Tests;

public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_Return_Correct_Score_After_First_Roll()
    {
        var game = new Game();
        game.Roll(1);

        Assert.AreEqual(1, game.Score());
    }

    [Test]
    public void Should_Return_Correct_Score_After_Second_Roll()
    {
        var game = new Game();
        game.Roll(1);
        game.Roll(6);

        Assert.AreEqual(7, game.Score());
    }

    [Test]
    public void Should_Apply_Bonus_After_A_Spare()
    {
        var game = new Game();
        game.Roll(8);
        game.Roll(2);
        game.Roll(5);

        Assert.AreEqual(20, game.Score());
    }

        [Test]
    public void Should_Apply_Bonus_After_A_Strike()
    {
        var game = new Game();
        game.Roll(10);
        game.Roll(5);
        game.Roll(5);

        Assert.AreEqual(30, game.Score());
    }
}