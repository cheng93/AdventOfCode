namespace AdventOfCode2022.Day04.Tests;

public class Day04SolverTests
{
    [Theory]
    [InlineData(2, "2-4,6-8", "2-3,4-5", "5-7,7-9", "2-8,3-7", "6-6,4-6", "2-6,4-8")]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day04Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4, "2-4,6-8", "2-3,4-5", "5-7,7-9", "2-8,3-7", "6-6,4-6", "2-6,4-8")]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day04Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}