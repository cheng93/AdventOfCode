using System.Text;

namespace AdventOfCode2021.Day16;

public static class Day16Solver
{
    public static int PuzzleOne(string input)
    {
        return GetPacketVersions(GetPackets(input));

        int GetPacketVersions(IEnumerable<Day16Packet> p)
        {
            return p.Sum(x => x.Version + GetPacketVersions(x.SubPackets));
        }
    }

    public static long PuzzleTwo(string input) => GetPackets(input).First().Execute();

    private static IEnumerable<Day16Packet> GetPackets(string input)
    {
        var hexBin = new Dictionary<char, string>
        {
            {'0', "0000"},
            {'1', "0001"},
            {'2', "0010"},
            {'3', "0011"},
            {'4', "0100"},
            {'5', "0101"},
            {'6', "0110"},
            {'7', "0111"},
            {'8', "1000"},
            {'9', "1001"},
            {'A', "1010"},
            {'B', "1011"},
            {'C', "1100"},
            {'D', "1101"},
            {'E', "1110"},
            {'F', "1111"},
        };

        var binary = input
            .Aggregate(
                new StringBuilder(),
                (agg, cur) => agg.Append(hexBin[cur]))
            .ToString();

        return Day16Packet.Create(binary);
    }
}