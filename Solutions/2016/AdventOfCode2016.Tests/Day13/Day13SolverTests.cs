namespace AdventOfCode2016.Tests.Day13;

using AdventOfCode2016.Day13;
using Xunit;

public class Day13SolverTests
{
    [Theory]
    [InlineData(11, 10)]
    public void PuzzleOne(int expected, int input)
    {
        var actual = Day13Solver.PuzzleOne(input, 7, 4);

        Assert.Equal(expected, actual);
    }
}