using MoreLinq;

namespace AdventOfCode2025.Day09;

using Coord = (int X, int Y);

public static class Day09Solver
{
    public static long PuzzleOne(string input) => Solve(input, false);

    public static long PuzzleTwo(string input) => Solve(input, true);

    private static long Solve(string input, bool filter)
    {
        var tiles = input
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var splits = x
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                return (X: splits[0], Y: splits[1]);
            })
            .ToArray();
        
        Coord min = (tiles.Select(t => t.X).Min() - 2 , tiles.Select(t => t.Y).Min() - 2); 
        Coord max = (tiles.Select(t => t.X).Max() + 2, tiles.Select(t => t.Y).Max() + 2);

        var cache = new Dictionary<(int Point, bool xAxis), (int Point, int Direction)[]>();

        return tiles
            .Subsets(2)
            .Where(IsContained)
            .Select(t => 
                1L * (Math.Abs(t[0].X - t[1].X) + 1) * (Math.Abs(t[0].Y - t[1].Y ) + 1))
            .Max();

        bool IsContained(IList<Coord> pair)
        {
            if (!filter)
            {
                return true;
            }
            var first = pair[0];
            var last = pair[1];

            var corners = new[]
            {
                first,
                (first.X, last.Y),
                last,
                (last.X, first.Y)
            }.Distinct().ToArray();

            return Enumerable
                .Range(0, corners.Length)
                .All(x => NoGaps(corners[x], corners[(x + 1) % corners.Length]));
        }

        bool NoGaps(Coord a, Coord b)
        {
            var isAlongXAxis = a.Y - b.Y == 0;
            Func<Coord, int> parallel = isAlongXAxis ? c => c.X : c => c.Y;
            Func<Coord, int> perpendicular = isAlongXAxis ? c => c.Y : c => c.X;

            (int Point, int Direction)[] GetSegments(int point, bool xAxis)
            {
                if (cache.TryGetValue((point, xAxis), out var cached))
                {
                    return cached;
                }

                var segments = new List<(int Point, int Direction)>();
                for (var i = 0; i < tiles.Length; i++)
                {
                    var start = tiles[i];
                    var end = tiles[(i + 1) % tiles.Length];
                    var points = new[] { start, end }
                        .Select(perpendicular)
                        .ToArray();
                    var ordered = points.OrderBy(p => p).ToArray();

                    if (ordered[0] <= point && point <= ordered[1])
                    {
                        segments.Add((parallel(start), Math.Sign(points[1] - points[0])));
                    }
                }

                segments = segments
                    .Where(i => i.Direction != 0)
                    .OrderBy(i => i.Point)
                    .ToList();
                var first = segments.First();
                segments = [
                    (parallel(min), first.Direction * -1),
                    ..segments,
                    (parallel(max), first.Direction)];
                cache.Add((point, xAxis), segments.ToArray());
                return segments.ToArray();
            }

            var segments = GetSegments(perpendicular(a), isAlongXAxis);
            var line = new[] { a, b }
                .Select(parallel)
                .OrderBy(p => p)
                .ToArray();
            var isIn = false;
            var current = segments.First();
            foreach (var segment in segments.Skip(1))
            {
                if (segment.Direction == current.Direction)
                {
                    current = segment;
                    continue;
                }
                if (!isIn)
                {
                    var points = new[] { current.Point, segment.Point }
                        .OrderBy(p => p)
                        .ToArray();

                    if (points[1] - points[0] > 1)
                    {
                        var start = points[0] + 1;
                        var end = points[1] - 1;

                        if (line[0] <= start && line[1] >= start
                            || line[0] <= end && line[1] >= end
                            || line[0] >= start && line[1] <= end)
                        {
                            return false;
                        }
                    }
                }

                isIn = !isIn;
                current = segment;
            }

            return true;
        }
    }
}