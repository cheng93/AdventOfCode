namespace AdventOfCode2022.Day03.Tests;

public class Day03SolverTests
{
    [Theory]
    [InlineData(157, "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void PuzzleOne(int expected, params string[] input)
    {
        var actual = Day03Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(70, "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void PuzzleTwo(int expected, params string[] input)
    {
        var actual = Day03Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}