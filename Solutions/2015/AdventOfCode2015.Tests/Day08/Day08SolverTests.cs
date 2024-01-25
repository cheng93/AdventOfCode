namespace AdventOfCode2015.Day08.Tests;

public class Day08SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    12,
                    """
                    ""
                    "abc"
                    "aaa\"aaa"
                    "\x27"
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day08Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    19,
                    """
                    ""
                    "abc"
                    "aaa\"aaa"
                    "\x27"
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day08Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}