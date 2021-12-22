namespace AdventOfCode2021.Day20;

public static class Day20Solver
{
    public static int PuzzleOne(string input)
        => Solve(input)
            .Skip(2)
            .First()
            .LightPixels
            .Count;

    public static int PuzzleTwo(string input)
        => Solve(input)
            .Skip(50)
            .First()
            .LightPixels
            .Count;

    private static IEnumerable<Day20Image> Solve(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var algorithm = new Day20Algorithm(splits[0]);
        var image = Day20Image.Create(splits[1]);

        do
        {
            yield return image;
            image = algorithm.Enhance(image);
        }
        while (true);
    }
}