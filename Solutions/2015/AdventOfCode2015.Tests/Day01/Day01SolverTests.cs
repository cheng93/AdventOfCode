namespace AdventOfCode2015.Day01.Tests;

public class Day01SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                { 0, "(())" },
                { 0, "()()" },
                { 3, "(((" },
                { 3, "(()(()(" },
                { 3, "))(((((" },
                { -1, "())" },
                { -1, "))(" },
                { -3, ")))" },
                { -3, ")())())" },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day01Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                { 1, ")" },
                { 5, "()())" },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day01Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}