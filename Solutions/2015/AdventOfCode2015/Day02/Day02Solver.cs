namespace AdventOfCode2015.Day02;

public static class Day02Solver
{
    public static int PuzzleOne(string input)
        => input
            .Split(Environment.NewLine)
            .Select(x => new Day02Dimension(x))
            .Sum(x => x.SurfaceArea + x.SmallestArea);

    public static int PuzzleTwo(string input)
        => input
            .Split(Environment.NewLine)
            .Select(x => new Day02Dimension(x))
            .Sum(x => x.Volume + x.SmallestPerimeter);
}