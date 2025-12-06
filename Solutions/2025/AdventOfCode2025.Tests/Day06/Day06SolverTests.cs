namespace AdventOfCode2025.Day06.Tests;

public class Day06SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new()
        {
            {
                4277556,
                """
                123 328  51 64 
                 45 64  387 23 
                  6 98  215 314
                *   +   *   +  
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day06Solver.PuzzleOne(input, 3);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new()
        {
            {
                3263827,
                """
                123 328  51 64 
                 45 64  387 23 
                  6 98  215 314
                *   +   *   +  
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day06Solver.PuzzleTwo(input, 3);

        Assert.Equal(expected, actual);
    }
}