using WordSquare.Board;
using WordSquare.ValueObject;

namespace WordSquare.AI;
public interface IBrain
{
    (char letter, Coord coord) GetBestMove(IBoard board);
}
