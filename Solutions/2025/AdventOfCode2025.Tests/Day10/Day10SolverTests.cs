namespace AdventOfCode2025.Day10.Tests;

public class Day10SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new()
        {
            {
                7,
                """
                [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day10Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new()
        {
            {
                33,
                """
                [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                """
            },
            // {
            //     12,
            //     """
            //     [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
            //     """
            // },
            {
                130,
                "[##########] (0,1,2,4,6,7,8,9) (3,6,8,9) (3,4,5,7,8,9) (0,1,2,4,5,6,7,8,9) (0,5,6,7,8,9) (3,8) (0,1) (2,3,4,5,6,7,8,9) (0,1,2,5,6,7) (3,5,9) (0,3,4) {63,42,43,78,66,70,70,70,92,102}"
            },
            {
                97,
                "[.#####..#] (0,1,2,3,4,8) (0,1,2,3,5,6,8) (0,1,5) (3,8) (1,2,3,4,5,8) (0,2,3,4,6,7,8) (1,4,6,8) (0,2,3,5,6,7) (1,2,4,5,6,7,8) {63,64,68,78,44,63,44,23,74}"
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day10Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}