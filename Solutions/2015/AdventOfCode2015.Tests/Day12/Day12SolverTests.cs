namespace AdventOfCode2015.Day12.Tests;

public class Day12SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                { 6, """[1,2,3]""" },
                { 6, """{"a":2,"b":4}""" },
                { 3, """[[[3]]]""" },
                { 3, """{"a":{"b":4},"c":-1}""" },
                { 0, """{"a":[-1,1]}""" },
                { 0, """[-1,{"a":1}]""" },
                { 0, """[]""" },
                { 0, """{}""" },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day12Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new TheoryData<int, string>()
        {
                { 6, """[1,2,3]""" },
                { 4, """[1,{"c":"red","b":2},3]""" },
                { 0, """{"d":"red","e":[1,2,3,4],"f":5}""" },
                { 6, """[1,"red",5]""" },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day12Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}