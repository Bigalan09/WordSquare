using WordSquare.ValueObject;

namespace WordSquare.Board.Internal;
internal class Board : IBoard
{
    private char[][] _board = new char[5][];

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
        return !_board.Cast<char>().Any(c => c != '\0');
    }

    public void PlaceLetter(char letter, Coord coord)
    {
        if (IsEmpty(coord))
            _board[coord.Row][coord.Column] = letter;
    }
}
