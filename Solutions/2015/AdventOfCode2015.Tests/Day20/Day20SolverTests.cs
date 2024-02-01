namespace AdventOfCode2015.Day20.Tests;

public class Day20SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    8,
                    """
                    140
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day20Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}