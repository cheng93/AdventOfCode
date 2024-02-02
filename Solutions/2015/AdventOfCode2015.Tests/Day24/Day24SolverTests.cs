namespace AdventOfCode2015.Day24.Tests;

public class Day24SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    99,
                    """
                    1
                    2
                    3
                    4
                    5
                    7
                    8
                    9
                    10
                    11
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day24Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    44,
                    """
                    1
                    2
                    3
                    4
                    5
                    7
                    8
                    9
                    10
                    11
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