namespace AdventOfCode2023.Day24;

using Coord = (decimal X, decimal Y, decimal Z);
using Axis = (long Position, long Velocity);

public static class Day24Solver
{
    public static int PuzzleOne(string input, long min = 200000000000000, long max = 400000000000000)
    {
        var hailstones = input
            .Split(Environment.NewLine)
            .Select(x => new Day24Hailstone(x))
            .ToArray();

        var intersects = 0;

        for (var i = 0; i < hailstones.Length; i++)
        {
            for (var j = i + 1; j < hailstones.Length; j++)
            {
                if (Intersects(hailstones[i], hailstones[j]))
                {
                    intersects++;
                }
            }
        }

        return intersects;

        bool Intersects(Day24Hailstone a, Day24Hailstone b)
        {
            var a1 = a.Position;
            var a2 = GetEnd(a);
            var b1 = b.Position;
            var b2 = GetEnd(b);

            var determinant =
                decimal.ToDouble(a1.X - a2.X) * decimal.ToDouble(b1.Y - b2.Y) - decimal.ToDouble(a1.Y - a2.Y) * decimal.ToDouble(b1.X - b2.X);
            if (determinant == 0)
            {
                return false;
            }

            var point = (X: 0M, Y: 0M);

            var t = (decimal.ToDouble(a1.X - b1.X) * decimal.ToDouble(b1.Y - b2.Y) - decimal.ToDouble(a1.Y - b1.Y) * decimal.ToDouble(b1.X - b2.X)) / determinant;
            var u = (decimal.ToDouble(a1.X - b1.X) * decimal.ToDouble(a1.Y - a2.Y) - decimal.ToDouble(a1.Y - b1.Y) * decimal.ToDouble(a1.X - a2.X)) / determinant;

            if (t is >= 0 and <= 1 && u is >= 0 and <= 1)
            {
                point = GetPoint(a1, a2, (decimal)t);
            }
            else
            {
                return false;
            }

            var output = IsInTestArea(point.X) && IsInTestArea(point.Y);
            return output;

            (decimal X, decimal Y) GetPoint(Coord a, Coord b, decimal factor)
            {
                return (GetValue(a.X, b.X), GetValue(a.Y, b.Y));

                decimal GetValue(decimal first, decimal second) => first + factor * (second - first);
            }

            bool IsInTestArea(decimal value) => value >= min && value <= max;
        }

        Coord GetEnd(Day24Hailstone hailstone)
        {
            var time = Math.Min(GetTime(hailstone.X), GetTime(hailstone.Y));

            return (GetEnd(hailstone.X), GetEnd(hailstone.Y), GetEnd(hailstone.Z));

            decimal GetTime(Axis axis)
            {
                var sign = Math.Sign(axis.Velocity);
                if (sign == 0)
                {
                    return decimal.MaxValue;
                }
                else if (sign == 1)
                {
                    var distance = max - axis.Position;
                    return Math.Max(0, distance / axis.Velocity);
                }
                else
                {
                    var distance = axis.Position - min;
                    return Math.Max(0, distance / -axis.Velocity);
                }
            }

            decimal GetEnd(Axis axis) => axis.Position + axis.Velocity * time;
        }
    }

    public static long PuzzleTwo(string input)
    {
        var hailstones = input
            .Split(Environment.NewLine)
            .Select(x => new Day24Hailstone(x))
            .ToArray();

        var results = new HashSet<(double Xp, int X, double Yp, int Y, double Zp, int Z)>();

        foreach (var x in GetPotentialVelocities(h => h.X))
        {
            foreach (var y in GetPotentialVelocities(h => h.Y))
            {
                foreach (var z in GetPotentialVelocities(h => h.Z))
                {
                    var filtered = hailstones
                        .Where(h => h.X.Velocity != x && h.Y.Velocity != y && h.Z.Velocity != z)
                        .ToArray();
                    var a = filtered[0];
                    var b = filtered[1];
                    var am = Qm(a);
                    var bm = Qm(b);
                    var ac = Qc(a);
                    var bc = Qc(b);

                    var rx = (ac - bc) / (am - bm);

                    var ry = (rx - a.X.Position) * am + a.Y.Position;

                    var t = GetTime(rx, x, a.X);
                    var rz = a.Z.Position + (a.Z.Velocity - z) * t;

                    if (GetTime(rx, x, a.X) == GetTime(ry, y, a.Y)
                        && GetTime(rx, x, a.X) == GetTime(rz, z, a.Z))
                    {
                        results.Add((rx, x, ry, y, rz, z));
                    }

                    double Qm(Day24Hailstone h) => 1D * (h.Y.Velocity - y) / (h.X.Velocity - x);

                    double Qc(Day24Hailstone h) => h.X.Position * Qm(h) - h.Y.Position;

                }
            }
        }

        foreach (var hailstone in hailstones)
        {
            if (results.Count == 1)
            {
                break;
            }

            foreach (var result in results.ToList())
            {
                var (rx, x, ry, y, rz, z) = result;
                if (x == hailstone.X.Velocity
                    || y == hailstone.Y.Velocity
                    || z == hailstone.Z.Velocity)
                {
                    continue;
                }
                if (GetTime(rx, x, hailstone.X) != GetTime(ry, y, hailstone.Y)
                    || GetTime(rx, x, hailstone.X) != GetTime(rz, z, hailstone.Z))
                {
                    results.Remove(result);
                }
            }
        }

        var first = results.Single();
        return (long)(first.Xp + first.Yp + first.Zp);

        long GetTime(double position, double velocity, Axis axis) => (long)Math.Round((position - axis.Position) / (axis.Velocity - velocity));

        IEnumerable<int> GetPotentialVelocities(Func<Day24Hailstone, Axis> selector)
        {
            var groups = hailstones
                .Select(selector)
                .GroupBy(axis => axis.Velocity);

            var velocities = new HashSet<int>();
            var init = false;
            foreach (var group in groups)
            {
                var list = group.ToList();
                if (list.Count == 1)
                {
                    continue;
                }

                for (var i = 0; i < list.Count - 1; i++)
                {
                    for (var j = i + 1; j < list.Count; j++)
                    {
                        var distance = list[i].Position - list[j].Position;
                        var set = Enumerable
                            .Range(-1000, 2000)
                            .Where(x => x != group.Key && distance % (x - group.Key) == 0)
                            .ToHashSet();

                        if (init)
                        {
                            velocities.IntersectWith(set);
                        }
                        else
                        {
                            velocities = set;
                            init = true;
                        }
                    }
                }
            }

            return velocities;
        }
    }
}