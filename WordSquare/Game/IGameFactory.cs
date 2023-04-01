namespace WordSquare.Game;
public interface IGameFactory
{
    IWordSquare CreateGame(Mode mode);
}
