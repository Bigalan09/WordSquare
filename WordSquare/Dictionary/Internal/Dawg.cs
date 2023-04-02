using Newtonsoft.Json;
using System.Drawing;
using System.Text;

namespace WordSquare.Dictionary.Internal;
internal class Dawg : IDawg
{
    private DawgNode _root;
    private HashSet<string> _words = new HashSet<string>();

    public Dawg()
    {
        _root = new DawgNode();
    }

    public Dawg(List<string> words)
    {
        _root = new DawgNode();
        words.ForEach(AddWord);
    }

    public bool Contains(string word)
    {
        DawgNode current = _root;
        foreach (char c in word)
        {
            if (!current.Edges.ContainsKey(c))
            {
                return false;
            }
            current = current.Edges[c];
        }
        return current.IsEndOfWord;
    }

    public IDawg FromJson(string json)
    {
        DawgNode root = JsonConvert.DeserializeObject<DawgNode>(json)!;
        _root = root;
        return this;
    }

    public List<string> GetWordsOfSize(int size)
    {
        List<string> words = new List<string>();
        GetWordsOfSizeRecursively(_root, size, new StringBuilder(), words);
        return words;
    }

    public List<string> Match(char[] pattern)
    {
        List<string> result = new List<string>();
        MatchHelper(_root, "", pattern, 0, result);
        return result;
    }

    private void MatchHelper(DawgNode node, string prefix, char[] pattern, int index, List<string> result)
    {
        if (index == pattern.Length)
        {
            if (node.IsEndOfWord)
            {
                result.Add(prefix);
            }
            return;
        }

        if (char.ToUpper(pattern[index]) == '\0')
        {
            foreach (var edge in node.Edges)
            {
                MatchHelper(edge.Value, prefix + edge.Key, pattern, index + 1, result);
            }
        }
        else
        {
            if (node.Edges.ContainsKey(char.ToUpper(pattern[index])))
            {
                MatchHelper(node.Edges[char.ToUpper(pattern[index])], prefix + char.ToUpper(pattern[index]), pattern, index + 1, result);
            }
        }
    }

    private void GetWordsOfSizeRecursively(DawgNode node, int size, StringBuilder currentWord, List<string> words)
    {
        if (currentWord.Length == size)
        {
            if (node.IsEndOfWord)
            {
                words.Add(currentWord.ToString());
            }
            return;
        }

        foreach (var kvp in node.Edges)
        {
            char label = kvp.Key;
            DawgNode child = kvp.Value;
            currentWord.Append(label);
            GetWordsOfSizeRecursively(child, size, currentWord, words);
            currentWord.Length -= 1; // Remove the last character
        }
    }

    private void AddWord(string word)
    {
        if (_words.Contains(word))
        {
            return; // word already added
        }

        _words.Add(word);

        DawgNode current = _root;
        foreach (char c in word)
        {
            if (!current.Edges.ContainsKey(c))
            {
                current.Edges[c] = new DawgNode() { Label = c };
            }
            current = current.Edges[c];
        }
        current.IsEndOfWord = true;
    }
}
