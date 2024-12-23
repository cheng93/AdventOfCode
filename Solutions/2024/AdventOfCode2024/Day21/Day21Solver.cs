namespace AdventOfCode2024.Day21;

public static class Day21Solver
{
    public static long PuzzleOne(string input) => Solve(input, 2);

    public static long PuzzleTwo(string input) => Solve(input, 25);

    private static long Solve(string input, int directional)
    {
        var cache = new Dictionary<CacheKey, long>();
        return input
            .Split(Environment.NewLine)
            .Select(x => Sequence(
                x,
                [
                    Day21Keypad.Numeric(),
                    ..Enumerable
                        .Range(0, directional)
                        .Select(x => Day21Keypad.Directional())
                ]) * long.Parse(x[..^1]))
            .Sum();

        long Sequence(string code, ICollection<Day21Keypad> keypads)
        {
            var cacheKey = new CacheKey(code, keypads.Count);
            if (cache.TryGetValue(cacheKey, out var cached))
            {
                return cached;
            }
            if (keypads.Count == 0)
            {
                return code.Length;
            }
            cached = code
                .Select(x => keypads
                    .First()
                    .Goto(x)
                    .Select(x => Sequence(x, keypads.Skip(1).ToList()))
                    .Min())
                .Sum();
            cache.Add(cacheKey, cached);
            return cached;
        }
    }

    private record CacheKey(string Code, int Keypads);
}