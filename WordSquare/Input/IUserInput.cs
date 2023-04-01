using WordSquare.ValueObject;

namespace WordSquare.Input;
public interface IUserInput
{
    Coord GetCoords();
    char GetLetter();
}
