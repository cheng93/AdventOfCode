namespace AdventOfCode2021.Day17.Tests;

public class Day17SolverTests
{
    [Theory]
    [InlineData(45, "target area: x=20..30, y=-10..-5")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day17Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(112, "target area: x=20..30, y=-10..-5")]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day17Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}