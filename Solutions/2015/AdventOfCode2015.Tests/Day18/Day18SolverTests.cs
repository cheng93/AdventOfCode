namespace AdventOfCode2015.Day18.Tests;

public class Day18SolverTests
{
    public static TheoryData<int, string, int> PuzzleOneTestData
        = new TheoryData<int, string, int>()
        {
                {
                    4,
                    """
                    .#.#.#
                    ...##.
                    #....#
                    ..#...
                    #.#..#
                    ####..
                    """,
                    4
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int steps)
    {
        var actual = Day18Solver.PuzzleOne(input, steps);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string, int> PuzzleTwoTestData
        = new TheoryData<int, string, int>()
        {
                {
                    17,
                    """
                    .#.#.#
                    ...##.
                    #....#
                    ..#...
                    #.#..#
                    ####..
                    """,
                    5
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input, int steps)
    {
        var actual = Day18Solver.PuzzleTwo(input, steps);

        Assert.Equal(expected, actual);
    }
}