using System;
using NUnit.Framework;

public class GameLogicTestSuite
{
    readonly PlayArea playArea = new();
    readonly TurnKeeper turnKeeper = new();

    [Test]
    [TestCase(3, 3)]
    [TestCase(-1, -1)]
    [TestCase(100, 100)]
    public void Mark_OutsidePlayArea_ExceptionThrown(int x, int y)
    {
        Player player = new Player(playArea, turnKeeper);

        Assert.Throws<ArgumentOutOfRangeException>(() => player.Play(x, y));
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    public void Mark_WithinPlayArea_ExceptionNotThrown(int x, int y)
    {
        Player player = new Player(playArea, turnKeeper);

        Assert.DoesNotThrow(() => player.Play(x, y));
    }

    [Test]
    public void Mark_OnAlreadyMarked_ExceptionThrown()
    {
        Player player = new Player(playArea, turnKeeper);

        player.Play(1, 1);

        Assert.Throws<InvalidOperationException>(() => player.Play(1, 1), "The position has already been marked.");
    }

    [Test]
    public void PlayerMarks_TurnChanges()
    {
        Player player = new Player(playArea, turnKeeper);
        bool isLastPlayedByPre = turnKeeper.IsLastPlayedBy(player.GetGuid());

        player.Play(1, 1);

        bool isLastPlayedByPost = turnKeeper.IsLastPlayedBy(player.GetGuid());
        Assert.IsFalse(isLastPlayedByPre == isLastPlayedByPost);
    }

    [Test]
    public void PlayerMarks_TwiceInARow_ThrowsException()
    {
        Player player = new Player(playArea, turnKeeper);

        player.Play(1, 0);

        Assert.Throws<InvalidOperationException>(() => player.Play(1, 2), "This player has already played.");
    }
}