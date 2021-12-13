namespace AdventOfCode2021.Day13;

public record Day13Instruction
{
    // example: fold along y=7
    public Day13Instruction(string input)
    {
        var splits = input.Substring("fold along ".Length).Split("=");
        Direction = splits[0][0];
        Value = int.Parse(splits[1]);
    }

    public char Direction { get; }
    public int Value { get; }

    public HashSet<(int X, int Y)> Fold(HashSet<(int X, int Y)> paper)
    {
        var folded = new HashSet<(int X, int Y)>(paper);
        foreach (var coord in paper)
        {
            if (Direction == 'x' && coord.X > Value)
            {
                var newCoord = (2 * Value - coord.X, coord.Y);
                folded.Remove(coord);
                folded.Add(newCoord);
            }
            else if (Direction == 'y' && coord.Y > Value)
            {
                var newCoord = (coord.X, 2 * Value - coord.Y);
                folded.Remove(coord);
                folded.Add(newCoord);
            }
        }

        return folded;
    }
}