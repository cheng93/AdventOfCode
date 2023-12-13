namespace AdventOfCode2023.Day08.Tests;

public class Day08SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    2,
                    """
                    RL

                    AAA = (BBB, CCC)
                    BBB = (DDD, EEE)
                    CCC = (ZZZ, GGG)
                    DDD = (DDD, DDD)
                    EEE = (EEE, EEE)
                    GGG = (GGG, GGG)
                    ZZZ = (ZZZ, ZZZ)
                    """
                },
                {
                    6,
                    """
                    LLR

                    AAA = (BBB, BBB)
                    BBB = (AAA, ZZZ)
                    ZZZ = (ZZZ, ZZZ)
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day08Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                {
                    6,
                    """
                    LR

                    11A = (11B, XXX)
                    11B = (XXX, 11Z)
                    11Z = (11B, XXX)
                    22A = (22B, XXX)
                    22B = (22C, 22C)
                    22C = (22Z, 22Z)
                    22Z = (22B, 22B)
                    XXX = (XXX, XXX)
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day08Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}