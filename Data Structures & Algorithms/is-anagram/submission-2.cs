
public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        
        var nbChar = new Dictionary<char, int>();
        foreach (var character in s)
        {
            if (!nbChar.ContainsKey(character))
            {
                nbChar[character] = 0;
            }
            else
            {
                nbChar[character]++;
            }
        }
        
        var nbChart = new Dictionary<char, int>();
        foreach (var character in t)
        {
            if (!nbChar.TryGetValue(character, out var nbS))
                return false;
            
            if (!nbChart.TryGetValue(character, out var nbT))
                nbChart[character] = 0;
            else
            {
                if (nbT == nbS)
                    return false;
                nbChart[character]++;
                
            }
        }

        return true;
    }
}