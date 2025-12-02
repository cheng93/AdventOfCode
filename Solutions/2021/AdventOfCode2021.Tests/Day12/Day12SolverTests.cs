namespace AdventOfCode2021.Day12.Tests;

public class Day12SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    10,
                    new []
                    {
"start-A",
"start-b",
"A-c",
"A-b",
"b-d",
"A-end",
"b-end",
                    }
                },
                {
                    19,
                    new []
                    {
"dc-end",
"HN-start",
"start-kj",
"dc-start",
"dc-HN",
"LN-dc",
"HN-end",
"kj-sa",
"kj-HN",
"kj-dc",
                    }
                },
                {
                    226,
                    new []
                    {
"fs-end",
"he-DX",
"fs-he",
"start-DX",
"pj-DX",
"end-zg",
"zg-sl",
"zg-pj",
"pj-he",
"RW-he",
"fs-DX",
"pj-RW",
"zg-RW",
"start-pj",
"he-WI",
"zg-he",
"pj-fs",
"start-RW",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day12Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
                {
                    36,
                    new []
                    {
"start-A",
"start-b",
"A-c",
"A-b",
"b-d",
"A-end",
"b-end",
                    }
                },
                {
                    103,
                    new []
                    {
"dc-end",
"HN-start",
"start-kj",
"dc-start",
"dc-HN",
"LN-dc",
"HN-end",
"kj-sa",
"kj-HN",
"kj-dc",
                    }
                },
                {
                    3509,
                    new []
                    {
"fs-end",
"he-DX",
"fs-he",
"start-DX",
"pj-DX",
"end-zg",
"zg-sl",
"zg-pj",
"pj-he",
"RW-he",
"fs-DX",
"pj-RW",
"zg-RW",
"start-pj",
"he-WI",
"zg-he",
"pj-fs",
"start-RW",
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day12Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}