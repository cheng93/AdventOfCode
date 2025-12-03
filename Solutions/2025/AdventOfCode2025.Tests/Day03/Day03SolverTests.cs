namespace AdventOfCode2025.Day03.Tests;

public class Day03SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new()
        {
            {
                357,
                """
                987654321111111
                811111111111119
                234234234234278
                818181911112111
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day03Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string> PuzzleTwoTestData
        = new()
        {
            {
                3121910778619,
                """
                987654321111111
                811111111111119
                234234234234278
                818181911112111
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day03Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}