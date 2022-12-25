namespace AdventOfCode2016.Tests.Day21;

using AdventOfCode2016.Day21;
using Xunit;

public class Day21SolverTests
{
    public static TheoryData<string, string[]> PuzzleOneTestData
        = new TheoryData<string, string[]>()
        {
                {
                    "decab",
                    new []
                    {
                        "swap position 4 with position 0",
                        "swap letter d with letter b",
                        "reverse positions 0 through 4",
                        "rotate left 1 step",
                        "move position 1 to position 4",
                        "move position 3 to position 0",
                        "rotate based on position of letter b",
                        "rotate based on position of letter d"
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(string expected, params string[] input)
    {
        var actual = Day21Solver.PuzzleOne(input, "abcde");

        Assert.Equal(expected, actual);
    }
}