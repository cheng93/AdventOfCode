namespace AdventOfCode2015.Day11.Tests;

public class Day11SolverTests
{
    public static TheoryData<string, string> PuzzleOneTestData
        = new TheoryData<string, string>()
        {
            { "abcdffaa", "abcdefgh" },
            { "ghjaabcc", "ghijklmn" },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(string expected, string input)
    {
        var actual = Day11Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}