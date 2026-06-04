public class Solution {
    public int LongestCommonSubsequence(string text1, string text2)
    {
        return LongestCommonSubsequence(text1, text2, text1.Length - 1, text2.Length - 1,
            new Dictionary<(int ind1, int ind2), int>());
    }

    private int LongestCommonSubsequence(string text1, string text2, int ind1, int ind2, Dictionary<(int ind1, int ind2), int> cache)
    {
        if (cache.TryGetValue((ind1, ind2), out var result))
            return result;
        if (ind1 < 0 || ind2 < 0)
            return 0;

        if (text1[ind1] == text2[ind2])
        {
            result = 1 + LongestCommonSubsequence(text1, text2, ind1 - 1, ind2 - 1, cache);
        }
        else
        {
            result = Math.Max(LongestCommonSubsequence(text1, text2, ind1 - 1, ind2, cache),
                LongestCommonSubsequence(text1, text2, ind1, ind2 - 1, cache));
        }

        cache[(ind1, ind2)] = result;
        return result;
    }
}