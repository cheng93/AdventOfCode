namespace AdventOfCode2015.Day23.Tests;

public class Day23SolverTests
{
    public static TheoryData<int, string, int> PuzzleOneTestData
        = new TheoryData<int, string, int>()
        {
                {
                    2,
                    """
                    inc a
                    jio a, +2
                    tpl a
                    inc a
                    """,
                    0
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int register)
    {
        var actual = Day23Solver.PuzzleOne(input, register);

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
        var actual = Day23Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}