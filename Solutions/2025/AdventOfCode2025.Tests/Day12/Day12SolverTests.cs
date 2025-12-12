namespace AdventOfCode2025.Day12.Tests;

public class Day12SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new()
        {
            {
                2,
                """
                0:
                ###
                ##.
                ##.
                
                1:
                ###
                ##.
                .##
                
                2:
                .##
                ###
                ##.
                
                3:
                ##.
                ###
                ##.
                
                4:
                ###
                #..
                ###
                
                5:
                ###
                .#.
                ###
                
                4x4: 0 0 0 0 2 0
                12x5: 1 0 1 0 2 2
                12x5: 1 0 1 0 3 2
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day12Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<int, string> PuzzleTwoTestData
        = new()
        {
            {
                2,
                """
                0:
                ###
                ##.
                ##.

                1:
                ###
                ##.
                .##

                2:
                .##
                ###
                ##.

                3:
                ##.
                ###
                ##.

                4:
                ###
                #..
                ###

                5:
                ###
                .#.
                ###

                4x4: 0 0 0 0 2 0
                12x5: 1 0 1 0 2 2
                12x5: 1 0 1 0 3 2
                """
            },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(int expected, string input)
    {
        var actual = Day12Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}