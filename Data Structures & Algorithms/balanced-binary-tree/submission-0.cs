
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
    public bool IsBalanced(TreeNode root)
    {
        return CheckBalanced(root).balanced;
    }

    public (int height, bool balanced) CheckBalanced(TreeNode root)
    {
        if (root == null)
            return (0, true);
        var (leftHeight, balancedLeft) = CheckBalanced(root.left);
        if (!balancedLeft)
            return (-1, false);
        var (rightHeight, balancedRight) = CheckBalanced(root.right);
        if (!balancedRight)
            return (-1, false);

        if (Math.Abs(rightHeight - leftHeight) > 1)
            return (-1, false);
        
        return (Math.Max(rightHeight, leftHeight) + 1, true);
    }
}