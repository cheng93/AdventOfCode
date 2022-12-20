namespace AdventOfCode2022.Day19.Tests;

public class Day19SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
            {
                33,
                new []
                {
                    "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.",
                    "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day19Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}