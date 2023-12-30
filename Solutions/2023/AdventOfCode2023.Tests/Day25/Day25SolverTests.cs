namespace AdventOfCode2023.Day25.Tests;

public class Day25SolverTests
{
    public static TheoryData<int, string> PuzzleOneTestData
        = new TheoryData<int, string>()
        {
                {
                    54,
                    """
                    jqt: rhn xhk nvd
                    rsh: frs pzl lsr
                    xhk: hfx
                    cmg: qnr nvd lhk bvb
                    rhn: xhk bvb hfx
                    bvb: xhk hfx
                    pzl: lsr hfx nvd
                    qnr: nvd
                    ntq: jqt hfx bvb xhk
                    nvd: lhk
                    lsr: lhk
                    rzs: qnr cmg lsr rsh
                    frs: qnr lhk lsr
                    """
                }
        };

    [Theory]
    [MemberData(nameof(PuzzleOneTestData))]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day25Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }
}