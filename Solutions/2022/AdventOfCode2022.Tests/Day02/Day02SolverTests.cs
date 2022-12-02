namespace AdventOfCode2022.Day02.Tests;

public class Day02SolverTests
{
    [Theory]
    [InlineData(15, "A Y", "B X", "C Z")]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day02Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(12, "A Y", "B X", "C Z")]
    public void PuzzleTwo(long expected, params string[] input)
    {
        var actual = Day02Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}