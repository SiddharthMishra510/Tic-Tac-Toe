using NUnit.Framework;

public class GameLogicTestSuite
{
    [Test]
    public void Mark_OutsidePlayArea_ExceptionThrown()
    {
        PlayArea playArea = new PlayArea();
        Player player = new Player(playArea);
        
        Assert.Throws<System.ArgumentOutOfRangeException>(() => player.Play(3, 3));
    }
    
    [Test]
    public void Mark_WithinPlayArea_ExceptionNotThrown()
    {
        PlayArea playArea = new PlayArea();
        Player player = new Player(playArea);
        
        Assert.DoesNotThrow(() => player.Play(0, 0));
    }
}
