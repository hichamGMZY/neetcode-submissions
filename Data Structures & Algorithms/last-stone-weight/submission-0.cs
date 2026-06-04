
public class Solution {
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> queue = new();
        foreach(var stone in stones)
            queue.Enqueue(stone, -stone);

        while (queue.Count > 1)
        {
            var stone1 = queue.Dequeue();
            var stone2 = queue.Dequeue();
            var rescrash = stone1 - stone2;
            if (rescrash == 0)
                continue;
            queue.Enqueue(rescrash, -rescrash);
        }

        return queue.TryPeek(out var last, out int priority) ? last : 0;
    }
}
