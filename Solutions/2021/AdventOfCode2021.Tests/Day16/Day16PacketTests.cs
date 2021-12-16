namespace AdventOfCode2021.Day16.Tests;

public class Day16PacketTests
{
    [Theory]
    [InlineData("110100101111111000101000", 6, 4, 21, 2021)]
    [InlineData("11010001010", 6, 4, 11, 10)]
    [InlineData("01010010001001000000000", 2, 4, 16, 20)]
    public void Day16LiteralPacket(string input, int version, int typeId, int length, int value)
    {
        var packet = new Day16LiteralPacket(input);

        Assert.Equal(version, packet.Version);
        Assert.Equal(typeId, packet.TypeId);
        Assert.Equal(length, packet.Length);
        Assert.Equal(value, packet.Value);
    }

    [Theory]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 1, 6, 49, 2)]
    public void Day16Operator0Packet(string input, int version, int typeId, int length, int subpackets)
    {
        var packet = new Day16Operator0Packet(input);

        Assert.Equal(version, packet.Version);
        Assert.Equal(typeId, packet.TypeId);
        Assert.Equal(length, packet.Length);
        Assert.Equal(subpackets, packet.SubPackets.Count());
    }

    [Theory]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 7, 3, 51, 3)]
    public void Day16Operator1Packet(string input, int version, int typeId, int length, int subpackets)
    {
        var packet = new Day16Operator1Packet(input);

        Assert.Equal(version, packet.Version);
        Assert.Equal(typeId, packet.TypeId);
        Assert.Equal(length, packet.Length);
        Assert.Equal(subpackets, packet.SubPackets.Count());
    }
}