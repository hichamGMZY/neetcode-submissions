public class Solution {

    public static void Run()
    {
        var solution = new Solution();
        int[] nums1 = [10, 20, 20, 40, 0, 0];
        var m = 4;
        int[] nums2 = [1, 2];
        var n = 2;
        
        solution.Merge(nums1, m, nums2, n);
        ; 
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var outTab = new int[m + n];
        var cpt1 = 0;
        var cpt2 = 0;
        var cptTot = 0;

        while (cpt1 < m && cpt2 < n)
        {
            if (nums1[cpt1] < nums2[cpt2])
            {
                outTab[cptTot++] = nums1[cpt1++];
            }
            else
            {
                outTab[cptTot++] = nums2[cpt2++];
            }
        }

        while (cpt1 < m)
        {
            outTab[cptTot++] = nums1[cpt1++];
        }

        while (cpt2 < n)
        {
            outTab[cptTot++] = nums2[cpt2++];
        }

        for (int i = 0; i < n + m; i++)
        {
            nums1[i] = outTab[i];
        }
    }

    
    public void MergeOpti(int[] nums1, int m, int[] nums2, int n)
    {
        var cpt12 = 0;
        var cpt2 = 0;
        for (int cpt1 = 0; cpt1 < m + n; cpt1++)
        {
            if (cpt12 >= cpt2)
            {
                if (cpt2 >= n || nums1[cpt1] < nums2[cpt2])
                    continue;

                (nums1[cpt1], nums2[cpt2]) = (nums2[cpt2], nums1[cpt1]);
                cpt2++;
            }
            else
            {
                if (cpt2 >= n || nums2[cpt12] < nums2[cpt2])
                {
                    nums1[cpt1] = nums2[cpt12];
                    cpt12++;
                }
                else
                {
                    (nums1[cpt1], nums2[cpt2]) = (nums2[cpt2], nums1[cpt1]);
                    cpt2++;
                }
            }
        }
    }
}