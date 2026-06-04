
public class Solution {
    public static void Run()
    {
        int[] nums = [2, 5, 6, 9];
        int target = 9;
        var res = new Solution().CombinationSum(nums, target);
        ;
    }
    
    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        List<List<(int nb, int cpt)>> result = new();
        Dictionary<int, int> current = nums.ToDictionary(x => x, x=>0);
        CombinationSum(nums, target, 0, current, result);
        var res = new List<List<int>>();
        foreach (var list in result)
        {
            List<int> subres = new List<int>();
            foreach (var item in list)
            {
                for (int i = 0; i < item.cpt; i++)
                    subres.Add(item.nb);
            }
            res.Add(subres);

        }

        return res;
    }

    private void CombinationSum(int[] nums, int target, int indexStart, Dictionary<int, int> current,
        List<List<(int nb, int cpt)>> result)
    {
        if (target < 0)
            return;

        if (target == 0)
        {
            result.Add(current.Select(x => (x.Key, x.Value)).ToList());
            return;
        }

        for (int i = indexStart; i < nums.Length; i++)
        {
            var value = nums[i];
            current[value] += 1;
            CombinationSum(nums, target - value, i, current, result);
            current[value] -= 1;
        }
            
    }
}
