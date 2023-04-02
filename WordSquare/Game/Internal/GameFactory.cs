using Microsoft.Extensions.DependencyInjection;
using WordSquare.Board;
using WordSquare.Dictionary;
using WordSquare.Input;
using WordSquare.Player;
using WordSquare.Scoring;

namespace WordSquare.Game.Internal;
internal class GameFactory : IGameFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IPlayerFactory _playerFactory;

    public GameFactory(
        IServiceProvider serviceProvider,
        IPlayerFactory playerFactory)
    {
        _serviceProvider = serviceProvider;
        _playerFactory = playerFactory;
    }

    public IWordSquare GetGame(Mode mode)
    {
        IPlayer player1;
        IPlayer player2;
        switch (mode)
        {
            case Mode.HumanVsHuman:
                player1 = _playerFactory.GetPlayer(Kind.Human, "Player 1");
                player2 = _playerFactory.GetPlayer(Kind.Human, "Player 2");
                break;
            case Mode.HumanVsComputer:
                player1 = _playerFactory.GetPlayer(Kind.Human, "Player 1");
                player2 = _playerFactory.GetPlayer(Kind.AI, "Player 2");
                break;
            case Mode.ComputerVsComputer:
                player1 = _playerFactory.GetPlayer(Kind.AI, "Player 1");
                player2 = _playerFactory.GetPlayer(Kind.AI, "Player 2");
                break;
            default:
                throw new NotImplementedException();
        }

        var game =  _serviceProvider.GetRequiredService<IWordSquare>();
        game.Initialise(player1, player2);
        return game;
    }
}
