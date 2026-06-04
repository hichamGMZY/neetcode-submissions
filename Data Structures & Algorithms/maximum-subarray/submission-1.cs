public class Solution {
    public int MaxSubArray(int[] nums) {
        var curSum = 0;
        var maxSum = nums[0];
        foreach (var num in nums)
        {
            curSum = Math.Max(curSum, 0);
            curSum += num;
            maxSum = Math.Max(curSum, maxSum);
        }

        return maxSum;
    }
}