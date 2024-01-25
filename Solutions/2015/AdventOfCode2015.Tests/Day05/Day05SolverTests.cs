namespace AdventOfCode2015.Day05.Tests;

public class Day05SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    2,
                    """
                    ugknbfddgicrmopn
                    aaa
                    jchzalrnumimnmhp
                    haegwjzuvuyypxyu
                    dvszwmarrgswjxmb
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day05Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    2,
                    """
                    qjhvhtzxzqqjkmpb
                    xxyxx
                    uurcxstgmygtbstg
                    ieodomkazucvgmuy
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day05Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}