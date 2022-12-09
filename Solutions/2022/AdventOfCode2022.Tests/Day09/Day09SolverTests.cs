namespace AdventOfCode2022.Day09.Tests;

public class Day09SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    13,
                    new []
                    {
                        "R 4",
                        "U 4",
                        "L 3",
                        "D 1",
                        "R 4",
                        "D 1",
                        "L 5",
                        "R 2",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day09Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
                {
                    1,
                    new []
                    {
                        "R 4",
                        "U 4",
                        "L 3",
                        "D 1",
                        "R 4",
                        "D 1",
                        "L 5",
                        "R 2",
                    }
                },
                {
                    36,
                    new []
                    {
                        "R 5",
                        "U 8",
                        "L 8",
                        "D 3",
                        "R 17",
                        "D 10",
                        "L 25",
                        "U 20",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day09Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}