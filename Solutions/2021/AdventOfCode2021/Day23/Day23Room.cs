using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2021.Day23;

public record Day23Room
{
    public Day23Room(char id, int size, string initial)
    {
        Id = id;
        Size = size;
        Initial = initial;
    }

    public char Id { get; }

    public int Size { get; }
    public string Initial { get; private set; }

    public bool Sorted => Initial == "".PadLeft(Size, Id);

    public bool CanEnter(char c, out int distance)
    {
        distance = 0;
        if (c == Id && Initial.All(x => x == c))
        {
            distance = Size - Initial.Length;
            return true;
        }

        return false;
    }

    public void Enter(char c) => Initial = c + Initial;

    public bool CanLeave([NotNullWhen(true)] out char? c, out int distance)
    {
        c = null;
        distance = 0;
        if (Initial.Any(x => x != Id))
        {
            c = Initial[0];
            distance = Size + 1 - Initial.Length;
            return true;
        }

        return false;
    }

    public void Leave() => Initial = Initial[1..];

    public override string ToString()
        => string.Join("", Initial).PadLeft(Size, '.');
}