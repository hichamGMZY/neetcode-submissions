public class Solution {
    public class Node
    {
        public int Value { get; set; }
        public List<Node> Neighbors { get; set; } = new List<Node>();

        public Node(int value)
        {
            this.Value = value;
        }
    }
    
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        
        Node[] graph = new Node[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new Node(i);
        }

        foreach (var prerequisite in prerequisites)
        {
            var source = prerequisite[1];
            var target = prerequisite[0];
            var sourceNode = graph[source];
            var targetNode = graph[target];
            sourceNode.Neighbors.Add(targetNode);
        }

        HashSet<int> dejaVus = new();

        for (int i = 0; i < numCourses; i++)
        {
            if (dejaVus.Contains(i))
                continue;
            var currentCycle = new HashSet<int>();
            
            if (!CanFinish(graph[i], dejaVus, currentCycle))
                return false;
        }

        return true;
    }

    private bool CanFinish(Node node, HashSet<int> dejaVus, HashSet<int> currentCycle)
    {
        dejaVus.Add(node.Value);
        if (!currentCycle.Add(node.Value))
            return false;

        foreach (var targetNode in node.Neighbors)
        {
            if (!CanFinish(targetNode, dejaVus, currentCycle))
                return false;
            
        }

        currentCycle.Remove(node.Value);
        return true;
    }
}