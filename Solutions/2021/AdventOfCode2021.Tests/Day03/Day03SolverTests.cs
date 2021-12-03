namespace AdventOfCode2021.Day03.Tests;

public class Day03SolverTests
{
    [Theory]
    [InlineData(198, "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010")]
    public void PuzzleOne(long expected, params string[] input)
    {
        var actual = Day03Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(230, "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010")]
    public void PuzzleTwo(long expected, params string[] input)
    {
        var actual = Day03Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}