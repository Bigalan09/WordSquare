using WordSquare.Player;

namespace WordSquare.Game;
public interface IWordSquare
{
    void Begin();
    void Initialise(IPlayer player1, IPlayer player2);
}
