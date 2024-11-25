using System;

public class TurnKeeper
{
    private Guid lastPlayerGuid;

    public bool IsLastPlayedBy(Guid playerGuid)
    {
        return playerGuid == lastPlayerGuid;
    }

    public void RegisterTurn(Guid playerGuid)
    {
        lastPlayerGuid = playerGuid;
    }
}