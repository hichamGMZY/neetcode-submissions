
public class Solution {
    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        CloneGraph(node, nodes);
        return nodes[1];
    }

    public Node CloneGraph(Node node, Dictionary<int, Node> newNodes)
    {
        if (newNodes.TryGetValue(node.val, out var newNode))
            return newNode;
        newNode = new Node(node.val);
        newNodes[node.val] = newNode;
        foreach (var neighbor in node.neighbors)
        {
            var newNeighbor = CloneGraph(neighbor, newNodes);
            newNode.neighbors.Add(newNeighbor);
        }

        return newNode;
    }
}