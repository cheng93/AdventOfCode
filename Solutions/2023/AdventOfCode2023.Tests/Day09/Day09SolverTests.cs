namespace AdventOfCode2023.Day09.Tests;

public class Day09SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    114,
                    """
                    0 3 6 9 12 15
                    1 3 6 10 15 21
                    10 13 16 21 30 45
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day09Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    2,
                    """
                    0 3 6 9 12 15
                    1 3 6 10 15 21
                    10 13 16 21 30 45
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day09Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}