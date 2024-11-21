public class Player
{
    private readonly PlayArea playArea;
    
    public Player(PlayArea playArea)
    {
        this.playArea = playArea;
    }

    public void Play(int x, int y)
    {
        playArea.Mark(x, y);
    }
}
