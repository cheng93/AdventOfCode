namespace AdventOfCode2023.Day25;

public static class Day25Solver
{
    public static int PuzzleOne(string input)
    {
        var wires = input
            .Split(Environment.NewLine)
            .SelectMany(x => new Day25Connection(x).Wires)
            .ToArray();

        while (true)
        {
            var graph = Karger(new Day25Graph(wires), 2);
            if (graph.MinCut == 3)
            {
                return graph.Nodes
                    .Aggregate(1, (agg, cur) => agg * cur.Split(',').Length);
            }
        }

        Day25Graph Karger(Day25Graph g, double t)
        {
            var random = new Random();
            while (g.NodesCount > t)
            {
                var index = random.Next(g.OriginalEdges.Count);
                var (left, right) = g.OriginalEdges.ElementAt(index);
                g.Merge(left, right);
            }

            return g;
        }
    }
}