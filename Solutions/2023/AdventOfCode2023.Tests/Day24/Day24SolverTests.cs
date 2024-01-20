namespace AdventOfCode2023.Day24.Tests;

public class Day24SolverTests
{
    public static TheoryData<int, string, int, int> PuzzleOneTestData
        = new TheoryData<int, string, int, int>()
        {
                {
                    2,
                    """
                    19, 13, 30 @ -2,  1, -2
                    18, 19, 22 @ -1, -1, -2
                    20, 25, 34 @ -2, -2, -4
                    12, 31, 28 @ -1, -2, -1
                    20, 19, 15 @  1, -5, -3
                    """,
                    7,
                    27
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int min, int max)
    {
        var actual = Day24Solver.PuzzleOne(input, min, max);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    47,
                    """
                    19, 13, 30 @ -2,  1, -2
                    18, 19, 22 @ -1, -1, -2
                    20, 25, 34 @ -2, -2, -4
                    12, 31, 28 @ -1, -2, -1
                    20, 19, 15 @  1, -5, -3
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day24Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}