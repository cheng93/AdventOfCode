namespace AdventOfCode2024.Day18.Tests;

public class Day18SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
            {
                22,
                """
                5,4
                4,2
                4,5
                3,0
                2,1
                6,3
                2,4
                1,5
                0,6
                3,3
                2,6
                5,1
                1,2
                5,5
                2,5
                6,5
                1,4
                0,4
                6,4
                1,1
                6,1
                1,0
                0,5
                1,6
                2,0
                """
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day18Solver.PuzzleOne(input, 6, 12);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<string, string> PuzzleTwoTestData
        = new TheoryData<string, string>()
        {
            {
                "6,1",
                """
                5,4
                4,2
                4,5
                3,0
                2,1
                6,3
                2,4
                1,5
                0,6
                3,3
                2,6
                5,1
                1,2
                5,5
                2,5
                6,5
                1,4
                0,4
                6,4
                1,1
                6,1
                1,0
                0,5
                1,6
                2,0
                """
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(string expected, string input)
    {
        var actual = Day18Solver.PuzzleTwo(input, 6, 12);

        Assert.Equal(expected, actual);
    }
}