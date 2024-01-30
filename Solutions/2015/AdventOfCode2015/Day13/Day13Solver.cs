using MoreLinq;

namespace AdventOfCode2015.Day13;

public static class Day13Solver
{
    public static int PuzzleOne(string input)
    {
        var happiness = input
            .Split(Environment.NewLine)
            .Select(x => new Day13Happiness(x))
            .ToArray();
        var lookup = happiness
            .GroupBy(x => x.Host)
            .ToDictionary(
                x => x.Key,
                x => x.ToDictionary(y => y.Neighbour, y => y.Value));
        var attendees = lookup.Keys.ToArray();

        var max = int.MinValue;

        var permutations = Enumerable
            .Range(0, attendees.Length)
            .Permutations()
            .Where(x => x[0] == 0);

        foreach (var permutation in permutations)
        {
            var sum = 0;
            for (var i = 0; i < permutation.Count; i++)
            {
                var host = attendees[permutation[i]];
                var neighbour = attendees[permutation[(i + 1) % attendees.Length]];
                sum += lookup[host][neighbour];
                sum += lookup[neighbour][host];
            }
            max = int.Max(max, sum);
        }

        return max;
    }

    public static int PuzzleTwo(string input)
    {
        var happiness = input
            .Split(Environment.NewLine)
            .Select(x => new Day13Happiness(x))
            .ToArray();
        var lookup = happiness
            .GroupBy(x => x.Host)
            .ToDictionary(
                x => x.Key,
                x => x.ToDictionary(y => y.Neighbour, y => y.Value));

        var attendees = lookup.Keys.ToArray();

        var max = int.MinValue;

        var permutations = Enumerable
            .Range(0, attendees.Length)
            .Permutations();

        foreach (var permutation in permutations)
        {
            var sum = 0;
            for (var i = 0; i < permutation.Count - 1; i++)
            {
                var host = attendees[permutation[i]];
                var neighbour = attendees[permutation[i + 1]];
                sum += lookup[host][neighbour];
                sum += lookup[neighbour][host];
            }
            max = int.Max(max, sum);
        }

        return max;
    }
}