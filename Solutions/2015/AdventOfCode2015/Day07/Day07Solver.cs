namespace AdventOfCode2015.Day07;

public static class Day07Solver
{
    public static int PuzzleOne(string input, string wire = "a") => Solve(input, wire).First();

    public static int PuzzleTwo(string input) => Solve(input, "a").Last();

    private static IEnumerable<int> Solve(string input, string wire)
    {
        var gates = input
            .Split(Environment.NewLine)
            .Select(x => new Day07Gate(x))
            .ToArray();

        var from = gates.ToDictionary(x => x.Output, x => x);
        var cache = new Dictionary<string, int>();

        var found = Recurse(wire);
        yield return found;

        cache.Clear();
        cache.Add("b", found);

        yield return Recurse(wire);

        int Recurse(string find)
        {
            if (cache.TryGetValue(find, out var cached))
            {
                return cached;
            }

            var gate = from[find];

            foreach (var input in gate.Inputs)
            {
                Recurse(input);
            }

            cache[find] = gate.Run(cache);
            return cache[find];
        }
    }
}