public class NumArray
{

    public static void Test()
    {
        int[] nums = [-2, 0, 3, -5, 2, -1];
        var solution = new NumArray(nums);
        var res1 = solution.SumRange(0, 2);
        var res2 = solution.SumRange(2, 5);
        var res3 = solution.SumRange(0, 5);
        Console.WriteLine(res1);
        Console.WriteLine(res2);
        Console.WriteLine(res3);
    }
    
    private int[] _nums;
    
    public NumArray(int[] nums) {
        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
        }
        _nums = nums;
    }
    
    public int SumRange(int left, int right) => left == 0 ? _nums[right] : _nums[right] - _nums[left - 1];
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */