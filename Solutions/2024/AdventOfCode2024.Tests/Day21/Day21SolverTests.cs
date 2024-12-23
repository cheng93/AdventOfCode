namespace AdventOfCode2024.Day21.Tests;

public class Day21SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    126384,
                    """
                    029A
                    980A
                    179A
                    456A
                    379A
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day21Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}