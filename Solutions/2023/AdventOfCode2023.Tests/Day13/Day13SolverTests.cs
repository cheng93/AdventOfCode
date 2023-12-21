namespace AdventOfCode2023.Day13.Tests;

public class Day13SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    405,
                    """
                    #.##..##.
                    ..#.##.#.
                    ##......#
                    ##......#
                    ..#.##.#.
                    ..##..##.
                    #.#.##.#.

                    #...##..#
                    #....#..#
                    ..##..###
                    #####.##.
                    #####.##.
                    ..##..###
                    #....#..#
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day13Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    400,
                    """
                    #.##..##.
                    ..#.##.#.
                    ##......#
                    ##......#
                    ..#.##.#.
                    ..##..##.
                    #.#.##.#.

                    #...##..#
                    #....#..#
                    ..##..###
                    #####.##.
                    #####.##.
                    ..##..###
                    #....#..#
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day13Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}