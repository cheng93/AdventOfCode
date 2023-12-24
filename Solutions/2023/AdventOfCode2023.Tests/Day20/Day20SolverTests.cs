namespace AdventOfCode2023.Day20.Tests;

public class Day20SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    32000000,
                    """
                    broadcaster -> a, b, c
                    %a -> b
                    %b -> c
                    %c -> inv
                    &inv -> a
                    """
                },
                {
                    11687500,
                    """
                    broadcaster -> a
                    %a -> inv, con
                    &inv -> b
                    %b -> con
                    &con -> output
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day20Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}