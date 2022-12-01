namespace AdventOfCode2022.Day01.Tests;

public class Day01SolverTests
{
    public static TheoryData<int, string[]> PuzzleOneTestData
        = new TheoryData<int, string[]>()
        {
                {
                    24000,
                    new []
                    {
                        """
                        1000
                        2000
                        3000
                        """,
                        """
                        4000
                        """,
                        """
                        5000
                        6000
                        """,
                        """
                        7000
                        8000
                        9000
                        """,
                        """
                        10000
                        """,
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day01Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string[]> PuzzleTwoTestData
        = new TheoryData<int, string[]>()
        {
                {
                    45000,
                    new []
                    {
                        """
                        1000
                        2000
                        3000
                        """,
                        """
                        4000
                        """,
                        """
                        5000
                        6000
                        """,
                        """
                        7000
                        8000
                        9000
                        """,
                        """
                        10000
                        """,
                    }
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day01Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}