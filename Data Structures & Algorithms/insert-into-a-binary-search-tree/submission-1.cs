

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
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root is null)
        {
            return new TreeNode(val);
        }
        var current = root;
        while (true)
        {
            TreeNode next;
            if (current.val < val)
            {
                next = current.right;
                if (next is null)
                {
                    current.right = new TreeNode(val);
                    return root;
                }

                current = next;
            }
            else
            {
                next = current.left;
                if (next is null)
                {
                    current.left = new TreeNode(val);
                    return root;
                }

                current = next;
            }
        }
    }
}