namespace AdventOfCode2015.Day10.Tests;

public class Day10SolverTests
{
    public static TheoryData<int, string, int> PuzzleOneTestData
        = new TheoryData<int, string, int>()
        {
                { 6, "1", 5 },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int iterations)
    {
        var actual = Day10Solver.PuzzleOne(input, iterations);

        Assert.Equal(expected, actual);
    }
}