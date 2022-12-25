namespace AdventOfCode2016.Tests.Day19;

using AdventOfCode2016.Day19;
using Xunit;

public class Day19SolverTests
{
    [Theory]
    [InlineData(3, 5)]
    public void PuzzleOne(int expected, int input)
    {
        var actual = Day19Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2, 5)]
    public void PuzzleTwo(int expected, int input)
    {
        var actual = Day19Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}