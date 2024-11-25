using System;

public class Player
{
    private readonly PlayArea playArea;
    private readonly Guid guid;
    private readonly TurnKeeper turnKeeper;

    public Player(PlayArea playArea, TurnKeeper turnKeeper)
    {
        guid = Guid.NewGuid();
        this.playArea = playArea;
        this.turnKeeper = turnKeeper;
    }

    public void Play(int x, int y)
    {
        if (turnKeeper.IsLastPlayedBy(guid))
        {
            throw new InvalidOperationException("This player has already played.");
        }

        playArea.Mark(x, y);
        turnKeeper.RegisterTurn(guid);
    }

    public Guid GetGuid()
    {
        return guid;
    }
}