public class Solution {
    public static void Test()
    {
        var solution = new Solution();
        int[] nums = [1, 2, 3, 1];
        int k = 3;
        var res = solution.ContainsNearbyDuplicate(nums, k);
        ;
    }
    
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var set = new HashSet<int>();
        var left = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i - left > k)
            {
                set.Remove(nums[left]);
                left++;
            }

            if (!set.Add(nums[i]))
                return true;
        }

        return false;
    }
}