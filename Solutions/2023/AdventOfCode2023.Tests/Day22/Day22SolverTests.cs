namespace AdventOfCode2023.Day22.Tests;

public class Day22SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    5,
                    """
                    1,0,1~1,2,1
                    0,0,2~2,0,2
                    0,2,3~2,2,3
                    0,0,4~0,2,4
                    2,0,5~2,2,5
                    0,1,6~2,1,6
                    1,1,8~1,1,9
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day22Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    7,
                    """
                    1,0,1~1,2,1
                    0,0,2~2,0,2
                    0,2,3~2,2,3
                    0,0,4~0,2,4
                    2,0,5~2,2,5
                    0,1,6~2,1,6
                    1,1,8~1,1,9
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day22Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}