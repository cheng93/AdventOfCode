namespace AdventOfCode2023.Day18.Tests;

public class Day18SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    62,
                    """
                    R 6 (#70c710)
                    D 5 (#0dc571)
                    L 2 (#5713f0)
                    D 2 (#d2c081)
                    R 2 (#59c680)
                    D 2 (#411b91)
                    L 5 (#8ceee2)
                    U 2 (#caa173)
                    L 1 (#1b58a2)
                    U 2 (#caa171)
                    R 2 (#7807d2)
                    U 3 (#a77fa3)
                    L 2 (#015232)
                    U 2 (#7a21e3)
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day18Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string> PuzzleTwoTestData
        = new TheoryData<long, string>()
        {
                {
                    952408144115,
                    """
                    R 6 (#70c710)
                    D 5 (#0dc571)
                    L 2 (#5713f0)
                    D 2 (#d2c081)
                    R 2 (#59c680)
                    D 2 (#411b91)
                    L 5 (#8ceee2)
                    U 2 (#caa173)
                    L 1 (#1b58a2)
                    U 2 (#caa171)
                    R 2 (#7807d2)
                    U 3 (#a77fa3)
                    L 2 (#015232)
                    U 2 (#7a21e3)
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day18Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}