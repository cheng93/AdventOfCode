namespace AdventOfCode2023.Day01.Tests;

public class Day01SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    142,
                    """
                    1abc2
                    pqr3stu8vwx
                    a1b2c3d4e5f
                    treb7uchet
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day01Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    281,
                    """
                    two1nine
                    eightwothree
                    abcone2threexyz
                    xtwone3four
                    4nineeightseven2
                    zoneight234
                    7pqrstsixteen
                    """
                },
                {
                    201,
                    """
                    twone
                    eighthree
                    sevenine
                    oneight
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day01Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}