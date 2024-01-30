namespace AdventOfCode2015.Day15.Tests;

public class Day15SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    62842880,
                    """
                    Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
                    Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day15Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    57600000,
                    """
                    Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
                    Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day15Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}