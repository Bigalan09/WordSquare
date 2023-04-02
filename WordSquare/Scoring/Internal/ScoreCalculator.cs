using WordSquare.Board;
using WordSquare.Dictionary;
using WordSquare.Player;

namespace WordSquare.Scoring.Internal;
internal class ScoreCalculator : IScoreCalculator
{
    private readonly IDawg _dawg;

    public ScoreCalculator(IDawg dawg)
    {
        _dawg = dawg;
    }

    public int CalculateScore(IPlayer player, IBoard board)
    {
        return string.Join("", GetWordsInGrid(board.GetBoard())).Trim('\0').Length;
    }

    private List<string> GetWordsInGrid(char[][] grid)
    {
        List<string> foundWords = new List<string>();

        // Check rows
        for (int row = 0; row < 5; row++)
        {
            var rowWord = CheckWordsInRowOrColumn(new string(grid[row]));
            if (rowWord != string.Empty) foundWords.Add(rowWord);
        }

        // Check columns
        for (int col = 0; col < 5; col++)
        {
            char[] colChars = new char[5];
            for (int row = 0; row < 5; row++)
            {
                colChars[row] = grid[row][col];
            }
            var colWord = CheckWordsInRowOrColumn(new string(colChars));
            if (colWord != string.Empty) foundWords.Add(colWord);
        }

        return foundWords;
    }

    private string CheckWordsInRowOrColumn(string word)
    {
        // Check 5-letter word
        if (_dawg.Contains(word))
        {
            return word;
        }

        // Check 4-letter words
        for (int i = 0; i < 2; i++)
        {
            string fourLetterWord = word.Substring(i, 4);
            if (_dawg.Contains(fourLetterWord))
            {
                return fourLetterWord;
            }
        }

        // Check 3-letter words
        for (int i = 0; i < 3; i++)
        {
            string threeLetterWord = word.Substring(i, 3);
            if (_dawg.Contains(threeLetterWord))
            {
                return threeLetterWord;
            }
        }

        return string.Empty;
    }
}
