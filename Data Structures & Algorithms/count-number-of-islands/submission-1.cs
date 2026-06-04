public class Solution {
    public int NumIslands(char[][] grid)
    {
        var dejaVus = new HashSet<(int x, int y)>();
        var cptComp = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1' && !dejaVus.Contains((i, j)))
                {
                    ParseComponent(grid, i, j, dejaVus);
                    cptComp++;
                }
                
            }
        }

        return cptComp;
    }

    private void ParseComponent(char[][] grid, int row, int col, HashSet<(int x, int y)> dejaVus)
    {
        if (!CheckDimension(grid, row, col))
            return;

        if (!dejaVus.Add((row, col)))
            return;

        if (grid[row][col] != '1')
            return;
        
        ParseComponent(grid, row + 1, col, dejaVus);
        ParseComponent(grid, row - 1, col, dejaVus);
        ParseComponent(grid, row, col + 1, dejaVus);
        ParseComponent(grid, row, col - 1, dejaVus);
    }

    private bool CheckDimension(char[][] grid, int row, int col)
    {
        if (row < 0 || row >= grid.Length)
            return false;
        if (col < 0 || col >= grid[0].Length)
            return false;
        return true;
    }
}