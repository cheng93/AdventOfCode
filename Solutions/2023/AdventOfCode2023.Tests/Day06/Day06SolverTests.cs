namespace AdventOfCode2023.Day06.Tests;

public class Day06SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    288,
                    """
                    Time:      7  15   30
                    Distance:  9  40  200
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day06Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    71503,
                    """
                    Time:      7  15   30
                    Distance:  9  40  200
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day06Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}