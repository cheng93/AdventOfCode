namespace AdventOfCode2022.Day17.Tests;

public class Day17SolverTests
{
    [Theory]
    [InlineData(3068, ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day17Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1514285714288, ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>")]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day17Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}