public class KthLargest
{

    private PriorityQueue<int, int> _queue = new();
    private int _k;
    public KthLargest(int k, int[] nums)
    {
        _k = k;
        foreach (var num in nums)
            Add(num);
    }
    
    public int Add(int val) {
        if (_queue.Count < _k)
        {
            _queue.Enqueue(val, val);
            return _queue.Peek();
        }

        var min = _queue.Peek();
        if (val > min)
        {
            _queue.Dequeue();
            _queue.Enqueue(val, val);
        }

        return _queue.Peek();

    }
}
