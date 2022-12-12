namespace AdventOfCode2022.Day12.Tests;

public class Day12SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    31,
                    """
                    Sabqponm
                    abcryxxl
                    accszExk
                    acctuvwj
                    abdefghi
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day12Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    29,
                    """
                    Sabqponm
                    abcryxxl
                    accszExk
                    acctuvwj
                    abdefghi
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day12Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}