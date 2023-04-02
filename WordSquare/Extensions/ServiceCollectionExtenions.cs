using WordSquare.AI;
using WordSquare.AI.Internal;
using WordSquare.Board;
using WordSquare.Board.Internal;
using WordSquare.Dictionary;
using WordSquare.Dictionary.Internal;
using WordSquare.Game;
using WordSquare.Game.Internal;
using WordSquare.Input;
using WordSquare.Input.Internal;
using WordSquare.Input.Validation;
using WordSquare.Input.Validation.Internal;
using WordSquare.Input.Validation.Rules;
using WordSquare.Player;
using WordSquare.Player.Internal;
using WordSquare.Scoring;
using WordSquare.Scoring.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterWordSquare(this IServiceCollection services)
    {
        services
            .AddScoped<IBrain, Brain>()
            .AddScoped<IBoardPrinter, BoardPrinter>()
            .AddScoped<IDawg, Dawg>()
            .AddScoped<IValidator<char>, Validator<char>>()
            .AddScoped<IValidator<int>, Validator<int>>()
            .AddScoped<IValidationRule<char>, LetterRule>()
            .AddScoped<IValidationRule<int>, RowColRule>()
            .AddScoped<IUserInput, ConsoleUserInput>()
            .AddScoped<IWordSquare, WordSquare.Game.Internal.WordSquare>()
            .AddScoped<IPlayerFactory, PlayerFactory>()
            .AddScoped<IScoreCalculator, ScoreCalculator>()
            .AddScoped<IAIPlayer, AIPlayer>()
            .AddScoped<IHumanPlayer, HumanPlayer>()
            .AddScoped<IGameFactory, GameFactory>();
        return services;
    }
}
