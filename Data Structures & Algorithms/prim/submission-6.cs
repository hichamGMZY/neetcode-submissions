public class Solution
{

    public static void Test()
    {
     /*   var solution = new Solution();
        var res = solution.MinimumSpanningTree(5,
            [[0, 1, 10], [0, 2, 3], [1, 3, 2], [2, 1, 4], [2, 3, 8], [2, 4, 2], [3, 4, 5]]);
        Console.WriteLine(res); */
    }
    
    public int MinimumSpanningTree(int n, List<List<int>> edges)
    {
        var unionFind = new UnionFind(n);
        var mst = new List<(int, int)>();
        var minHeap = new PriorityQueue<(int n1, int n2, int cost ), int>();
        foreach (var edge in edges)
        {
            minHeap.Enqueue(GetEdge(edge), edge[2]);
        }

        var totalCost= 0;

        while (mst.Count < n - 1)
        {
            if (minHeap.Count == 0)
                return -1;
            var (n1, n2, cost) = minHeap.Dequeue();
            if (unionFind.Union(n1, n2))
            {
                mst.Add((n1, n2));
                totalCost += cost;
            }
        }

        return totalCost;
    }

    public (int n1, int n2, int cost) GetEdge(List<int> edge) => (edge[0], edge[1], edge[2]);
}


public class Graph
{
    private Dictionary<int, GraphNode> nodes = new();

    public int ShortestDistFromBegin(int begin)
    {
        var source = nodes[begin];
        Queue<GraphNode> nodesToVisit = new Queue<GraphNode>();
        HashSet<int> dejaVus = new HashSet<int>();
        Dictionary<int, int> shortestPaths = new();
        
        nodesToVisit.Enqueue(source);
        shortestPaths[source.Value] = 0;
        while (nodesToVisit.Any())
        {
            var node = nodesToVisit.Dequeue();

            foreach (var (child, cost) in node.Neighbours)
            {
                var costFromHere = shortestPaths[node.Value] + cost;
                var currentTime = shortestPaths.GetValueOrDefault(child.Value, Int32.MaxValue);
                if (costFromHere < currentTime)
                {
                    shortestPaths[child.Value] = Math.Min(currentTime, costFromHere);
                    nodesToVisit.Enqueue(child);
                }
            }
        }


        var maxTime = -1;
        foreach (var (key, node) in nodes)
        {
            if (!shortestPaths.TryGetValue(key, out var shortestTimeForKey))
                return -1;
            maxTime = Math.Max(maxTime, shortestTimeForKey);
        }

        return maxTime;
    }
    
    public class GraphNode
    {
        public int Value { get; set; }
        public readonly List<(GraphNode node, int cost)> Neighbours = new();

        public GraphNode(int value)
        {
            Value = value;
        }
    }

    
    
    public void BuildGraph(int[][] times, int n)
    {

        for (int i = 0; i < n; i++)
        {
            nodes[i] = new GraphNode(i);
        }
        
        foreach (var value in times)
        {
            var sourceNode = nodes[value[0]];
            var destinationNode = nodes[value[1]];
            sourceNode.Neighbours.Add((destinationNode, value[2])); 
            destinationNode.Neighbours.Add((sourceNode, value[2]));
        }
    }

}


public class UnionFind
{
    private Dictionary<int, int> parents = new();
    private Dictionary<int, int> rank = new();

    public UnionFind(int n)
    {
        for (int i = 0; i < n; i++)
        {
            parents[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int node)
    {
        var current = node;
        while (current != parents[current])
        {
            var parent = parents[parents[current]];
            parents[current] = parent;
            current = parent;
        }

        return current;
    }

    public bool Union(int n1, int n2)
    {
        var p1 = Find(n1);
        var p2 = Find(n2);

        if (p1 == p2)
            return false;

        if (rank[p1] > rank[p2])
        {
            parents[p2] = p1;
        } else if (rank[p2] > rank[p1])
        {
            parents[p1] = p2;
        }
        else
        {
            parents[p2] = p1;
            rank[p1]++;
        }

        return true;
    }
}