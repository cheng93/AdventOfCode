namespace AdventOfCode2015.Day06.Tests;

public class Day06SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    998996,
                    """
                    turn on 0,0 through 999,999
                    toggle 0,0 through 999,0
                    turn off 499,499 through 500,500
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
                { 1, ")" },
                { 5, "()())" },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day06Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}