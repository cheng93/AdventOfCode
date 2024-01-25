namespace AdventOfCode2015.Day07.Tests;

public class Day07SolverTests
{
    public static TheoryData<int, string, string> PuzzleOneTestData
        = new TheoryData<int, string, string>()
        {
                {
                    507,
                    """
                    123 -> x
                    456 -> y
                    x AND y -> d
                    x OR y -> e
                    x LSHIFT 2 -> f
                    y RSHIFT 2 -> g
                    NOT x -> h
                    NOT y -> i
                    """,
                    "e"
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input, string wire)
    {
        var actual = Day07Solver.PuzzleOne(input, wire);

        Assert.Equal(expected, actual);
    }
}