namespace AdventOfCode2016.Day15;

public record Day15Disc(int Positions, int Position)
{
    //Disc #1 has 13 positions; at time=0, it is at position 1.
    public static Day15Disc Create(string input)
    {
        var ints = input
            .Replace("#", string.Empty)
            .Replace(".", string.Empty)
            .Split(" ")
            .Where(x => int.TryParse(x, out var _))
            .Select(int.Parse)
            .ToArray();

        return new(ints[1], ints[2]);
    }

    public int PositionAt(int time) => (Position + time) % Positions;
}