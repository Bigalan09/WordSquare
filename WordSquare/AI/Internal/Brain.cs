using WordSquare.Board;
using WordSquare.Dictionary;
using WordSquare.ValueObject;

namespace WordSquare.AI.Internal;
internal class Brain : IBrain
{
    private readonly IDawg _dawg;
    private IBoard _board = default!;

    public Brain(IDawg dawg)
    {
        _dawg = dawg;
    }

    public (char letter, Coord coord) GetBestMove(IBoard board)
    {
        _board = board;

        string selectedWord = SelectWord();
        Coord bestCoord = FindBestPlacement(selectedWord);
        char letterToPlace = GetLetterToPlace(selectedWord);

        return (letterToPlace, bestCoord);
    }

    private string SelectWord()
    {
        List<string> candidateWords = _dawg.GetWordsOfSize(5).ToList();
        candidateWords.AddRange(_dawg.GetWordsOfSize(4));
        candidateWords.AddRange(_dawg.GetWordsOfSize(3));

        int maxScore = -1;
        string selectedWord = "";

        foreach (string word in candidateWords)
        {
            int wordScore = ScoreWordSelection(word);
            if (wordScore > maxScore)
            {
                maxScore = wordScore;
                selectedWord = word;
            }
        }

        return selectedWord;
    }

    private int ScoreWordSelection(string word)
    {
        int score = 0;
        char[][] grid = _board.GetBoard();

        foreach (char letter in word)
        {
            if (grid.Any(row => row.Contains(letter)))
            {
                score++;
            }
        }

        return score;
    }

    private Coord FindBestPlacement(string word)
    {
        int maxScore = -1;
        Coord bestCoord = Coord.From(0, 0);

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                int horizontalScore = ScorePlacement(word, Coord.From(row, col), true);
                if (horizontalScore > maxScore)
                {
                    maxScore = horizontalScore;
                    bestCoord = Coord.From(row, col);
                }

                int verticalScore = ScorePlacement(word, Coord.From(row, col), false);
                if (verticalScore > maxScore)
                {
                    maxScore = verticalScore;
                    bestCoord = Coord.From(row, col);
                }
            }
        }

        return Coord.From(bestCoord.Row, bestCoord.Column);
    }

    private int ScorePlacement(string word, Coord coord, bool isHorizontal)
    {
        int score = 0;
        char[][] grid = _board.GetBoard();

        for (int i = 0; i < word.Length; i++)
        {
            int row = coord.Row + (isHorizontal ? 0 : i);
            int col = coord.Column + (isHorizontal ? i : 0);

            if (row < 5 && col < 5)
            {
                char currentLetter = grid[row][col];
                char wordLetter = word[i];

                if (currentLetter == '\0' || currentLetter == wordLetter)
                {
                    score++;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        return score;
    }

    private char GetLetterToPlace(string word)
    {
        char[][] grid = _board.GetBoard();
        foreach (char letter in word)
        {
            bool letterExists = grid.Any(row => row.Contains(letter));
            if (!letterExists)
            {
                return letter;
            }
        }

        return '\0';
    }
}
