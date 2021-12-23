namespace AdventOfCode2021.Day22;

public static class Day22Solver
{
    public static long PuzzleOne(IEnumerable<string> input)
        => Solve(input)
            .Last(x => x.Initializing)
            .Cuboids
            .Sum(x => x.Volume);

    public static long PuzzleTwo(IEnumerable<string> input)
        => Solve(input)
            .Last()
            .Cuboids
            .Sum(x => x.Volume);

    private static IEnumerable<(IEnumerable<Day22Cuboid> Cuboids, bool Initializing)> Solve(IEnumerable<string> input)
    {
        var steps = input.Select(x => new Day22Step(x));
        var cuboids = new List<Day22Cuboid>();

        foreach (var step in steps)
        {
            cuboids = cuboids
                .SelectMany(x => step.Cuboid.Intersect(x))
                .ToList();

            if (step.On)
            {
                cuboids.Add(step.Cuboid);
            }

            yield return (cuboids, step.Initialization);
        }
    }
}