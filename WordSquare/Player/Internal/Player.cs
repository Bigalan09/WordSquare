using WordSquare.ValueObject;

namespace WordSquare.Player.Internal;
internal abstract class Player : IPlayer
{
    public void EndTurn()
    {
        throw new NotImplementedException();
    }

    public void FirstAction(Coord coord)
    {
        throw new NotImplementedException();
    }

    public bool HasActions()
    {
        throw new NotImplementedException();
    }

    public bool IsSecondAction()
    {
        throw new NotImplementedException();
    }

    public char SecondAction(char letter, Coord coord)
    {
        throw new NotImplementedException();
    }

    public void SkipAction()
    {
        throw new NotImplementedException();
    }
}
