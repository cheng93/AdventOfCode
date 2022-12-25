namespace AdventOfCode2016.Tests.Day20;

using AdventOfCode2016.Day20;
using Xunit;

public class Day20SolverTests
{
    public static TheoryData<long, string[]> PuzzleOneTestData
        = new TheoryData<long, string[]>()
        {
                {
                    3,
                    new []
                    {
                        "5-8",
                        "0-2",
                        "4-7"
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(long expected, params string[] input)
    {
        var actual = Day20Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
    public static TheoryData<long, string[]> PuzzleTwoTestData
        = new TheoryData<long, string[]>()
        {
                {
                    2,
                    new []
                    {
                        "5-8",
                        "0-2",
                        "4-7"
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, params string[] input)
    {
        var actual = Day20Solver.PuzzleTwo(input, 9);

        Assert.Equal(expected, actual);
    }
}