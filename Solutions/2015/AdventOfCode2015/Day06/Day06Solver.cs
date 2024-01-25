namespace AdventOfCode2015.Day06;

using Coord = (int X, int Y);

public static class Day06Solver
{
    public static int PuzzleOne(string input)
    {
        var instructions = input
            .Split(Environment.NewLine)
            .Select(x => new Day06Instruction(x))
            .ToArray();

        var lights = new Dictionary<Coord, bool>();

        foreach (var instruction in instructions)
        {
            for (var y = instruction.Start.Y; y <= instruction.End.Y; y++)
            {
                for (var x = instruction.Start.X; x <= instruction.End.X; x++)
                {
                    var coord = (x, y);
                    if (!lights.TryGetValue(coord, out var light))
                    {
                        lights.Add(coord, false);
                    }

                    Func<bool, bool> apply = instruction.Phrase switch
                    {
                        "on" => x => true,
                        "off" => x => false,
                        "toggle" => x => !x,
                        _ => throw new Exception()
                    };

                    lights[coord] = apply(light);
                }
            }
        }

        return lights.Values.Count(x => x);
    }

    public static int PuzzleTwo(string input)
    {
        var instructions = input
            .Split(Environment.NewLine)
            .Select(x => new Day06Instruction(x))
            .ToArray();

        var lights = new Dictionary<Coord, int>();

        foreach (var instruction in instructions)
        {
            for (var y = instruction.Start.Y; y <= instruction.End.Y; y++)
            {
                for (var x = instruction.Start.X; x <= instruction.End.X; x++)
                {
                    var coord = (x, y);
                    if (!lights.TryGetValue(coord, out var light))
                    {
                        lights.Add(coord, 0);
                    }

                    Func<int, int> apply = instruction.Phrase switch
                    {
                        "on" => x => x + 1,
                        "off" => x => Math.Max(0, x - 1),
                        "toggle" => x => x + 2,
                        _ => throw new Exception()
                    };

                    lights[coord] = apply(light);
                }
            }
        }

        return lights.Values.Sum();
    }
}