namespace AdventOfCode2015.Day14.Tests;

public class Day14SolverTests
{
    public static TheoryData<int, string, int> PuzzleOneTestData
        = new TheoryData<int, string, int>()
        {
                {
                    1120,
                    """
                    Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
                    Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
                    """,
                    1000
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, int seconds)
    {
        var actual = Day14Solver.PuzzleOne(input, seconds);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string, int> PuzzleTwoTestData
        = new TheoryData<int, string, int>()
        {
                {
                    689,
                    """
                    Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
                    Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
                    """,
                    1000
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input, int seconds)
    {
        var actual = Day14Solver.PuzzleTwo(input, seconds);

        Assert.Equal(expected, actual);
    }
}