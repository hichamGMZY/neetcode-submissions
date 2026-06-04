
public class Solution {
    public int Search(int[] nums, int target)
    {
        var begin = 0;
        var end = nums.Length - 1;
        if (nums[begin] == target)
            return begin;

        if (nums[end] == target)
            return end;
        
        while (end - begin > 1)
        {
            var middle = (begin + end) / 2;
            if (nums[middle] == target)
                return middle;
            if (nums[middle] > target)
                end = middle;
            else
                begin = middle;
        }

        return -1;

    }
}