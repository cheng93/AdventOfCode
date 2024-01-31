namespace AdventOfCode2015.Day17.Tests;

public class Day17SolverTests
{
    public static TheoryData<int, string, int> PuzzleOneTestData
        = new TheoryData<int, string, int>()
        {
                {
                    4,
                    """
                    20
                    15
                    10
                    5
                    5
                    """,
                    25
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int liters)
    {
        var actual = Day17Solver.PuzzleOne(input, liters);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string, int> PuzzleTwoTestData
        = new TheoryData<int, string, int>()
        {
                {
                    3,
                    """
                    20
                    15
                    10
                    5
                    5
                    """,
                    25
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input, int liters)
    {
        var actual = Day17Solver.PuzzleTwo(input, liters);

        Assert.Equal(expected, actual);
    }
}