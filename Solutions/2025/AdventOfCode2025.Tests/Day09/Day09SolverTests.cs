namespace AdventOfCode2025.Day09.Tests;

public class Day09SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new()
        {
            {
                50,
                """
                7,1
                11,1
                11,7
                9,7
                9,5
                2,5
                2,3
                7,3
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day09Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new()
        {
            {
                24,
                """
                7,1
                11,1
                11,7
                9,7
                9,5
                2,5
                2,3
                7,3
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day09Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}