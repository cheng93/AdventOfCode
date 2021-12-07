namespace AdventOfCode2021.Day07.Tests;

public class Day07SolverTests
{
    [Theory]
    [InlineData(37, 16, 1, 2, 0, 4, 2, 7, 1, 2, 14)]
    public void PuzzleOne(int expected, params int[] input)
    {
        var actual = Day07Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(168, 16, 1, 2, 0, 4, 2, 7, 1, 2, 14)]
    public void PuzzleTwo(int expected, params int[] input)
    {
        var actual = Day07Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}