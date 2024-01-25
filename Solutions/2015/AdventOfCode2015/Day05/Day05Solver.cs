namespace AdventOfCode2015.Day05;

public static class Day05Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var nice = 0;
        string[] badStrings = ["ab", "cd", "pq", "xy"];

        foreach (var line in lines)
        {
            var vowels = 0;
            var hasDouble = false;
            var hasBad = false;
            for (var i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if ("aeiou".Contains(character))
                {
                    vowels++;
                }

                if (i < line.Length - 1)
                {
                    var next = line[i + 1];
                    if (character == next)
                    {
                        hasDouble = true;
                    }
                    else if (badStrings.Contains($"{character}{next}"))
                    {
                        hasBad = true;
                    }
                }
            }

            if (vowels >= 3 && hasDouble && !hasBad)
            {
                nice++;
            }
        }

        return nice;
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var nice = 0;

        foreach (var line in lines)
        {
            var pairs = new Dictionary<string, int>();
            var hasSandwich = false;
            var hasDoublePair = false;
            for (var i = 0; i < line.Length - 1; i++)
            {
                var character = line[i];
                var pair = $"{character}{line[i + 1]}";
                if (pairs.TryGetValue(pair, out var position))
                {
                    if (i > position)
                    {
                        hasDoublePair = true;
                    }
                }
                else
                {
                    pairs.Add(pair, i + 1);
                }

                if (i < line.Length - 2 && character == line[i + 2])
                {
                    hasSandwich = true;
                }
            }

            if (hasSandwich && hasDoublePair)
            {
                nice++;
            }
        }

        return nice;
    }
}