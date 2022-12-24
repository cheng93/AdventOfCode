namespace AdventOfCode2016.Tests.Day15;

using AdventOfCode2016.Day15;
using Xunit;

public class Day15SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    5,
                    new []
                    {
                        "Disc #1 has 5 positions; at time=0, it is at position 4.",
                        "Disc #2 has 2 positions; at time=0, it is at position 1.",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day15Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}