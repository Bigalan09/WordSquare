namespace WordSquare.Dictionary;
public interface IDawg
{
    bool Contains(string word);
    List<string> Match(char[] pattern);
    List<string> GetWordsOfSize(int size);
}
