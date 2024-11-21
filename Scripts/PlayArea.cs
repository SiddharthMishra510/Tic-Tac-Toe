using System;

public class PlayArea
{
    public void Mark(int x, int y)
    {
        if (x > 2 || y > 2 || x < 0 || y < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
