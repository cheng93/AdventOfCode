namespace AdventOfCode2023.Day21.Tests;

public class Day21SolverTests
{
    public static TheoryData<int, string, int> PuzzleOneTestData
        = new TheoryData<int, string, int>()
        {
                {
                    16,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    6
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int steps)
    {
        var actual = Day21Solver.PuzzleOne(input, steps);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string, int> PuzzleTwoTestData
        = new TheoryData<long, string, int>()
        {
                {
                    16,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    6
                },
                {
                    50,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    10
                },
                {
                    1594,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    50
                },
                {
                    6536,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    100
                },
                {
                    167004,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    500
                },
                {
                    668697,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    1000
                },
                {
                    16733044,
                    """
                    ...........
                    .....###.#.
                    .###.##..#.
                    ..#.#...#..
                    ....#.#....
                    .##..S####.
                    .##..#...#.
                    .......##..
                    .##.#.####.
                    .##..##.##.
                    ...........
                    """,
                    5000
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input, int steps)
    {
        var actual = Day21Solver.PuzzleTwo(input, steps);

        Assert.Equal(expected, actual);
    }
}