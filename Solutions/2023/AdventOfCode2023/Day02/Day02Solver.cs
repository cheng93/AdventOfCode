namespace AdventOfCode2023.Day02;

public static class Day02Solver
{
    public static int PuzzleOne(string input) => input
            .Split(Environment.NewLine)
            .Select(line => new Day02Game(line))
            .Select(game => (
                Id: game.Id,
                Red: game.Sets.Max(x => x.Red),
                Green: game.Sets.Max(x => x.Green),
                Blue: game.Sets.Max(x => x.Blue)))
            .Where(max => max.Red <= 12
                && max.Green <= 13
                && max.Blue <= 14)
            .Sum(max => max.Id);

    public static int PuzzleTwo(string input) => input
            .Split(Environment.NewLine)
            .Select(line => new Day02Game(line))
            .Select(game => (
                Red: game.Sets.Max(x => x.Red),
                Green: game.Sets.Max(x => x.Green),
                Blue: game.Sets.Max(x => x.Blue)))
            .Sum(max => max.Red * max.Green * max.Blue);
}