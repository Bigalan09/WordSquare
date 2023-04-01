namespace WordSquare.ValueObjects;
public class Coord : ValueObject
{
    static Coord()
    {
    }

    private Coord()
    {
    }

    private Coord(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; private set; } = 0;
    public int Column { get; private set; } = 0;

    public static Coord From(int row, int column)
    {
        var colour = new Coord { Row = row, Column = column };
        return colour;
    }

    public static implicit operator string(Coord coord)
    {
        return coord.ToString();
    }

    public override string ToString()
    {
        return $"({Row}, {Column})";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
