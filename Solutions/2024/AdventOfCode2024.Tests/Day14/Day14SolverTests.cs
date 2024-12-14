namespace AdventOfCode2024.Day14.Tests;

public class Day14SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    12,
                    """
                    p=0,4 v=3,-3
                    p=6,3 v=-1,-3
                    p=10,3 v=-1,2
                    p=2,0 v=2,-1
                    p=0,0 v=1,3
                    p=3,0 v=-2,-2
                    p=7,6 v=-1,-3
                    p=3,0 v=-1,-2
                    p=9,3 v=2,3
                    p=7,3 v=-1,2
                    p=2,4 v=2,-3
                    p=9,5 v=-3,-3
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day14Solver.PuzzleOne(input, 11, 7);

        Assert.Equal(expected, actual);
    }
}