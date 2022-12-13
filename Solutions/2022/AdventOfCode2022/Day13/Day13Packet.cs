namespace AdventOfCode2022.Day13;

public abstract class Day13Packet : IComparable<Day13Packet>
{
    public int CompareTo(Day13Packet? other)
    {
        return other switch
        {
            Day13PacketList l => CompareTo(l),
            Day13PacketValue v => CompareTo(v),
            _ => throw new InvalidOperationException()
        };
    }

    public abstract int CompareTo(Day13PacketList list);

    public abstract int CompareTo(Day13PacketValue value);
}

public class Day13PacketList : Day13Packet
{
    public List<Day13Packet> Items { get; } = new();

    public override int CompareTo(Day13PacketList packet)
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (packet.Items.Count < i + 1)
            {
                return 1;
            }
            var left = Items[i];
            var right = packet.Items[i];

            var compare = left.CompareTo(right);
            if (compare != 0)
            {
                return compare;
            }
        }

        if (packet.Items.Count > Items.Count)
        {
            return -1;
        }

        return 0;
    }

    public override int CompareTo(Day13PacketValue value)
    {
        var newList = new Day13PacketList();
        newList.Items.Add(value);

        return this.CompareTo(newList);
    }

    // [1,[2,[3,[4,[5,6,7]]]],8,9]
    public static Day13PacketList Create(string input)
    {
        var stack = new Stack<Day13PacketList>();
        var numberStr = string.Empty;

        foreach (var character in input)
        {
            if (character == '[')
            {
                stack.Push(new Day13PacketList());
            }
            else if (character == ']' || character == ',')
            {
                if (int.TryParse(numberStr, out var parsed))
                {
                    stack.Peek().Items.Add(new Day13PacketValue(parsed));
                    numberStr = string.Empty;
                }

                if (character == ']')
                {
                    var popped = stack.Pop();
                    if (stack.Count == 0)
                    {
                        return popped;
                    }
                    stack.Peek().Items.Add(popped);
                }
            }
            else
            {
                numberStr += character;
            }
        }

        throw new Exception();
    }
}

public class Day13PacketValue : Day13Packet
{
    public Day13PacketValue(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public override int CompareTo(Day13PacketValue value)
        => Value.CompareTo(value.Value);

    public override int CompareTo(Day13PacketList list)
    {
        var newList = new Day13PacketList();
        newList.Items.Add(this);

        return newList.CompareTo(list);
    }
}