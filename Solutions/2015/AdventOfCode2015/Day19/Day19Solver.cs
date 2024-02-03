namespace AdventOfCode2015.Day19;

public static class Day19Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var replacements = splits[0]
            .Split(Environment.NewLine)
            .Select(x => new Day19Replacement(x))
            .ToArray();
        var source = splits[1];

        var molecules = new HashSet<string>();

        foreach (var replacement in replacements)
        {
            var index = source.IndexOf(replacement.From);
            while (index != -1)
            {
                molecules.Add($"{source[..index]}{replacement.To}{source[(index + replacement.From.Length)..]}");
                index = source.IndexOf(replacement.From, index + replacement.From.Length);
            }
        }

        return molecules.Count;
    }

    public static int PuzzleTwo(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var replacements = splits[0]
            .Split(Environment.NewLine)
            .Select(x => new Day19Replacement(x))
            .OrderByDescending(x => x.To.Length)
            .ToArray();

        var target = splits[1];

        var lookup = replacements.ToDictionary(x => x.To, x => x.From);
        var molecule = target;
        var replaced = 0;
        var hasChanged = true;

        while (hasChanged)
        {
            hasChanged = false;
            var marker = molecule.Length;
            string? previous = null;
            string? now = null;

            if (lookup.TryGetValue(molecule, out var v))
            {
                molecule = v;
                replaced++;
                hasChanged = true;
                continue;
            }

            for (var i = marker - 1; i >= 0; i--)
            {
                var m = molecule[i];
                if (m is >= 'a' and <= 'z')
                {
                    now += m;
                    continue;
                }
                now = m + now;

                if (now == "Ar")
                {
                    marker = i + 2;
                }
                else if (previous != null)
                {
                    if (previous == "Rn")
                    {
                        var key = molecule[i..marker];
                        if (lookup.TryGetValue(key, out var value))
                        {
                            molecule = $"{molecule[..i]}{value}{molecule[marker..]}";
                            hasChanged = true;
                        }
                    }
                    else
                    {
                        var key = now + previous;
                        if (lookup.TryGetValue(key, out var value))
                        {
                            molecule = $"{molecule[..i]}{value}{molecule[(i + key.Length)..]}";
                            hasChanged = true;
                        }
                    }
                }

                if (hasChanged)
                {
                    replaced++;
                    break;
                }

                previous = now;
                now = null;
            }
        }

        return replaced;
    }
}