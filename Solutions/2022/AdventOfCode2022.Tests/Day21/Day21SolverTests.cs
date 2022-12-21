namespace AdventOfCode2022.Day21.Tests;

public class Day21SolverTests
{
    public static TheoryData<long, string[]> PuzzleOneTestData
        = new TheoryData<long, string[]>()
        {
            {
                152,
                new []
                {
                    "root: pppw + sjmn",
                    "dbpl: 5",
                    "cczh: sllz + lgvd",
                    "zczc: 2",
                    "ptdq: humn - dvpt",
                    "dvpt: 3",
                    "lfqf: 4",
                    "humn: 5",
                    "ljgn: 2",
                    "sjmn: drzm * dbpl",
                    "sllz: 4",
                    "pppw: cczh / lfqf",
                    "lgvd: ljgn * ptdq",
                    "drzm: hmdt - zczc",
                    "hmdt: 32",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(long expected, params string[] input)
    {
        var actual = Day21Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
    public static TheoryData<long, string[]> PuzzleTwoTestData
        = new TheoryData<long, string[]>()
        {
            {
                301,
                new []
                {
                    "root: pppw + sjmn",
                    "dbpl: 5",
                    "cczh: sllz + lgvd",
                    "zczc: 2",
                    "ptdq: humn - dvpt",
                    "dvpt: 3",
                    "lfqf: 4",
                    "humn: 5",
                    "ljgn: 2",
                    "sjmn: drzm * dbpl",
                    "sllz: 4",
                    "pppw: cczh / lfqf",
                    "lgvd: ljgn * ptdq",
                    "drzm: hmdt - zczc",
                    "hmdt: 32",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, params string[] input)
    {
        var actual = Day21Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}