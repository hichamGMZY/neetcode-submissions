public class Solution {

    
    public List<int> topologicalSort(int n, int[][] edges)
    {
        Dictionary<int, List<int>> adj = new();
        for (int i = 0; i < n; i++)
            adj[i] = new();
        
        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
        }

        List<int> res = new();
        var visited = new HashSet<int>();
        var cycleDetector = new HashSet<int>();
        for (int i =0; i < n; i++)
        {
            if (!TopologicalSort(adj, i, visited, res, cycleDetector))
            {
                return new List<int>();
            }
        }

        res.Reverse();
        return res;

    }

    public bool TopologicalSort(Dictionary<int, List<int>> adj, int currentNode, HashSet<int> dejaVus, List<int> res, HashSet<int> cycleDetector)
    {
        if (cycleDetector.Contains(currentNode))
        {
            return false;
        }
        
        if (dejaVus.Contains(currentNode))
        {
            return true; //todo voir comment gerer les cycles
        }

        cycleDetector.Add(currentNode);
        dejaVus.Add(currentNode);
        
        foreach (var node in adj[currentNode])
        {
            if (!TopologicalSort(adj, node, dejaVus, res, cycleDetector))
                return false;
        }
        
        res.Add(currentNode);
        cycleDetector.Remove(currentNode);
        return true;
    }
}