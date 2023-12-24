namespace AdventOfCode2023.Day19.Tests;

public class Day19SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    19114,
                    """
                    px{a<2006:qkq,m>2090:A,rfg}
                    pv{a>1716:R,A}
                    lnx{m>1548:A,A}
                    rfg{s<537:gd,x>2440:R,A}
                    qs{s>3448:A,lnx}
                    qkq{x<1416:A,crn}
                    crn{x>2662:A,R}
                    in{s<1351:px,qqz}
                    qqz{s>2770:qs,m<1801:hdj,R}
                    gd{a>3333:R,R}
                    hdj{m>838:A,pv}

                    {x=787,m=2655,a=1222,s=2876}
                    {x=1679,m=44,a=2067,s=496}
                    {x=2036,m=264,a=79,s=2244}
                    {x=2461,m=1339,a=466,s=291}
                    {x=2127,m=1623,a=2188,s=1013}
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day19Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    public static TheoryData<long, string> PuzzleTwoTestData
        = new TheoryData<long, string>()
        {
                {
                    167409079868000,
                    """
                    px{a<2006:qkq,m>2090:A,rfg}
                    pv{a>1716:R,A}
                    lnx{m>1548:A,A}
                    rfg{s<537:gd,x>2440:R,A}
                    qs{s>3448:A,lnx}
                    qkq{x<1416:A,crn}
                    crn{x>2662:A,R}
                    in{s<1351:px,qqz}
                    qqz{s>2770:qs,m<1801:hdj,R}
                    gd{a>3333:R,R}
                    hdj{m>838:A,pv}

                    {x=787,m=2655,a=1222,s=2876}
                    {x=1679,m=44,a=2067,s=496}
                    {x=2036,m=264,a=79,s=2244}
                    {x=2461,m=1339,a=466,s=291}
                    {x=2127,m=1623,a=2188,s=1013}
                    """
                },
        };

    [Theory]
    [MemberData(nameof(PuzzleTwoTestData))]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day19Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}