namespace AdventOfCode2016.Tests.Day24;

using AdventOfCode2016.Day24;
using Xunit;

public class Day24SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    14,
                    """
                    ###########
                    #0.1.....2#
                    #.#######.#
                    #4.......3#
                    ###########
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day24Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}