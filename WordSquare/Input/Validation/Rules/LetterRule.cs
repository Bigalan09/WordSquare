namespace WordSquare.Input.Validation.Rules;
internal class LetterRule : IValidationRule<char>
{
    /// <inheritdoc/>
    public ValidationError Error => new ValidationError("002", "Letter needs to be between A and Z.");

    /// <inheritdoc/>
    public bool Validate(char model) => (model >= 'a' && model <= 'z') || (model >= 'A' && model <= 'Z');
}
