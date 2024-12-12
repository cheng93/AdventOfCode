namespace AdventOfCode2024.Day11.Tests;

public class Day11SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    55312,
                    """
                    125 17
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day11Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}