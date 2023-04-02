namespace WordSquare.Dictionary.Internal;
internal class DawgNode
{
    public char Label { get; set; }
    public int Index { get; set; }
    public bool IsEndOfWord { get; set; }
    public Dictionary<char, DawgNode> Edges { get; set; } = new Dictionary<char, DawgNode>();
}
