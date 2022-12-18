namespace AdventOfCode2022.Day18.Tests;

public class Day18SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
            {
                64,
                new []
                {
                    "2,2,2",
                    "1,2,2",
                    "3,2,2",
                    "2,1,2",
                    "2,3,2",
                    "2,2,1",
                    "2,2,3",
                    "2,2,4",
                    "2,2,6",
                    "1,2,5",
                    "3,2,5",
                    "2,1,5",
                    "2,3,5",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day18Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
            {
                58,
                new []
                {
                    "2,2,2",
                    "1,2,2",
                    "3,2,2",
                    "2,1,2",
                    "2,3,2",
                    "2,2,1",
                    "2,2,3",
                    "2,2,4",
                    "2,2,6",
                    "1,2,5",
                    "3,2,5",
                    "2,1,5",
                    "2,3,5",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day18Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}