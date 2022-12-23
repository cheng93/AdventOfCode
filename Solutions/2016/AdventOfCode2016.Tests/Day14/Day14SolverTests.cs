namespace AdventOfCode2016.Tests.Day14;

using AdventOfCode2016.Day14;
using Xunit;

public class Day14SolverTests
{
    [Theory]
    [InlineData(22728, "abc")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day14Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(22551, "abc")]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day14Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}