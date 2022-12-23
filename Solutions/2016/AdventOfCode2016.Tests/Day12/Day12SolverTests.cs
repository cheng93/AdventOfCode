namespace AdventOfCode2016.Tests.Day12;

using AdventOfCode2016.Day12;
using Xunit;

public class Day12SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    42,
                    new []
                    {
                        "cpy 41 a",
                        "inc a",
                        "inc a",
                        "dec a",
                        "jnz a 2",
                        "dec a",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day12Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}