using System;

public class PlayArea
{
    private CellState[,] board = new CellState[3, 3];

    public PlayArea()
    { 
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = CellState.Unmarked;
            }
        }
    }
    public void Mark(int x, int y)
    {
        if (x > 2 || y > 2 || x < 0 || y < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (board[x, y] != CellState.Unmarked)
        {
            throw new InvalidOperationException();
        }

        board[x, y] = CellState.Cross;
    }
}
