namespace AdventOfCode2021.Day05;

public static class Day05Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var vents = input.Select(x => new Day05Vent(x));

        var counts = new Dictionary<(int X, int Y), int>();

        foreach (var vent in vents)
        {
            if (vent.Start.X == vent.End.X)
            {
                foreach (var number in Sequence(vent.Start.Y, vent.End.Y))
                {
                    counts.Increase((vent.Start.X, number));
                }

            }
            else if (vent.Start.Y == vent.End.Y)
            {
                foreach (var number in Sequence(vent.Start.X, vent.End.X))
                {
                    counts.Increase((number, vent.Start.Y));
                }
            }
        }

        return counts.Values.Count(x => x >= 2);
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var vents = input.Select(x => new Day05Vent(x));

        var counts = new Dictionary<(int X, int Y), int>();

        foreach (var vent in vents)
        {
            if (vent.Start.X == vent.End.X)
            {
                foreach (var number in Sequence(vent.Start.Y, vent.End.Y))
                {
                    counts.Increase((vent.Start.X, number));
                }

            }
            else if (vent.Start.Y == vent.End.Y)
            {
                foreach (var number in Sequence(vent.Start.X, vent.End.X))
                {
                    counts.Increase((number, vent.Start.Y));
                }
            }
            else
            {
                var xSequence = Sequence(vent.Start.X, vent.End.X).ToArray();
                var ySequence = Sequence(vent.Start.Y, vent.End.Y).ToArray();

                for (var i = 0; i < xSequence.Length; i++)
                {
                    counts.Increase((xSequence[i], ySequence[i]));
                }
            }
        }

        return counts.Values.Count(x => x >= 2);
    }

    private static IEnumerable<int> Sequence(int start, int end)
    {
        var sign = Math.Sign(end - start);
        var current = start;
        while (current != end)
        {
            yield return current;
            current += sign * 1;
        }
        yield return end;
    }

    private static void Increase(this Dictionary<(int X, int Y), int> dict, (int X, int Y) key)
    {
        if (dict.TryGetValue(key, out var value))
        {
            dict[key]++;
        }
        else
        {
            dict[key] = 1;
        }
    }
}