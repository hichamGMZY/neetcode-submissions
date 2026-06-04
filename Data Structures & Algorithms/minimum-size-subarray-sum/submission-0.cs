public class Solution {

    public static void Test()
    {
        var solution = new Solution();
        int target = 5;
        int[] nums = [1, 2, 1];
        int res = solution.MinSubArrayLen(target, nums);
        ;
    }
    
    public int MinSubArrayLen(int target, int[] nums)
    {
        var length = Int32.MaxValue;
        var left = 0;
        var curSum = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            curSum += nums[right];
            if (curSum < target)
                continue;

            while (curSum >= target && left <= right)
            {
                length = Math.Min(length, right - left + 1);
                curSum -= nums[left];
                left += 1;
            }
        }

        return length == int.MaxValue ? 0 : length;
    }
}