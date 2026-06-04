
public class Solution {
    public int UniquePaths(int m, int n)
    {
        Dictionary<(int row, int col), int> cache = new();
        return UniquePath(m, n, cache);

    }

    private int UniquePath(int row, int col , Dictionary<(int row, int col), int> cache)
    {
        if (cache.TryGetValue((row, col), out var result))
        {
            return result;
        }

        if (row == 1)
            return 1;
        if (col == 1)
            return 1;

        result = UniquePath(row, col - 1, cache) + UniquePath(row - 1, col, cache);
        cache[(row, col)] = result;
        return result;
    }
}