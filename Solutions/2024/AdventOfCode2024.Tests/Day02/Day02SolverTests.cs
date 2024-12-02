namespace AdventOfCode2024.Day02.Tests;

public class Day02SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    2,
                    """
                    7 6 4 2 1
                    1 2 7 8 9
                    9 7 6 2 1
                    1 3 2 4 5
                    8 6 4 4 1
                    1 3 6 7 9
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day02Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    4,
                    """
                    7 6 4 2 1
                    1 2 7 8 9
                    9 7 6 2 1
                    1 3 2 4 5
                    8 6 4 4 1
                    1 3 6 7 9
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day02Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}