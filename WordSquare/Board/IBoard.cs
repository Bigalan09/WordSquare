using WordSquare.ValueObject;

namespace WordSquare.Board;
public interface IBoard
{
    void PlaceLetter(char letter, Coord coord);
    bool IsEmpty(Coord coord);
    bool IsFull();
    char[][] GetBoard();
}
