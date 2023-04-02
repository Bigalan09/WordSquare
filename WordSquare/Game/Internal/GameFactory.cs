using WordSquare.Board;
using WordSquare.Dictionary;
using WordSquare.Input;
using WordSquare.Player;
using WordSquare.Scoring;

namespace WordSquare.Game.Internal;
internal class GameFactory : IGameFactory
{
    private readonly IPlayerFactory _playerFactory;
    private readonly IDawg _dawg;
    private readonly IUserInput _userInput;
    private readonly IScoreCalculator _scoreCalculator;
    private readonly IBoardPrinter _boardPrinter;

    public GameFactory(
        IPlayerFactory playerFactory,
        IDawg dawg,
        IUserInput userInput,
        IScoreCalculator scoreCalculator,
        IBoardPrinter boardPrinter)
    {
        _playerFactory = playerFactory;
        _dawg = dawg;
        _userInput = userInput;
        _scoreCalculator = scoreCalculator;
        _boardPrinter = boardPrinter;
    }

    public IWordSquare CreateGame(Mode mode)
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

        return new WordSquare(_dawg, _userInput, _scoreCalculator, _boardPrinter, player1, player2);
    }
}
