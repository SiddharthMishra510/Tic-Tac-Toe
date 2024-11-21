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
        
        Assert.Throws<System.ArgumentOutOfRangeException>(() => player.Play(x, y));
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
    public void Mark_OnAlreadyMarked_Fails()
    {
        PlayArea playArea = new PlayArea();
        Player player = new Player(playArea);
        
        player.Play(1, 1);
        Assert.Throws<System.InvalidOperationException>(() => player.Play(1, 1), "The position has already been marked.");
    }
}
