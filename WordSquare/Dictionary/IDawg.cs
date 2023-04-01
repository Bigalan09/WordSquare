namespace WordSquare.Dictionary;
public interface IDawg
{
    bool Contains(string word);
    List<string> Match(char[] pattern);
    IDawg FromJson(string json);
    List<string> GetWordsOfSize(int v);
}
