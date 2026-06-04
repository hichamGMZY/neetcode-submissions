

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int KthSmallest(TreeNode root, int k)
    {
        int cpt = 0;
        return KthSmallest(root,ref cpt,  k).Value;
    }

    public int? KthSmallest(TreeNode node, ref int cpt, int k)
    {
        if (node is null)
            return null;

        var valueLeft = KthSmallest(node.left, ref cpt, k);
        if (valueLeft != null)
            return valueLeft;
        cpt++;
        if (cpt == k)
            return node.val;
        return KthSmallest(node.right, ref cpt, k);
    }
    
}
