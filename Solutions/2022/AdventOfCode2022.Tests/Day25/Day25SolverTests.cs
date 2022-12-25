namespace AdventOfCode2022.Day25.Tests;

public class Day25SolverTests
{
    public static TheoryData<string, string[]> PuzzleOneTestData
        = new TheoryData<string, string[]>()
        {
            {
                "2=-1=0",
                new[]
                {
                    "1=-0-2",
                    "12111",
                    "2=0=",
                    "21",
                    "2=01",
                    "111",
                    "20012",
                    "112",
                    "1=-1=",
                    "1-12",
                    "12",
                    "1=",
                    "122",
                }
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(string expected, params string[] input)
    {
        var actual = Day25Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}