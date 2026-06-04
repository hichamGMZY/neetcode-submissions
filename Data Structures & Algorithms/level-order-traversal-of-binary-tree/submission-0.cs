

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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> res = new List<List<int>>();
        Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
        if (root == null)
            return res;
        queue.Enqueue((root, 0));
        while (queue.Any())
        {
            (var node, int level) = queue.Dequeue();
            if (res.Count <= level)
                res.Add(new List<int>());
            res[level].Add(node.val);
            if (node.left != null)
                queue.Enqueue((node.left, level + 1));
            if (node.right != null)
                queue.Enqueue((node.right, level + 1));
        }

        return res;

    }
}