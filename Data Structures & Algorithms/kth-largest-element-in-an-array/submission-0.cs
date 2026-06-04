public class Solution {
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> queue = new();
        foreach (var num in nums)
        {
            if (queue.Count < k)
                queue.Enqueue(num, num);
            else
            {
                if (num > queue.Peek())
                {
                    queue.Dequeue();
                    queue.Enqueue(num, num);
                }
            }
        }

        return queue.Peek();
    }
}
