using System;

public class PlayArea
{
    private const int NoOfRows = 3;
    private const int NoOfCols = 3;
    
    private readonly CellState[,] board = new CellState[NoOfRows, NoOfCols];
    
    public PlayArea()
    {
        for (int i = 0; i < NoOfRows; i++)
        {
            for (int j = 0; j < NoOfCols; j++)
            {
                board[i, j] = CellState.Unmarked;
            }
        }
    }
    
    public void Mark(int x, int y)
    {
        if (IsOutsideBounds(x, y))
        {
            throw new ArgumentOutOfRangeException();
        }

        if (IsMarked(x, y))
        {
            throw new InvalidOperationException();
        }

        board[x, y] = CellState.Cross;
    }

    private bool IsOutsideBounds(int x, int y)
    {
        return x > NoOfRows - 1 || y > NoOfCols - 1 || x < 0 || y < 0;
    }
    
    private bool IsMarked(int x, int y)
    {
        return board[x, y] != CellState.Unmarked;
    }
}
