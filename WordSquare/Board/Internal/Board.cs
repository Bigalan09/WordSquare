using WordSquare.ValueObject;

namespace WordSquare.Board.Internal;
internal class Board : IBoard
{
    private char[][] _board = new char[5][];

    public Board()
    {
        InitialiseGrid();
    }

    public char[][] GetBoard()
    {
        return _board;
    }

    public bool IsEmpty(Coord coord)
    {
        return _board[coord.Row][coord.Column] == '\0';
    }

    public bool IsFull()
    {
        return _board.SelectMany(row => row).All(c => c != '\0');
    }

    public void PlaceLetter(char letter, Coord coord)
    {
        if (IsEmpty(coord))
            _board[coord.Row][coord.Column] = letter;
    }

    private void InitialiseGrid()
    {
        for (int i = 0; i < 5; i++)
        {
            _board[i] = new char[5];
            for (int j = 0; j < 5; j++)
            {
                _board[i][j] = '\0';
            }
        }
    }
}
