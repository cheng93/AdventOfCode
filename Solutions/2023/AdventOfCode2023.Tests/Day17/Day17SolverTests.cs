namespace AdventOfCode2023.Day17.Tests;

public class Day17SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    102,
                    """
                    2413432311323
                    3215453535623
                    3255245654254
                    3446585845452
                    4546657867536
                    1438598798454
                    4457876987766
                    3637877979653
                    4654967986887
                    4564679986453
                    1224686865563
                    2546548887735
                    4322674655533
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day17Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    94,
                    """
                    2413432311323
                    3215453535623
                    3255245654254
                    3446585845452
                    4546657867536
                    1438598798454
                    4457876987766
                    3637877979653
                    4654967986887
                    4564679986453
                    1224686865563
                    2546548887735
                    4322674655533
                    """
                },
                {
                    71,
                    """
                    111111111111
                    999999999991
                    999999999991
                    999999999991
                    999999999991
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day17Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}