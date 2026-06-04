
public class Solution {
    public static void Test()
    {
        var solution = new Solution();
        int[] numbers = [1, 2, 3, 4];
        int target = 3;
        var res = solution.TwoSum(numbers, target);
        Console.WriteLine(string.Join(",", res));
        ;
    }
    
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;
        while (left < right)
        {
            var sum = numbers[left] + numbers[right];
            if (sum == target)
                return [left + 1, right + 1];
            else if (sum < target)
                left++;
            else
                right--;
        }

        return null;
    }
}