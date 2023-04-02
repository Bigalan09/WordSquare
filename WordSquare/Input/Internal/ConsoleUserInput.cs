using WordSquare.Input.Validation.Rules;
using WordSquare.Input.Validation;
using WordSquare.ValueObject;

namespace WordSquare.Input.Internal;
internal class ConsoleUserInput : IUserInput
{
    private readonly IValidator<int> _numberValidator;
    private readonly IValidator<char> _letterValidator;

    public ConsoleUserInput(
        IValidator<int> numberValidator,
        IValidator<char> letterValidator)
    {
        _numberValidator = numberValidator;
        _letterValidator = letterValidator;

        _numberValidator.AddRule(typeof(RowColRule));
        _letterValidator.AddRule(typeof(LetterRule));
    }

    public Coord GetCoords()
    {

        int row;
        string? input;
        do
        {
            do
            {
                Console.WriteLine("Select a row (0-4): ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out row));
        } while (!_numberValidator.Validate(row).IsValid);

        int column;
        do
        {
            do
            {
                Console.WriteLine("Select a column (0-4): ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out column));
        } while (!_numberValidator.Validate(column).IsValid);

        return Coord.From(row, column);
    }

    public char GetLetter()
    {
        char letter;
        string? input;
        do
        {
            do
            {
                Console.WriteLine("Pick a letter (a-z): ");
                input = Console.ReadLine();
            } while (!char.TryParse(input, out letter));
        } while (!_letterValidator.Validate(letter).IsValid);

        return char.ToUpper(letter);
    }
}