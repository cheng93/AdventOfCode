namespace AdventOfCode2023.Day25;

using System.Diagnostics.CodeAnalysis;
using Edge = (string Left, string Right);

public class Day25Graph
{
    public Day25Graph(IEnumerable<Edge> edges)
    {
        OriginalEdges = edges.ToList();
        foreach (var edge in edges)
        {
            superEdges.Add(edge, new([edge]));
            if (!superNodes.ContainsKey(edge.Left))
            {
                superNodes.Add(edge.Left, new(edge.Left, [edge.Left]));
                graph.Add(edge.Left, new());
            }
            if (!superNodes.ContainsKey(edge.Right))
            {
                superNodes.Add(edge.Right, new(edge.Right, [edge.Right]));
                graph.Add(edge.Right, new());
            }

            graph[edge.Left].Add(edge.Right);
            graph[edge.Right].Add(edge.Left);
        }
    }

    private Day25Graph(Dictionary<string, SuperNode> superNodes, Dictionary<Edge, SuperEdge> superEdges)
    {
        this.superNodes = superNodes.ToDictionary();
        this.superEdges = superEdges.ToDictionary(new EdgeComparer());
        this.OriginalEdges = superEdges.Values
            .SelectMany(x => x.Edges)
            .ToHashSet();
        foreach (var edge in superEdges.Keys)
        {
            if (!graph.ContainsKey(edge.Left))
            {
                graph.Add(edge.Left, new());
            }
            if (!graph.ContainsKey(edge.Right))
            {
                graph.Add(edge.Right, new());
            }

            graph[edge.Left].Add(edge.Right);
            graph[edge.Right].Add(edge.Left);
        }
    }

    public ICollection<Edge> OriginalEdges { get; }

    public IEnumerable<string> Nodes => graph.Keys;

    public int NodesCount => graph.Count;

    public IEnumerable<Edge> Edges => superEdges.Keys;

    public int? MinCut => superEdges.Count == 1 ? superEdges.First().Value.Edges.Count : null;

    private readonly Dictionary<string, HashSet<string>> graph = new();

    private readonly Dictionary<string, SuperNode> superNodes = new();

    private readonly Dictionary<Edge, SuperEdge> superEdges = new(new EdgeComparer());

    public void Merge(string left, string right)
    {
        var leftNode = superNodes[left];
        var rightNode = superNodes[right];
        var superNode = leftNode + rightNode;
        graph.Add(superNode.Id, new());
        foreach (var node in superNode.Nodes)
        {
            superNodes[node] = superNode;
        }

        var leftNeighbours = graph[leftNode.Id].ToHashSet();
        leftNeighbours.Remove(rightNode.Id);
        var rightNeighbours = graph[rightNode.Id].ToHashSet();
        rightNeighbours.Remove(leftNode.Id);
        var neighbours = leftNeighbours.Concat(rightNeighbours).ToHashSet();
        var union = leftNeighbours.ToHashSet();
        union.IntersectWith(rightNeighbours);
        leftNeighbours.ExceptWith(union);
        rightNeighbours.ExceptWith(union);

        foreach (var neighbour in neighbours)
        {
            graph[neighbour].Remove(leftNode.Id);
            graph[neighbour].Remove(rightNode.Id);
            graph[neighbour].Add(superNode.Id);
            graph[superNode.Id].Add(neighbour);
        }

        graph.Remove(leftNode.Id);
        graph.Remove(rightNode.Id);

        foreach (var common in union)
        {
            var leftEdge = superEdges[(common, leftNode.Id)];
            var rightEdge = superEdges[(common, rightNode.Id)];
            var newEdge = leftEdge + rightEdge;
            superEdges.Add((common, superNode.Id), newEdge);
            superEdges.Remove((common, leftNode.Id));
            superEdges.Remove((common, rightNode.Id));
        }
        foreach (var neighbour in leftNeighbours)
        {
            var edge = superEdges[(leftNode.Id, neighbour)];
            superEdges.Add((superNode.Id, neighbour), edge);
            superEdges.Remove((leftNode.Id, neighbour));
        }
        foreach (var neighbour in rightNeighbours)
        {
            var edge = superEdges[(rightNode.Id, neighbour)];
            superEdges.Add((superNode.Id, neighbour), edge);
            superEdges.Remove((rightNode.Id, neighbour));
        }

        var removeEdge = superEdges[(leftNode.Id, rightNode.Id)];
        superEdges.Remove((leftNode.Id, rightNode.Id));
        foreach (var edge in removeEdge.Edges)
        {
            OriginalEdges.Remove(edge);
        }
    }

    public Day25Graph Clone() => new Day25Graph(superNodes, superEdges);

    private class SuperNode
    {
        public SuperNode(string id, ICollection<string> nodes)
        {
            Id = id;
            Nodes = nodes;
        }

        public string Id { get; }
        public ICollection<string> Nodes { get; }

        public static SuperNode operator +(SuperNode left, SuperNode right)
            => new($"{left.Id},{right.Id}", left.Nodes.Concat(right.Nodes).ToList());
    }

    private class SuperEdge
    {
        public SuperEdge(ICollection<Edge> edges)
        {
            Edges = edges;
        }

        public ICollection<Edge> Edges { get; }

        public static SuperEdge operator +(SuperEdge left, SuperEdge right)
            => new(left.Edges.Concat(right.Edges).ToList());
    }

    private class EdgeComparer : IEqualityComparer<Edge>
    {
        public bool Equals(Edge x, Edge y) => x == y || x == (y.Right, y.Left);

        public int GetHashCode([DisallowNull] Edge edge) => edge.Left.GetHashCode() ^ edge.Right.GetHashCode();
    }
}