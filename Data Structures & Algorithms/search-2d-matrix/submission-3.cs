

public class Solution {


    public static void Run()
    {
        int[][] matrix = [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 50]];
        var solution = new Solution();
        var res = solution.SearchMatrix(matrix, 30);
        ;
    }
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var firstNumbers = matrix.Select(x => x.First()).ToArray();
        var row = Search(firstNumbers, target, true);
        return Search(matrix[row], target) != -1;
    }

    public int Search(int[] nums, int target, bool getBegin = false)
    {
        var begin = 0;
        var end = nums.Length - 1;
        if (nums[begin] == target)
            return begin;

        if (nums[end] == target)
            return end;

        if (getBegin && nums[end] < target)
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

        return getBegin ? begin : -1;

    }
}