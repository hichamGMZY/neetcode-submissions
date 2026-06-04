public class Solution {
    public static void Run()
    {
        var res = new Solution().IsAnagram("racecar", "carrace");
        Console.WriteLine(res);
    }
    
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        
        Dictionary<char, int> counterS = new();
        Dictionary<char, int> counterT = new();
        foreach (var c in s)
        {
            if (!counterS.TryGetValue(c, out var cpt))
            {
                counterS[c] = 1;
            }
            else
            {
                counterS[c] = cpt + 1; 
            }
        }
        
        foreach (var c in t)
        {
            if (!counterS.TryGetValue(c, out var cptS))
                return false;
            
            if (!counterT.TryGetValue(c, out var cpt))
                counterT[c] = 1;
            else
                counterT[c] = cpt + 1;

            if (cpt == cptS)
                return false;

        }

        return true;

    }
}