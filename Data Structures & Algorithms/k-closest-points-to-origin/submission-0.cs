public class Solution {
    public int[][] KClosest(int[][] points, int k) 
    {
        PriorityQueue<(int[] point, double dist), double> queue = new();
        foreach (var point in points)
        {
            var dist = point[0] * point[0] + point[1] * point[1];
            if (queue.Count < k)
                queue.Enqueue((point, dist), -dist);
            else
            {
                if (dist < queue.Peek().dist)
                {
                    queue.Dequeue();
                    queue.Enqueue((point, dist), -dist);
                }
            }
        }

        int[][] res = new int[k][];
        for (int i = 0; i < k; i++)
            res[i] = queue.Dequeue().point;
        return res;
    }
}
