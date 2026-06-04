public class Solution {
    public bool hasDuplicate(int[] nums)
    {
        HashSet<int> dejaVus = new();
        return nums.Any(num => !dejaVus.Add(num));
    }
}