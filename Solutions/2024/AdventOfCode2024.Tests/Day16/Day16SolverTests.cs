namespace AdventOfCode2024.Day16.Tests;

public class Day16SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    7036,
                    """
                    ###############
                    #.......#....E#
                    #.#.###.#.###.#
                    #.....#.#...#.#
                    #.###.#####.#.#
                    #.#.#.......#.#
                    #.#.#####.###.#
                    #...........#.#
                    ###.#.#####.#.#
                    #...#.....#.#.#
                    #.#.#.###.#.#.#
                    #.....#...#.#.#
                    #.###.#.#.#.#.#
                    #S..#.....#...#
                    ###############
                    """
                },
                {
                    11048,
                    """
                    #################
                    #...#...#...#..E#
                    #.#.#.#.#.#.#.#.#
                    #.#.#.#...#...#.#
                    #.#.#.#.###.#.#.#
                    #...#.#.#.....#.#
                    #.#.#.#.#.#####.#
                    #.#...#.#.#.....#
                    #.#.#####.#.###.#
                    #.#.#.......#...#
                    #.#.###.#####.###
                    #.#.#...#.....#.#
                    #.#.#.#####.###.#
                    #.#.#.........#.#
                    #.#.#.#########.#
                    #S#.............#
                    #################
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day16Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    45,
                    """
                    ###############
                    #.......#....E#
                    #.#.###.#.###.#
                    #.....#.#...#.#
                    #.###.#####.#.#
                    #.#.#.......#.#
                    #.#.#####.###.#
                    #...........#.#
                    ###.#.#####.#.#
                    #...#.....#.#.#
                    #.#.#.###.#.#.#
                    #.....#...#.#.#
                    #.###.#.#.#.#.#
                    #S..#.....#...#
                    ###############
                    """
                },
                {
                    64,
                    """
                    #################
                    #...#...#...#..E#
                    #.#.#.#.#.#.#.#.#
                    #.#.#.#...#...#.#
                    #.#.#.#.###.#.#.#
                    #...#.#.#.....#.#
                    #.#.#.#.#.#####.#
                    #.#...#.#.#.....#
                    #.#.#####.#.###.#
                    #.#.#.......#...#
                    #.#.###.#####.###
                    #.#.#...#.....#.#
                    #.#.#.#####.###.#
                    #.#.#.........#.#
                    #.#.#.#########.#
                    #S#.............#
                    #################
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day16Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}