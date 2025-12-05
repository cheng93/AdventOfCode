namespace AdventOfCode2025.Day05.Tests;

public class Day05SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new()
        {
            {
                3,
                """
                3-5
                10-14
                16-20
                12-18
                
                1
                5
                8
                11
                17
                32
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day05Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new()
        {
            {
                14,
                """
                3-5
                10-14
                16-20
                12-18

                1
                5
                8
                11
                17
                32
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day05Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}