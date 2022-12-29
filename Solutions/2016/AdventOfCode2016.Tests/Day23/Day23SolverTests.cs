namespace AdventOfCode2016.Tests.Day23;

using AdventOfCode2016.Day23;
using Xunit;

public class Day23SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    3,
                    new []
                    {
                        "cpy 2 a",
                        "tgl a",
                        "tgl a",
                        "tgl a",
                        "cpy 1 a",
                        "dec a",
                        "dec a",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day23Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}