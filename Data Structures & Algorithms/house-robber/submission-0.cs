public class Solution {
    public int Rob(int[] nums)
    {
        var maxCache = new Dictionary<int, int>();
        int end = nums.Length - 1;
        return Rob(nums, maxCache, end);
    }

    public int Rob(int[] nums, Dictionary<int, int> maxCache, int end)
    {
        if (maxCache.TryGetValue(end, out var result))
            return result;

        if (end < 0)
            return 0;

        if (end == 0)
            return nums[0];
        
        result = Math.Max(nums[end] + Rob(nums, maxCache, end - 2), nums[end - 1] + Rob(nums, maxCache, end - 3));
        maxCache.Add(end, result);
        return result;
    }
}
