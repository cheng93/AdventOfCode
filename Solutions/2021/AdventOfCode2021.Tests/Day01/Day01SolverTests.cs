namespace AdventOfCode2021.Day01.Tests;

public class Day01SolverTests
{
    [Theory]
    [InlineData(7, 199, 200, 208, 210, 200, 207, 240, 269, 260, 263)]
    public void PuzzleOne(int expected, params int[] input)
    {
        var actual = Day01Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(5, 199, 200, 208, 210, 200, 207, 240, 269, 260, 263)]
    public void PuzzleTwo(int expected, params int[] input)
    {
        var actual = Day01Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}