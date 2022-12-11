namespace AdventOfCode2022.Day11.Tests;

public class Day11SolverTests
{
    public static TheoryData<long, string> PuzzleOneTestData
        = new TheoryData<long, string>()
        {
                {
                    10605,
                    """
                    Monkey 0:
                    Starting items: 79, 98
                    Operation: new = old * 19
                    Test: divisible by 23
                        If true: throw to monkey 2
                        If false: throw to monkey 3

                    Monkey 1:
                    Starting items: 54, 65, 75, 74
                    Operation: new = old + 6
                    Test: divisible by 19
                        If true: throw to monkey 2
                        If false: throw to monkey 0

                    Monkey 2:
                    Starting items: 79, 60, 97
                    Operation: new = old * old
                    Test: divisible by 13
                        If true: throw to monkey 1
                        If false: throw to monkey 3

                    Monkey 3:
                    Starting items: 74
                    Operation: new = old + 3
                    Test: divisible by 17
                        If true: throw to monkey 0
                        If false: throw to monkey 1
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(long expected, string input)
    {
        var actual = Day11Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string> PuzzleTwoTestData
        = new TheoryData<long, string>()
        {
                {
                    2713310158,
                    """
                    Monkey 0:
                    Starting items: 79, 98
                    Operation: new = old * 19
                    Test: divisible by 23
                        If true: throw to monkey 2
                        If false: throw to monkey 3

                    Monkey 1:
                    Starting items: 54, 65, 75, 74
                    Operation: new = old + 6
                    Test: divisible by 19
                        If true: throw to monkey 2
                        If false: throw to monkey 0

                    Monkey 2:
                    Starting items: 79, 60, 97
                    Operation: new = old * old
                    Test: divisible by 13
                        If true: throw to monkey 1
                        If false: throw to monkey 3

                    Monkey 3:
                    Starting items: 74
                    Operation: new = old + 3
                    Test: divisible by 17
                        If true: throw to monkey 0
                        If false: throw to monkey 1
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day11Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}