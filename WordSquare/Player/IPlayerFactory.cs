namespace WordSquare.Player;
public interface IPlayerFactory
{
    IPlayer GetPlayer(Kind kind, string name);
}
