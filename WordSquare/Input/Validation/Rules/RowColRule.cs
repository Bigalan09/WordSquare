namespace WordSquare.Input.Validation.Rules;
internal class RowColRule : IValidationRule<int>
{
    /// <inheritdoc/>
    public ValidationError Error => new ValidationError("001", "Number needs to be between 0 and 4.");

    /// <inheritdoc/>
    public bool Validate(int model) => model >= 0 && model <= 4;
}
