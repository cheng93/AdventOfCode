namespace AdventOfCode2016.Tests.Day16;

using AdventOfCode2016.Day16;
using Xunit;

public class Day16SolverTests
{
    [Theory]
    [InlineData("100", "110010110100", 12)]
    [InlineData("01100", "10000", 20)]
    public void PuzzleOne(string expected, string input, int length)
    {
        var actual = Day16Solver.PuzzleOne(input, length);

        Assert.Equal(expected, actual);
    }
}