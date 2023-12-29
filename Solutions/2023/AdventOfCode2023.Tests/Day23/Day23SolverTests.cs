namespace AdventOfCode2023.Day23.Tests;

public class Day23SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    94,
                    """
                    #.#####################
                    #.......#########...###
                    #######.#########.#.###
                    ###.....#.>.>.###.#.###
                    ###v#####.#v#.###.#.###
                    ###.>...#.#.#.....#...#
                    ###v###.#.#.#########.#
                    ###...#.#.#.......#...#
                    #####.#.#.#######.#.###
                    #.....#.#.#.......#...#
                    #.#####.#.#.#########v#
                    #.#...#...#...###...>.#
                    #.#.#v#######v###.###v#
                    #...#.>.#...>.>.#.###.#
                    #####v#.#.###v#.#.###.#
                    #.....#...#...#.#.#...#
                    #.#########.###.#.#.###
                    #...###...#...#...#.###
                    ###.###.#.###v#####v###
                    #...#...#.#.>.>.#.>.###
                    #.###.###.#.###.#.#v###
                    #.....###...###...#...#
                    #####################.#
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day23Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    154,
                    """
                    #.#####################
                    #.......#########...###
                    #######.#########.#.###
                    ###.....#.>.>.###.#.###
                    ###v#####.#v#.###.#.###
                    ###.>...#.#.#.....#...#
                    ###v###.#.#.#########.#
                    ###...#.#.#.......#...#
                    #####.#.#.#######.#.###
                    #.....#.#.#.......#...#
                    #.#####.#.#.#########v#
                    #.#...#...#...###...>.#
                    #.#.#v#######v###.###v#
                    #...#.>.#...>.>.#.###.#
                    #####v#.#.###v#.#.###.#
                    #.....#...#...#.#.#...#
                    #.#########.###.#.#.###
                    #...###...#...#...#.###
                    ###.###.#.###v#####v###
                    #...#...#.#.>.>.#.>.###
                    #.###.###.#.###.#.#v###
                    #.....###...###...#...#
                    #####################.#
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day23Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}