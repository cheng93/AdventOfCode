namespace AdventOfCode2024.Day25;

public static class Day25Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var schematics = splits
            .Select(x => new Day25Schematic(x))
            .ToArray();

        var locks = schematics.Where(x => x.IsLock).ToArray();
        var keys = schematics.Where(x => !x.IsLock).ToArray();

        var fit = 0;

        foreach (var l in locks)
        {
            foreach (var k in keys)
            {
                var isFit = true;
                for (var i = 0; i < 5; i++)
                {
                    if (l.Heights[i] + k.Heights[i] > 5)
                    {
                        isFit = false;
                        break;
                    }
                }
                if (isFit)
                {
                    fit++;
                }
            }
        }

        return fit;
    }
}