namespace AdventOfCode2022.Day13.Tests;

public class Day13SolverTests
{
    public static TheoryData<int, string[][]> PuzzleOneTestData
        = new TheoryData<int, string[][]>()
        {
            {
                13,
                new string[][]
                {
                    new []
                    {
                        "[1,1,3,1,1]",
                        "[1,1,5,1,1]",
                    },
                    new []
                    {
                        "[[1],[2,3,4]]",
                        "[[1],4]",
                    },
                    new []
                    {
                        "[9]",
                        "[[8,7,6]]",
                    },
                    new []
                    {
                        "[[4,4],4,4]",
                        "[[4,4],4,4,4]",
                    },
                    new []
                    {
                        "[7,7,7,7]",
                        "[7,7,7]",
                    },
                    new []
                    {
                        "[]",
                        "[3]",
                    },
                    new []
                    {
                        "[[[]]]",
                        "[[]]",
                    },
                    new []
                    {
                        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                        "[1,[2,[3,[4,[5,6,0]]]],8,9]",
                    }
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[][] input)
    {
        var actual = Day13Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
    public static TheoryData<int, string[][]> PuzzleTwoTestData
        = new TheoryData<int, string[][]>()
        {
            {
                140,
                new string[][]
                {
                    new []
                    {
                        "[1,1,3,1,1]",
                        "[1,1,5,1,1]",
                    },
                    new []
                    {
                        "[[1],[2,3,4]]",
                        "[[1],4]",
                    },
                    new []
                    {
                        "[9]",
                        "[[8,7,6]]",
                    },
                    new []
                    {
                        "[[4,4],4,4]",
                        "[[4,4],4,4,4]",
                    },
                    new []
                    {
                        "[7,7,7,7]",
                        "[7,7,7]",
                    },
                    new []
                    {
                        "[]",
                        "[3]",
                    },
                    new []
                    {
                        "[[[]]]",
                        "[[]]",
                    },
                    new []
                    {
                        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
                        "[1,[2,[3,[4,[5,6,0]]]],8,9]",
                    }
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[][] input)
    {
        var actual = Day13Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}