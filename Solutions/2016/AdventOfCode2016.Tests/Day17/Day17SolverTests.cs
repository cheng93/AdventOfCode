namespace AdventOfCode2016.Tests.Day17;

using AdventOfCode2016.Day17;
using Xunit;

public class Day17SolverTests
{
    [Theory]
    [InlineData("DDRRRD", "ihgpwlah")]
    [InlineData("DDUDRLRRUDRD", "kglvqrro")]
    [InlineData("DRURDRUDDLLDLUURRDULRLDUUDDDRR", "ulqzkmiv")]
    public void PuzzleOne(string expected, string input)
    {
        var actual = Day17Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(370, "ihgpwlah")]
    [InlineData(492, "kglvqrro")]
    [InlineData(830, "ulqzkmiv")]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day17Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}