using System;

public class Player
{
    private readonly PlayArea playArea;
    private Guid guid;
    private TurnKeeper turnKeeper;

    public Player(PlayArea playArea, TurnKeeper turnKeeper)
    {
        guid = Guid.NewGuid();
        this.playArea = playArea;
        this.turnKeeper = turnKeeper;
    }

    public void Play(int x, int y)
    {
        playArea.Mark(x, y);
        turnKeeper.RegisterTurn(guid);
    }

    public Guid GetGuid()
    {
        return guid;
    }
}