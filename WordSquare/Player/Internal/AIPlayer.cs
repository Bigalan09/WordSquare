using WordSquare.ValueObject;

namespace WordSquare.Player.Internal;
internal class AIPlayer : Player, IAIPlayer
{
    public AIPlayer(string name) : base(name)
    {
    }

    public Coord GetCoords()
    {
        throw new NotImplementedException();
    }

    public char GetLetter()
    {
        throw new NotImplementedException();
    }
}
