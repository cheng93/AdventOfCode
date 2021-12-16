namespace AdventOfCode2021.Day16.Tests;

public class Day16SolverTests
{

    [Theory]
    [InlineData(16, "8A004A801A8002F478")]
    [InlineData(12, "620080001611562C8802118E34")]
    [InlineData(23, "C0015000016115A2E0802F182340")]
    [InlineData(31, "A0016C880162017C3686B18A3D4780")]
    public void PuzzleOne(int expected, string input)
    {
        var actual = Day16Solver.PuzzleOne(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(3, "C200B40A82")]
    [InlineData(54, "04005AC33890")]
    [InlineData(7, "880086C3E88112")]
    [InlineData(9, "CE00C43D881120")]
    [InlineData(1, "D8005AC2A8F0")]
    [InlineData(0, "F600BC2D8F")]
    [InlineData(0, "9C005AC2F8F0")]
    [InlineData(1, "9C0141080250320F1802104A08")]
    public void PuzzleTwo(long expected, string input)
    {
        var actual = Day16Solver.PuzzleTwo(input);

        Assert.Equal(expected, actual);
    }
}