namespace AdventOfCode2025.Day02.Tests;

public class Day02SolverTests
{
    public static TheoryData<long, string> PuzzleOneTestData
        = new()
        {
            {
                1227775554,
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(long expected, string input)
    {
        var actual = Day02Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string> PuzzleTwoTestData
        = new()
        {
            {
                4174379265,
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day02Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}