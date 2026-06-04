
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        Dictionary<(int row, int col), int> cache = new();
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        return UniquePath(m - 1, n - 1, cache, obstacleGrid);

    }

    private int UniquePath(int row, int col , Dictionary<(int row, int col), int> cache, int[][] obstacleGrid)
    {
        if (row < 0 || col < 0)
            return 0;
        
        if (obstacleGrid[row][col] == 1)
            return 0;
        
        if (cache.TryGetValue((row, col), out var result))
            return result;

        if (row == 0 && col == 0)
            return 1;
     

        result = UniquePath(row, col - 1, cache, obstacleGrid) + UniquePath(row - 1, col, cache, obstacleGrid);
        cache[(row, col)] = result;
        return result;
    }
}