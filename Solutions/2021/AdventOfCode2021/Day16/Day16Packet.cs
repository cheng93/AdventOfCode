using System.Text;

namespace AdventOfCode2021.Day16;

public abstract class Day16Packet
{
    protected Day16Packet(string input)
    {
        Version = Convert.ToInt32(input[0..3], 2);
        TypeId = Convert.ToInt32(input[3..6], 2);
    }

    public int Version { get; }

    public int TypeId { get; }

    public int Length { get; init; } = 6;

    public IEnumerable<Day16Packet> SubPackets { get; init; } = Enumerable.Empty<Day16Packet>();

    public abstract long Execute();

    // example: 110100101111111000101000
    public static IEnumerable<Day16Packet> Create(string input)
    {
        var current = input;
        while (current.Any(x => x == '1'))
        {
            var typeId = Convert.ToInt32(current[3..6], 2);

            if (typeId == 4)
            {
                var packet = new Day16LiteralPacket(current);
                current = current[packet.Length..];
                yield return packet;
            }
            else
            {
                var lengthTypePacket = current[6];
                if (lengthTypePacket == '0')
                {
                    var packet = new Day16Operator0Packet(current);
                    current = current[packet.Length..];
                    yield return packet;
                }
                else if (lengthTypePacket == '1')
                {
                    var packet = new Day16Operator1Packet(current);
                    current = current[packet.Length..];
                    yield return packet;
                }
            }
        }
    }
}

public class Day16LiteralPacket : Day16Packet
{
    // example: 110100101111111000101000
    public Day16LiteralPacket(string input)
        : base(input)
    {
        var sb = new StringBuilder();
        for (var i = 6; i < input.Length; i = i + 5)
        {
            var group = input[i..(i + 5)];
            var first = group[0];

            sb.Append(group[^4..]);
            if (first == '0')
            {
                Length = i + 5;
                break;
            }
        }

        Value = Convert.ToInt64(sb.ToString(), 2);
    }

    public long Value { get; }

    public override long Execute() => this.Value;
}

public abstract class Day16OperatorPacket : Day16Packet
{
    protected Day16OperatorPacket(string input)
        : base(input)
    {
    }

    public override long Execute()
    {
        return TypeId switch
        {
            0 => SubPackets.Sum(x => x.Execute()),
            1 => SubPackets.Aggregate(1L, (agg, cur) => agg * cur.Execute()),
            2 => SubPackets.Select(x => x.Execute()).Min(),
            3 => SubPackets.Select(x => x.Execute()).Max(),
            5 => SubPackets.First().Execute() > SubPackets.Last().Execute() ? 1 : 0,
            6 => SubPackets.First().Execute() < SubPackets.Last().Execute() ? 1 : 0,
            7 => SubPackets.First().Execute() == SubPackets.Last().Execute() ? 1 : 0,
            _ => throw new InvalidOperationException()
        };
    }
}

public class Day16Operator0Packet : Day16OperatorPacket
{
    // example: 11010000000000000110111101000101001010010001001000000000
    public Day16Operator0Packet(string input)
        : base(input)
    {
        var subpacketBitLength = Convert.ToInt32(input[7..22], 2);

        Length += 16 + subpacketBitLength;
        SubPackets = Day16Packet.Create(input[22..Length]);
    }

}

public class Day16Operator1Packet : Day16OperatorPacket
{
    // example: 11010010000000001101010000001100100000100011000001100000
    public Day16Operator1Packet(string input)
        : base(input)
    {
        var subpacketLength = Convert.ToInt32(input[7..18], 2);

        SubPackets = Day16.Day16Packet.Create(input[18..]).Take(subpacketLength);
        Length += 12 + SubPackets.Sum(x => x.Length);
    }
}