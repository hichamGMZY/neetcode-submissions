
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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null)
        {
            return null;
        }

        var (current, prec) = FindNode(root, key);
        if (current == null)
            return root;

        var next = MergeChildren(current);
        if (prec == null)
            return next;

        if (prec.val < key)
        {
            prec.right = next;
        }
        else
            prec.left = next;

        return root;
    }
    
    private (TreeNode? current, TreeNode? prec) FindNode(TreeNode root, int key)
    {
        if (root.val == key)
            return (root, null);
        var current = root;
        TreeNode? prec = null;
        while (true)
        {
            prec = current;
            if (current.val < key)
                current = current.right;
            else
                current = current.left;

            if (current == null)
                return (null, null);
            if (current.val == key)
                return (current, prec);
        }

    }


    private TreeNode? MergeChildren(TreeNode node)
    {
        if (node.left == null)
            return node.right;
        if (node.right == null)
            return node.left;

        var current = node.right;
        while (current.left != null)
            current = current.left;
        current.left = node.left;
        return node.right;
    }
    
}