namespace AdventOfCode2015.Day25.Tests;

public class Day25SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    7981243,
                    """
                    To continue, please consult the code grid in the manual.  Enter the code at row 3, column 4.
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day25Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}