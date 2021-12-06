namespace AdventOfCode2021.Day06.Tests;

public class Day06SolverTests
{
    [Theory]
    [InlineData(5934, 3, 4, 3, 1, 2)]
    public void PuzzleOne(long expected, params int[] input)
    {
        var actual = Day06Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(26984457539, 3, 4, 3, 1, 2)]
    public void PuzzleTwo(long expected, params int[] input)
    {
        var actual = Day06Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}