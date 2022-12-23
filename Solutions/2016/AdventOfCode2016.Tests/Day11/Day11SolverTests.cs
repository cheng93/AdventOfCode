namespace AdventOfCode2016.Tests.Day11;

using AdventOfCode2016.Day11;
using Xunit;

public class Day11SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    11,
                    new []
                    {
                        "The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.",
                        "The second floor contains a hydrogen generator.",
                        "The third floor contains a lithium generator.",
                        "The fourth floor contains nothing relevant.",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day11Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}