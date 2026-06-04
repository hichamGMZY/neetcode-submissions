

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
    public List<int> InorderTraversal(TreeNode root)
    {
        List<int> list = new List<int>();
        Traverse(root, list);
        return list;
    }

    private void Traverse(TreeNode root, List<int> list)
    {
        if (root == null)
            return;
        Traverse(root.left, list);
        list.Add(root.val);
        Traverse(root.right, list);
    }
    
    
}