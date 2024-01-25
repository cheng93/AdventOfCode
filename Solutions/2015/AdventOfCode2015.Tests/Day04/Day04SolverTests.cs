namespace AdventOfCode2015.Day04.Tests;

public class Day04SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                { 609043, "abcdef" },
                { 1048970, "pqrstuv" },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day04Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}