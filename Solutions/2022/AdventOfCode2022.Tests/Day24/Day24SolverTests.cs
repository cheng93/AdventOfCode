namespace AdventOfCode2022.Day24.Tests;

public class Day24SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
            {
                18,
                """
                #.######
                #>>.<^<#
                #.<..<<#
                #>v.><>#
                #<^v^^>#
                ######.#
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

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
            {
                54,
                """
                #.######
                #>>.<^<#
                #.<..<<#
                #>v.><>#
                #<^v^^>#
                ######.#
                """
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day24Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}