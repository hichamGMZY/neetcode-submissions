public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dico = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dico.ContainsKey(nums[i]))
            {
                dico[nums[i]].Add(i);
            }
            else
            {
                dico[nums[i]] = [i];
            }
          
        }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (dico.TryGetValue(target - nums[i], out var list))
            {
                foreach (var j in list)
                {
                    if (j > i)
                        return [i, j];
                }
            }
        }

        return [0, 0];
    }
    
}