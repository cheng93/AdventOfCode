namespace AdventOfCode2022.Day06.Tests;

public class Day06SolverTests
{
    [Theory]
    [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day06Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(23, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day06Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}