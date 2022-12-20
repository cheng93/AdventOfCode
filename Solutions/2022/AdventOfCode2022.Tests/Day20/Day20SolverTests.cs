namespace AdventOfCode2022.Day20.Tests;

public class Day20SolverTests
{
    public static TheoryData<long, int[]> PuzzleOneTestData
        = new TheoryData<long, int[]>()
        {
            {
                3,
                new []
                {
                    1,
                    2,
                    -3,
                    3,
                    -2,
                    0,
                    4
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(long expected, params int[] input)
    {
        var actual = Day20Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, int[]> PuzzleTwoTestData
        = new TheoryData<long, int[]>()
        {
            {
                1623178306,
                new []
                {
                    1,
                    2,
                    -3,
                    3,
                    -2,
                    0,
                    4
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, params int[] input)
    {
        var actual = Day20Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}