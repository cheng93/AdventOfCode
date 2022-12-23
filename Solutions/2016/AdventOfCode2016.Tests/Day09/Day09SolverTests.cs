namespace AdventOfCode2016.Tests.Day09;

using AdventOfCode2016.Day09;
using Xunit;

public class Day09SolverTests
{
    [Theory]
    [InlineData(6, "ADVENT")]
    [InlineData(7, "A(1x5)BC")]
    [InlineData(9, "(3x3)XYZ")]
    [InlineData(11, "A(2x2)BCD(2x2)EFG")]
    [InlineData(6, "(6x1)(1x3)A")]
    [InlineData(18, "X(8x2)(3x3)ABCY")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day09Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(6, "ADVENT")]
    [InlineData(7, "A(1x5)BC")]
    [InlineData(9, "(3x3)XYZ")]
    [InlineData(11, "A(2x2)BCD(2x2)EFG")]
    [InlineData(3, "(6x1)(1x3)A")]
    [InlineData(20, "X(8x2)(3x3)ABCY")]
    [InlineData(241920, "(27x12)(20x12)(13x14)(7x10)(1x12)A")]
    [InlineData(445, "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN")]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day09Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}