using WordSquare.Board;
using WordSquare.Players;

namespace WordSquare.Scoring;
public interface IScoreCalculator
{
    int CalculateScore(IPlayer player, IBoard board);
}
