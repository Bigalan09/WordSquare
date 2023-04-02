using System.Text;

namespace WordSquare.Board.Internal;
internal class BoardPrinter : IBoardPrinter
{
    public string Print(IBoard board)
    {
        StringBuilder boardBuilder = new StringBuilder();
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                var cell = board.GetBoard()[row][col];
                boardBuilder.Append($" [{(cell != '\0' ? cell : " ")}] ");
            }
            boardBuilder.AppendLine();
        }

        return boardBuilder.ToString();
    }
}
