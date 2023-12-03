namespace AdventOfCode2023.Day03;

using Coord = (int X, int Y);

public static class Day03Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();

        var partCoords = new List<(int PartNumber, List<Coord> Coords)>();
        var symbols = new HashSet<Coord>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var partNumber = 0;
            var coords = new List<Coord>();
            for (var j = 0; j < line.Length; j++)
            {
                var character = line[j];
                var coord = (j, i);

                if (int.TryParse(character.ToString(), out var parsed))
                {
                    partNumber *= 10;
                    partNumber += parsed;
                    coords.Add(coord);

                    if (j == line.Length - 1)
                    {
                        Reset();
                    }
                }
                else
                {
                    if (partNumber > 0)
                    {
                        Reset();
                    }

                    if (character != '.')
                    {
                        symbols.Add(coord);
                    }
                }
            }

            void Reset()
            {
                partCoords.Add((partNumber, coords));
                partNumber = 0;
                coords = new();
            }
        }

        var symbolNeighbours = new HashSet<Coord>();
        foreach (var symbol in symbols)
        {
            var directions = new Coord[] { (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };
            foreach (var direction in directions)
            {
                symbolNeighbours.Add((symbol.X + direction.X, symbol.Y + direction.Y));
            }
        }

        return partCoords
            .Where(x => x.Coords.Any(coord => symbolNeighbours.Contains(coord)))
            .Sum(x => x.PartNumber);
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();

        var partCoords = new List<(int PartNumber, List<Coord> Coords)>();
        var symbols = new HashSet<Coord>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var partNumber = 0;
            var coords = new List<Coord>();
            for (var j = 0; j < line.Length; j++)
            {
                var character = line[j];
                var coord = (j, i);

                if (int.TryParse(character.ToString(), out var parsed))
                {
                    partNumber *= 10;
                    partNumber += parsed;
                    coords.Add(coord);

                    if (j == line.Length - 1)
                    {
                        Reset();
                    }
                }
                else
                {
                    if (partNumber > 0)
                    {
                        Reset();
                    }

                    if (character == '*')
                    {
                        symbols.Add(coord);
                    }
                }
            }

            void Reset()
            {
                partCoords.Add((partNumber, coords));
                partNumber = 0;
                coords = new();
            }
        }

        var symbolGroups = new List<HashSet<Coord>>();
        foreach (var symbol in symbols)
        {
            var symbolNeighbours = new HashSet<Coord>();
            var directions = new Coord[] { (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };
            foreach (var direction in directions)
            {
                symbolNeighbours.Add((symbol.X + direction.X, symbol.Y + direction.Y));
            }
            symbolGroups.Add(symbolNeighbours);
        }

        return symbolGroups
            .Select(s => partCoords
                .Where(x => s.Overlaps(x.Coords))
                .Select(x => x.PartNumber))
            .Where(p => p.Count() == 2)
            .Sum(p => p.First() * p.Last());
    }
}