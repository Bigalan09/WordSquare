namespace WordSquare.Player.Internal;
internal class PlayerFactory : IPlayerFactory
{
    public IPlayer GetPlayer(Kind kind, string name)
    {
        return kind switch
        {
            Kind.Human => new HumanPlayer(name),
            Kind.AI => new AIPlayer(name),
            _ => throw new ArgumentException("Invalid Kind!"),
        };
    }
}
