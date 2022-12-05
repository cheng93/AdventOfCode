namespace AdventOfCode2022.Day05.Tests;

public class Day05SolverTests
{
    public static TheoryData<string, string> PuzzleOneTestData
        = new TheoryData<string, string>()
        {
                {
                    "CMZ",
                    """
                        [D]    
                    [N] [C]    
                    [Z] [M] [P]
                    1   2   3 

                    move 1 from 2 to 1
                    move 3 from 1 to 3
                    move 2 from 2 to 1
                    move 1 from 1 to 2
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(string expected, string input)
    {
        var actual = Day05Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
    public static TheoryData<string, string> PuzzleTwoTestData
        = new TheoryData<string, string>()
        {
                {
                    "MCD",
                    """
                        [D]    
                    [N] [C]    
                    [Z] [M] [P]
                    1   2   3 

                    move 1 from 2 to 1
                    move 3 from 1 to 3
                    move 2 from 2 to 1
                    move 1 from 1 to 2
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(string expected, string input)
    {
        var actual = Day05Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}