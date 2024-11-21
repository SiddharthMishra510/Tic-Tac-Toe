using System;
using NUnit.Framework;

public class GameLogicTestSuite
{
    [Test]
    [TestCase(3, 3)] 
    [TestCase(-1, -1)]
    [TestCase(100, 100)]
    public void Mark_OutsidePlayArea_ExceptionThrown(int x, int y)
    {
        PlayArea playArea = new PlayArea();
        Player player = new Player(playArea);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => player.Play(x, y));
    }
    
    [Test]
    [TestCase(0, 0)] 
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    public void Mark_WithinPlayArea_ExceptionNotThrown(int x, int y)
    {
        PlayArea playArea = new PlayArea();
        Player player = new Player(playArea);
        
        Assert.DoesNotThrow(() => player.Play(x, y));
    }
    
    [Test]
    public void Mark_OnAlreadyMarked_ExceptionThrown()
    {
        PlayArea playArea = new PlayArea();
        Player player = new Player(playArea);
        
        player.Play(1, 1);
        Assert.Throws<InvalidOperationException>(() => player.Play(1, 1), "The position has already been marked.");
    }

    [Test]
    public void PlayerMarks_TwoTimesInARow_ExceptionThrown()
    {
        PlayArea playArea = new PlayArea();
        Player player1 = new Player(playArea);
        
        player1.Play(1, 1);
        Assert.Throws<InvalidOperationException>(() => player1.Play(1, 2), "The position has already played last.");
    }
}
