namespace AdventOfCode2016.Tests.Day18;

using AdventOfCode2016.Day18;
using Xunit;

public class Day18SolverTests
{
    [Theory]
    [InlineData(38, ".^^.^.^^^^")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day18Solver.PuzzleOne(input, 10);

        Assert.Equal(expected, actual);
    }
}