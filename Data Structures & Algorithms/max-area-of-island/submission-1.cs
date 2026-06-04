public class Solution {
    public int MaxAreaOfIsland(int[][] grid)
    {
        var dejaVus = new HashSet<(int x, int y)>();
        var maxArea = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1 && !dejaVus.Contains((i, j)))
                {
                    int area = 0;
                    ParseComponent(grid, i, j, dejaVus, ref area);
                    maxArea = Math.Max(maxArea, area);
                }
                
            }
        }

        return maxArea;
    }

    private void ParseComponent(int[][] grid, int row, int col, HashSet<(int x, int y)> dejaVus, ref int area)
    {
        if (!CheckDimension(grid, row, col))
            return;

        if (!dejaVus.Add((row, col)))
            return;

        if (grid[row][col] != 1)
            return;
        area++;
        ParseComponent(grid, row + 1, col, dejaVus, ref area);
        ParseComponent(grid, row - 1, col, dejaVus, ref area);
        ParseComponent(grid, row, col + 1, dejaVus, ref area);
        ParseComponent(grid, row, col - 1, dejaVus, ref area);
    }

    private bool CheckDimension(int[][] grid, int row, int col)
    {
        if (row < 0 || row >= grid.Length)
            return false;
        if (col < 0 || col >= grid[0].Length)
            return false;
        return true;
    }
}