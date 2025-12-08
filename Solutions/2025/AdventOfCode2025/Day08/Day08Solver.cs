using MoreLinq;

namespace AdventOfCode2025.Day08;

using Coord = (int X, int Y, int Z);

public static class Day08Solver
{
    public static long PuzzleOne(string input, int limit = 1000)
    {
        var junctions = input
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var splits = x
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                return (X: splits[0], Y: splits[1], Z: splits[2]);
            })
            .ToArray();

        var pairs = junctions
            .Subsets(2)
            .OrderBy(p => EuclideanDistanceSquared(p[0], p[1]));

        var circuits = junctions
            .Select(x => new HashSet<Coord> { x })
            .ToList();
        
        foreach (var pair in pairs.Take(limit))
        {
            var first = circuits.Single(c => c.Contains(pair[0]));
            var last = circuits.Single(c => c.Contains(pair[1]));
            
            if (first == last)
            {
                continue;
            }

            first.UnionWith(last);
            circuits.Remove(last);
        }

        return circuits
            .OrderByDescending(c => c.Count)
            .Take(3)
            .Aggregate(1L, (agg, cur) => agg * cur.Count);
    }

    public static long PuzzleTwo(string input)
    {
        var junctions = input
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var splits = x
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                return (X: splits[0], Y: splits[1], Z: splits[2]);
            })
            .ToArray();

        var pairs = junctions
            .Subsets(2)
            .OrderBy(p => EuclideanDistanceSquared(p[0], p[1]));

        var circuits = junctions
            .Select(x => new HashSet<Coord> { x })
            .ToList();
        
        foreach (var pair in pairs)
        {
            var first = circuits.Single(c => c.Contains(pair[0]));
            var last = circuits.Single(c => c.Contains(pair[1]));
            
            if (first == last)
            {
                continue;
            }

            first.UnionWith(last);
            circuits.Remove(last);

            if (circuits.Count == 1)
            {
                return 1L * pair[0].X * pair[1].X;
            }
        }

        throw new Exception();
    }
    
    private static long EuclideanDistanceSquared(Coord a, Coord b)
        => (long)Math.Pow(a.X - b.X, 2) + (long)Math.Pow(a.Y - b.Y, 2) + (long)Math.Pow(a.Z - b.Z, 2);
}