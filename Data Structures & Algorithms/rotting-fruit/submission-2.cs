public class Solution {
    public int OrangesRotting(int[][] grid)
    {
        HashSet<(int row, int col)> freshFruits = new();
        Dictionary<(int row, int col), int> rottingDate = new();
        for (int row = 0; row < grid.Length; ++row)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                var data = grid[row][col];
                if (data == 0)
                    continue;
                if (data == 1)
                {
                    freshFruits.Add((row, col));
                    continue;
                }

                var queue = new Queue<(int row, int col, int minute)>();
                queue.Enqueue((row, col, 0));
                while (queue.Any())
                {
                    var (currentRow, currentCol, minute) = queue.Dequeue();
                    var directions = GenerateDirections(grid, currentRow, currentCol);
                    foreach (var dir in directions)
                    {
                        if (grid[dir.row][dir.col] != 1)
                            continue;
                        if (rottingDate.TryGetValue((dir.row, dir.col), out var oldDate) && oldDate <= minute + 1)
                            continue;
                        rottingDate[(dir.row, dir.col)] = minute + 1;
                        queue.Enqueue((dir.row, dir.col, minute + 1));
                    }
                }
            }
        }

        var maxMinute = 0;
        foreach (var fruit in freshFruits)
        {
            if (!rottingDate.TryGetValue((fruit.row, fruit.col), out var date))
            {
                return -1;
            }

            maxMinute = Math.Max(maxMinute, date);
        }

        return maxMinute;
    }

    private List<(int row, int col)> GenerateDirections(int[][] grid, int row, int col)
    {
        var result = new List<(int row, int col)>();
        if (row > 0) result.Add((row - 1, col));
        if (row < grid.Length - 1)
            result.Add((row + 1, col));
        if (col > 0)
            result.Add((row, col  - 1));
        if (col < grid[row].Length - 1)
            result.Add((row, col + 1));
        return result;
    }
}