namespace AdventOfCode2023.Day22;

using Coord = (int X, int Y, int Z);

public class Day22Brick
{
    // 1,0,1~1,2,1
    public Day22Brick(string input)
    {
        var splits = input.Split('~');
        var coords = splits
            .Select<string, Coord>(x =>
            {
                var numbers = x
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                return (numbers[0], numbers[1], numbers[2]);
            })
            .ToArray();
        Start = coords[0];
        End = coords[1];
        Height = Math.Abs(Start.Z - End.Z) + 1;
    }

    public Coord Start { get; }

    public Coord End { get; }

    public int Height { get; }

    public bool IsHorizontal => Height == 1;

    public IEnumerable<Coord> Base()
    {
        if (IsHorizontal)
        {
            for (var x = Math.Min(Start.X, End.X); x <= Math.Max(Start.X, End.X); x++)
            {
                for (var y = Math.Min(Start.Y, End.Y); y <= Math.Max(Start.Y, End.Y); y++)
                {
                    yield return (x, y, Start.Z);
                }
            }
        }
        else
        {
            yield return (Start.X, Start.Y, Math.Min(Start.Z, End.Z));
        }
    }
}