namespace AdventOfCode2023.Day22;

using Coord = (int X, int Y, int Z);

public static class Day22Solver
{
    public static int PuzzleOne(string input)
    {
        var bricks = input
            .Split(Environment.NewLine)
            .Select(x => new Day22Brick(x))
            .ToArray();

        var ordered = bricks
            .Select((brick, i) => new { Brick = brick, Index = i })
            .OrderBy(x => Math.Min(x.Brick.Start.Z, x.Brick.End.Z))
            .Select(x => x.Index);

        var settled = new Dictionary<Coord, int>();
        var brickSupports = bricks
            .Select(x => new HashSet<int>())
            .ToArray();
        var supportedBy = bricks
            .Select(x => new HashSet<int>())
            .ToArray();

        var highestPoints = new Dictionary<(int X, int Y), int>();

        foreach (var index in ordered)
        {
            var brick = bricks[index];
            var xys = brick
                .Base()
                .Select(coord => (coord.X, coord.Y))
                .ToArray();

            var peaks = xys
                .Select<(int X, int Y), Coord>(xy => (xy.X, xy.Y, highestPoints.TryGetValue(xy, out var z) ? z : 0))
                .GroupBy(coord => coord.Z)
                .OrderByDescending(group => group.Key)
                .First()
                .ToArray();

            var supports = peaks
                .Where(settled.ContainsKey)
                .Select(coord => settled[coord])
                .Distinct();

            foreach (var s in supports)
            {
                brickSupports[s].Add(index);
                supportedBy[index].Add(s);
            }

            foreach (var xy in xys)
            {
                var z = peaks[0].Z + brick.Height;
                highestPoints[xy] = z;
                settled[(xy.X, xy.Y, z)] = index;
            }
        }

        var disintegratable = 0;
        for (var i = 0; i < bricks.Length; i++)
        {
            var supports = brickSupports[i];
            if (supports.Count == 0)
            {
                disintegratable++;
            }
            else
            {
                if (supports.All(s => supportedBy[s].Count(sb => sb != i) > 0))
                {
                    disintegratable++;
                }
            }
        }

        return disintegratable;
    }

    public static int PuzzleTwo(string input)
    {
        var bricks = input
            .Split(Environment.NewLine)
            .Select(x => new Day22Brick(x))
            .ToArray();

        var ordered = bricks
            .Select((brick, i) => new { Brick = brick, Index = i })
            .OrderBy(x => Math.Min(x.Brick.Start.Z, x.Brick.End.Z))
            .Select(x => x.Index);

        var settled = new Dictionary<Coord, int>();
        var brickSupports = bricks
            .Select(x => new HashSet<int>())
            .ToArray();
        var supportedBy = bricks
            .Select(x => new HashSet<int>())
            .ToArray();

        var highestPoints = new Dictionary<(int X, int Y), int>();

        foreach (var index in ordered)
        {
            var brick = bricks[index];
            var xys = brick
                .Base()
                .Select(coord => (coord.X, coord.Y))
                .ToArray();

            var peaks = xys
                .Select<(int X, int Y), Coord>(xy => (xy.X, xy.Y, highestPoints.TryGetValue(xy, out var z) ? z : 0))
                .GroupBy(coord => coord.Z)
                .OrderByDescending(group => group.Key)
                .First()
                .ToArray();

            var supports = peaks
                .Where(settled.ContainsKey)
                .Select(coord => settled[coord])
                .Distinct();

            foreach (var s in supports)
            {
                brickSupports[s].Add(index);
                supportedBy[index].Add(s);
            }

            foreach (var xy in xys)
            {
                var z = peaks[0].Z + brick.Height;
                highestPoints[xy] = z;
                settled[(xy.X, xy.Y, z)] = index;
            }
        }

        int Disintegrate(int index)
        {
            var removed = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(index);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                removed.Add(current);

                foreach (var supported in brickSupports[current])
                {
                    if (supportedBy[supported].IsSubsetOf(removed))
                    {
                        queue.Enqueue(supported);
                    }
                }
            }
            return removed.Count - 1;
        }

        return Enumerable
            .Range(0, bricks.Length)
            .Select(Disintegrate)
            .Sum();
    }
}