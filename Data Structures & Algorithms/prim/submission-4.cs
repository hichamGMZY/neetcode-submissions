public class Solution
{

    
    public int MinimumSpanningTree(int n, List<List<int>> edges)
    {
        var graph = new Graph();
        graph.BuildGraph(edges.Select(x => x.ToArray()).ToArray(), n);
        var res = graph.MinimumSpanningTree();
        return res;
    }
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

    public int MinimumSpanningTree()
    {
        var minHeap = new PriorityQueue<(int cost, GraphNode n1, GraphNode n2), int>();
        var visited = new HashSet<int>();

        List<int[]> mst = new();
        var totalCost = 0;

        var node = nodes.First().Value;
        foreach (var (neighbour, cost) in node.Neighbours)
        {
            minHeap.Enqueue((cost, node, neighbour), cost);
        }

        visited.Add(node.Value);

        while (minHeap.Count > 0)
        {
            var (cost, nodeToVisit, nextNode) = minHeap.Dequeue();
            if (visited.Contains(nextNode.Value))
            {
                continue;
            }
            
            totalCost += cost;
            mst.Add(new[]{nodeToVisit.Value, nextNode.Value});
            foreach (var (newNode, newCost) in nextNode.Neighbours)
            {
                minHeap.Enqueue((newCost, nextNode, newNode), newCost);
            }

            visited.Add(nextNode.Value);
        }

        return visited.Count == nodes.Count ? totalCost : -1;
    }
}

