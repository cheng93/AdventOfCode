namespace AdventOfCode2024.Day01.Tests;

public class Day01SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    11,
                    """
                    3   4
                    4   3
                    2   5
                    1   3
                    3   9
                    3   3
                    """
                }
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
                {
                    31,
                    """
                    3   4
                    4   3
                    2   5
                    1   3
                    3   9
                    3   3
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day01Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}