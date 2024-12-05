namespace AdventOfCode2024.Day05;

public static class Day05Solver
{
    public static int PuzzleOne(string input) => Solve(input, true);

    public static int PuzzleTwo(string input) => Solve(input, false);

    private static int Solve(string input, bool isValid)
    {
        var splits = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .ToArray();

        var rules = splits[0]
            .Split(Environment.NewLine)
            .Select(x => new Day05Rule(x));
        var updates = splits[1]
            .Split(Environment.NewLine)
            .Select(x => x
                .Split(',')
                .Select(int.Parse)
                .ToArray());

        var before = new Dictionary<int, HashSet<int>>();

        foreach (var rule in rules)
        {
            if (!before.TryGetValue(rule.Before, out var b))
            {
                b = new();
                before[rule.Before] = b;
            }
            b.Add(rule.After);
        }

        return updates
            .Where(x => IsValid(x) == isValid)
            .Select(x => x
                .OrderBy(y => y, new Day05Comparer(before))
                .ToArray())
            .Sum(x => x[x.Length / 2]);

        bool IsValid(IEnumerable<int> update)
        {
            var seen = new HashSet<int>();
            foreach (var page in update)
            {
                if (before.TryGetValue(page, out var b) && b.Overlaps(seen))
                {
                    return false;
                }
                seen.Add(page);
            }

            return true;
        }
    }
}