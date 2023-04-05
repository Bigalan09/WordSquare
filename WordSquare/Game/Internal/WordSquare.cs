using WordSquare.Board;
using WordSquare.Dictionary;
using WordSquare.Input;
using WordSquare.Player;
using WordSquare.Scoring;
using WordSquare.Scoring.Internal;
using WordSquare.ValueObject;

namespace WordSquare.Game.Internal;
internal class WordSquare : IWordSquare
{
    private IPlayer _player1 { get; set; } = default!;
    private IPlayer _player2 { get; set; } = default!;

    private readonly IUserInput _userInput;
    private readonly IScoreCalculator _scoreCalculator;
    private readonly IBoardPrinter _boardPrinter;
    private bool _firstMove = true;
    private IPlayer _currentPlayer = default!;

    private char _lastLetter = '\0';

    public WordSquare(
        IUserInput userInput,
        IScoreCalculator scoreCalculator,
        IBoardPrinter boardPrinter)
    {
        _userInput = userInput;
        _scoreCalculator = scoreCalculator;
        _boardPrinter = boardPrinter;
    }

    public void Begin()
    {
        if (_player1 == null || _player2 == null) return;

        do
        {
            Console.WriteLine($"It's {_currentPlayer.Name}'s Turn: ");
            Console.WriteLine($"{_currentPlayer.Name}'s Board: ");
            Console.WriteLine($"{_boardPrinter.Print(_currentPlayer.Board)}");

            if (_firstMove)
            {
                _currentPlayer.SkipAction();
                _firstMove = false;
            }

            do
            {
                char letter = _lastLetter;
                if (_currentPlayer.IsSecondAction())
                {
                    Console.WriteLine($"{_currentPlayer.Name}, choose a letter: ");
                    if (_currentPlayer is IAIPlayer)
                    {
                        letter = ((IAIPlayer)_currentPlayer).GetLetter();
                    }
                    else
                    {
                        letter = _userInput.GetLetter();
                    }
                }
                else
                {
                    Console.WriteLine($"{_currentPlayer.Name}, where do you want to place the letter '{letter}'?: ");
                }

                Coord coords;
                do
                {
                    if (_currentPlayer is IAIPlayer)
                    {
                        coords = ((IAIPlayer)_currentPlayer).GetCoords();
                    }
                    else
                    {
                        coords = _userInput.GetCoords();
                    }
                } while (!_currentPlayer.Board.IsEmpty(coords));

                _lastLetter = _currentPlayer.PlaceLetter(letter, coords);
            } while (_currentPlayer.HasActions());

            Console.WriteLine($"{_currentPlayer.Name}'s Board: ");
            Console.WriteLine($"{_boardPrinter.Print(_currentPlayer.Board)}");
            Console.WriteLine("----------");
            if (!(_player1 is IAIPlayer && _player2 is IAIPlayer))
            {
                Console.WriteLine("Press any key to end your turn!");
                Console.ReadKey();
                Console.Clear();
            }
            _currentPlayer.EndTurn();
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        } while (!HasGameEnded());
    }

    public (int, int) End()
    {
        int player1Score = _scoreCalculator.CalculateScore(_player1, _player1.Board);
        int player2Score = _scoreCalculator.CalculateScore(_player2, _player2.Board);

        return (player1Score, player2Score);
    }

    public bool HasGameEnded()
    {
        return _player1.Board.IsFull() && _player2.Board.IsFull();
    }

    public void Initialise(IPlayer player1, IPlayer player2)
    {

        _player1 = player1;
        _player2 = player2;

        _currentPlayer = _player1;
    }
}
