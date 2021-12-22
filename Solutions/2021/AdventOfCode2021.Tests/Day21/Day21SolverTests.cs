namespace AdventOfCode2021.Day21.Tests;

public class Day21SolverTests
{
    [Theory]
    [InlineData(739785, 4, 8)]
    public void PuzzleOne(int expected, params int[] input)
    {
        var actual = Day21Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(444356092776315, 4, 8)]
    public void PuzzleTwo(long expected, params int[] input)
    {
        var actual = Day21Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}