namespace AdventOfCode2024.Day17.Tests;

public class Day17SolverTests
{
    public static TheoryData<string, string> PuzzleOneTestData
        = new TheoryData<string, string>()
        {
                {
                    "4,6,3,5,6,3,5,2,1,0",
                    """
                    Register A: 729
                    Register B: 0
                    Register C: 0

                    Program: 0,1,5,4,3,0
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(string expected, string input)
    {
        var actual = Day17Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    117440,
                    """
                    Register A: 2024
                    Register B: 0
                    Register C: 0

                    Program: 0,3,5,4,3,0
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day17Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}