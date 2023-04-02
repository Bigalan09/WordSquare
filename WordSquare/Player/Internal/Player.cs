using WordSquare.Board;
using WordSquare.ValueObject;

namespace WordSquare.Player.Internal;
internal abstract class Player : IPlayer
{
    private int _currentAction = 0;

    public string Name { get; private init; }
    public IBoard Board { get; private init; }

    public Player(string name)
    {
        Name = name;
        Board = new Board.Internal.Board();
    }

    public void EndTurn()
    {
        _currentAction = 0;
    }

    public bool HasActions()
    {
        return _currentAction < 2;
    }

    public bool IsSecondAction()
    {
        return _currentAction == 1;
    }

    public char PlaceLetter(char letter, Coord coord)
    {
        if (Board.IsEmpty(coord))
        {
            Board.PlaceLetter(letter, coord);
            _currentAction++;
        }

        return letter;
    }

    public void SkipAction()
    {
        _currentAction++;
    }
}
