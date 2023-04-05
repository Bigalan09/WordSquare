using WordSquare.AI;
using WordSquare.ValueObject;

namespace WordSquare.Player.Internal;
internal class AIPlayer : Player, IAIPlayer
{
    private readonly IBrain _brain;

    public AIPlayer(string name, IBrain brain) : base(name)
    {
        _brain = brain;
    }

    public Coord GetCoords()
    {
        var (_, coord) = _brain.GetBestMove(Board);
        return coord;
    }

    public char GetLetter()
    {
        var (letter, _) = _brain.GetBestMove(Board);
        return letter;
    }
}
