namespace AdventOfCode2015.Day03.Tests;

public class Day03SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                { 2, ">" },
                { 4, "^>v<" },
                { 2, "^v^v^v^v^v" },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day03Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                { 3, "^v" },
                { 3, "^>v<" },
                { 11, "^v^v^v^v^v" },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day03Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}