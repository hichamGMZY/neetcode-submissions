public class PrefixTree {

    private class TrieNode
    {
        public bool word;
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    }

    private TrieNode head = new();
    public PrefixTree() {
             
    }
    
    public void Insert(string word)
    {
        var current = head;
        foreach (var character in word)
        {
            if (!current.children.TryGetValue(character, out TrieNode next))
            {
                next = new TrieNode();
                current.children.Add(character, next);
            }

            current = next;
        }

        current.word = true;
    }
    
    public bool Search(string word)
    {
        var current = head;
        foreach (var character in word)
        {
            if (!current.children.TryGetValue(character, out TrieNode next))
            {
                return false;
            }

            current = next;
        }

        return current.word;
    }
    
    public bool StartsWith(string prefix) {
        var current = head;
        foreach (var character in prefix)
        {
            if (!current.children.TryGetValue(character, out TrieNode next))
            {
                return false;
            }

            current = next;
        }

        return true;
    }
}