namespace AdventOfCode2022.Day14.Tests;

public class Day14SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
            {
                24,
                new []
                {
                    "498,4 -> 498,6 -> 496,6",
                    "503,4 -> 502,4 -> 502,9 -> 494,9",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day14Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
            {
                93,
                new []
                {
                    "498,4 -> 498,6 -> 496,6",
                    "503,4 -> 502,4 -> 502,9 -> 494,9",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day14Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}