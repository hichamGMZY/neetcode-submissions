

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
    public List<int> RightSideView(TreeNode root)
    {
        var queue = new Queue<(TreeNode  node, int level)>();
        if (root == null)
            return new();
        var res = new List<int>();
        queue.Enqueue((root, 0));
        while (queue.Any())
        {
            var (node, level) = queue.Dequeue();
            if (node.left != null)
                queue.Enqueue((node.left, level + 1));
            if (node.right != null)
                queue.Enqueue((node.right, level + 1));

            if (queue.TryPeek(out var next))
            {
                if (level < next.level)
                    res.Add(node.val);
            }
            else
            {
                res.Add(node.val);
            }
        }

        return res;
    }
}