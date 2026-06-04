
public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        HashSet<(int row, int col)> dejaVus = new();
        if (grid[0][0] != 0)
            return -1;
        if (grid.Last().Last() != 0)
            return -1;
        
        var queue = new Queue<(int row, int col, int length)>();
        queue.Enqueue((0, 0, 1));
        
        while (queue.Any())
        {
            var current = queue.Dequeue();
            var nextDir = GenerateNextDir(grid, current.row, current.col);
            foreach (var dir in nextDir)
            {
                if (dir.row == grid.Length - 1 && dir.col == grid[0].Length - 1)
                    return current.length + 1;

                if (grid[dir.row][dir.col] != 0)
                    continue;
                
                if (!dejaVus.Add((dir.row, dir.col)))
                    continue;
                
                queue.Enqueue((dir.row, dir.col, current.length + 1));
                
            }

        }

        return -1;
    }

    private List<(int row, int col)> GenerateNextDir(int[][] grid, int row, int col)
    {
        var res = new List<(int row, int col)>();
        for (int i = -1; i < 2; i++)
        {
            if (row + i < 0)
                continue;
            if (row + i >= grid.Length)
                continue;
            
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                
                if (col + j < 0)
                    continue;
                if (col + j >= grid[0].Length)
                    continue;
                res.Add((row +i, col  + j));

            }
        }

        return res;
    }
}