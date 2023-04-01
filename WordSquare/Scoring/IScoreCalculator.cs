using WordSquare.Board;
using WordSquare.Player;

namespace WordSquare.Scoring;
public interface IScoreCalculator
{
    int CalculateScore(IPlayer player, IBoard board);
}
