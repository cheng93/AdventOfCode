namespace AdventOfCode2022.Day08.Tests;

public class Day08SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    21,
                    new []
                    {
"30373",
"25512",
"65332",
"33549",
"35390",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day08Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
                {
                    8,
                    new []
                    {
"30373",
"25512",
"65332",
"33549",
"35390",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day08Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}