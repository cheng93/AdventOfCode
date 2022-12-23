namespace AdventOfCode2016.Tests.Day10;

using AdventOfCode2016.Day10;
using Xunit;

public class Day10SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    2,
                    new []
                    {
                        "value 5 goes to bot 2",
                        "bot 2 gives low to bot 1 and high to bot 0",
                        "value 3 goes to bot 1",
                        "bot 1 gives low to output 1 and high to bot 0",
                        "bot 0 gives low to output 2 and high to output 0",
                        "value 2 goes to bot 2",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day10Solver.PuzzleOne(input, 5, 2);

        Assert.Equal(expected, actual);
    }
    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
                {
                    30,
                    new []
                    {
                        "value 5 goes to bot 2",
                        "bot 2 gives low to bot 1 and high to bot 0",
                        "value 3 goes to bot 1",
                        "bot 1 gives low to output 1 and high to bot 0",
                        "bot 0 gives low to output 2 and high to output 0",
                        "value 2 goes to bot 2",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day10Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}