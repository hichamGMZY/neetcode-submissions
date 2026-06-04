public class Solution {
    public List<List<int>> Subsets(int[] nums)
    {
        var sortedNums = nums.Order().ToArray();
        var result = new List<List<int>>();
        var current = new List<int>();
        result.Add(current);
        CreateSubsets(sortedNums, result, current, 0 );
        return result;
    }

    public void CreateSubsets(int[] sortedNums, List<List<int>> result, List<int> current, int indexStart)
    {
        for (int i = indexStart; i < sortedNums.Length; i++)
        {
            var newList = current.ToList();
            newList.Add(sortedNums[i]);
            result.Add(newList);
            CreateSubsets(sortedNums, result, newList, i + 1);
        }
    }
}