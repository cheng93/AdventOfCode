namespace AdventOfCode2021.Day02.Tests;

public class Day02SolverTests
{
    [Theory]
    [InlineData(150, "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2")]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day02Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(900, "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2")]
    public void PuzzleTwo(long expected, params string[] input)
    {
        var actual = Day02Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}