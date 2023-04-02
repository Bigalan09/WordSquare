using WordSquare.Board;
using WordSquare.ValueObject;

namespace WordSquare.Player;
public interface IPlayer
{
    IBoard Board { get; }
    string Name { get; }

    void EndTurn();
    bool HasActions();
    bool IsSecondAction();
    void SkipAction();
    char PlaceLetter(char letter, Coord coord);
}
