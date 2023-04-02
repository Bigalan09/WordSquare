using WordSquare.ValueObject;

namespace WordSquare.Player;
public interface IAIPlayer : IPlayer
{
    Coord GetCoords();
    char GetLetter();
}
