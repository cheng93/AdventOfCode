namespace AdventOfCode2015.Day19.Tests;

public class Day19SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    4,
                    """
                    H => HO
                    H => OH
                    O => HH

                    HOH
                    """
                },
                {
                    7,
                    """
                    H => HO
                    H => OH
                    O => HH

                    HOHOHO
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day19Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    3,
                    """
                    e => H
                    e => O
                    H => HO
                    H => OH
                    O => HH

                    HOH
                    """
                },
                {
                    6,
                    """
                    e => H
                    e => O
                    H => HO
                    H => OH
                    O => HH

                    HOHOHO
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day19Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}