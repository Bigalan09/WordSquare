namespace WordSquare.Game;
public interface IGameFactory
{
    IWordSquare GetGame(Mode mode);
}
