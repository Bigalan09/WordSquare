using WordSquare.AI;

namespace WordSquare.Player.Internal;
internal class PlayerFactory : IPlayerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PlayerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public IPlayer GetPlayer(Kind kind, string name)
    {
        return kind switch
        {
            Kind.Human => new HumanPlayer(name),
            Kind.AI => new AIPlayer(name, (IBrain)_serviceProvider.GetService(typeof(IBrain))!),
            _ => throw new ArgumentException("Invalid Kind!"),
        };
    }
}
