public class Solution {
    public void SortColors(int[] nums) {
        int[] nbColours = [0, 0, 0];
        foreach (var num in nums)
        {
            nbColours[num]++;
        }

        int cpt = 0;
        for (int i = 0; i < nbColours.Length; i++)
        {
            for (int j = 0; j < nbColours[i]; j++)
            {
                nums[cpt++] = i;
            }
        }
    }
}