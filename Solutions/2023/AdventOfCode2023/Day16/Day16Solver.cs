namespace AdventOfCode2023.Day16;

using Coord = (int X, int Y);

public static class Day16Solver
{
    public static int PuzzleOne(string input)
        => new Day16Contraption(input).Energize(((0, 0), 0));

    public static int PuzzleTwo(string input)
    {
        var contraption = new Day16Contraption(input);
        var origins = new List<(Coord Position, int Direction)>();

        for (var y = 0; y < contraption.LengthY; y++)
        {
            if (y == 0 || y == contraption.LengthY - 1)
            {
                for (var x = 0; x < contraption.LengthX; x++)
                {
                    var direction = y == 0 ? 1 : 3;
                    origins.Add(((x, y), direction));
                }
            }

            origins.Add(((0, y), 0));
            origins.Add(((contraption.LengthX - 1, y), 3));
        }

        return origins
            .Select(contraption.Energize)
            .Max();
    }
}