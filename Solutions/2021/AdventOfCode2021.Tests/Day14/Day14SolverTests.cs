namespace AdventOfCode2021.Day14.Tests;

public class Day14SolverTests
{
    public static TheoryData<long, string> PuzzleOneTestData
        = new TheoryData<long, string>()
        {
            {
                1588,
@"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C"
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(long expected, string input)
    {
        var actual = Day14Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string> PuzzleTwoTestData
        = new TheoryData<long, string>()
        {
            {
                2188189693529,
@"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C"
            }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day14Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}