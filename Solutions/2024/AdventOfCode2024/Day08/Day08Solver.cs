using System.Numerics;

namespace AdventOfCode2024.Day08;

public static class Day08Solver
{
    public static int PuzzleOne(string input) => Solve(input, x => x.Skip(2).Take(1));

    public static int PuzzleTwo(string input) => Solve(input, x => x);

    private static int Solve(string input, Func<IEnumerable<Complex>, IEnumerable<Complex>> func)
    {
        var lines = input.Split(Environment.NewLine);
        var points = new HashSet<Complex>();
        var frequencies = new Dictionary<char, List<Complex>>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                var point = i + j * Complex.ImaginaryOne;
                points.Add(point);
                if (c != '.')
                {
                    if (!frequencies.TryGetValue(c, out var list))
                    {
                        list = new();
                        frequencies.Add(c, list);
                    }
                    list.Add(point);
                }
            }
        }

        var antinodes = new HashSet<Complex>();

        foreach (var antennas in frequencies.Values)
        {
            for (var i = 0; i < antennas.Count; i++)
            {
                var source = antennas[i];
                for (var j = 0; j < antennas.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var diff = antennas[j] - source;
                    var allAntinodes = Enumerable
                        .Range(0, int.MaxValue)
                        .Select(x => source + x * diff)
                        .TakeWhile(points.Contains);

                    foreach (var antinode in func(allAntinodes))
                    {
                        antinodes.Add(antinode);
                    }
                }
            }
        }

        return antinodes.Count;
    }
}