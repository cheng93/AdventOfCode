namespace AdventOfCode2023.Day13;

public static class Day13Solver
{
    public static int PuzzleOne(string input)
    {
        var patterns = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => new Day13Pattern(x))
            .ToArray();

        var sum = 0;

        foreach (var pattern in patterns)
        {
            var xLength = pattern.Lines[0].Length;
            var yLength = pattern.Lines.Length;
            sum += pattern
                .ScanLeft()
                .LastOrDefault(x => x.Initial == x.Reflected)
                .Initial
                ?.Split(Environment.NewLine)[0].Length ?? 0;
            sum += xLength - (pattern
                .ScanRight()
                .LastOrDefault(x => x.Initial == x.Reflected)
                .Initial
                ?.Split(Environment.NewLine)[0].Length ?? xLength);
            sum += (pattern
                .ScanDown()
                .LastOrDefault(x => x.Initial == x.Reflected)
                .Initial
                ?.Split(Environment.NewLine).Length ?? 0) * 100;
            sum += (yLength - (pattern
                .ScanUp()
                .LastOrDefault(x => x.Initial == x.Reflected)
                .Initial
                ?.Split(Environment.NewLine).Length ?? yLength)) * 100;
        }

        return sum;
    }

    public static int PuzzleTwo(string input)
    {
        var patterns = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => new Day13Pattern(x))
            .ToArray();

        var sum = 0;

        foreach (var pattern in patterns)
        {
            var xLength = pattern.Lines[0].Length;
            var yLength = pattern.Lines.Length;
            sum += pattern
                .ScanLeft()
                .LastOrDefault(x => x.Initial
                    .Zip(x.Reflected, (a, b) => a != b)
                    .Count(x => x) == 1)
                .Initial
                ?.Split(Environment.NewLine)[0].Length ?? 0;
            sum += xLength - (pattern
                .ScanRight()
                .LastOrDefault(x => x.Initial
                    .Zip(x.Reflected, (a, b) => a != b)
                    .Count(x => x) == 1)
                .Initial
                ?.Split(Environment.NewLine)[0].Length ?? xLength);
            sum += (pattern
                .ScanDown()
                .LastOrDefault(x => x.Initial
                    .Zip(x.Reflected, (a, b) => a != b)
                    .Count(x => x) == 1)
                .Initial
                ?.Split(Environment.NewLine).Length ?? 0) * 100;
            sum += (yLength - (pattern
                .ScanUp()
                .LastOrDefault(x => x.Initial
                    .Zip(x.Reflected, (a, b) => a != b)
                    .Count(x => x) == 1)
                .Initial
                ?.Split(Environment.NewLine).Length ?? yLength)) * 100;
        }

        return sum;
    }
}