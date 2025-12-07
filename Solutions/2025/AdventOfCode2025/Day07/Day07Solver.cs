namespace AdventOfCode2025.Day07;

public static class Day07Solver
{
    public static long PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var beams = new HashSet<int>();
        var levels = new List<HashSet<int>>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            levels.Add([]);
            for (var x = 0; x < line.Length; x++)
            {
                var c = line[x];
                if (c == 'S')
                {
                    beams.Add(x);
                }
                else if (c == '^')
                {
                    levels[y].Add(x);
                }
            }
        }

        var seen = 0;
        
        foreach (var splitters in levels)
        {
            var newBeams = beams.ToHashSet();
            foreach (var splitter in splitters)
            {
                if (!beams.Contains(splitter))
                {
                    continue;
                }

                seen++;
                newBeams.Remove(splitter);
                newBeams.Add(splitter - 1);
                newBeams.Add(splitter + 1);
            }

            beams = newBeams;
        }

        return seen;
    }

    public static long PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var source = 0;
        var levels = new List<HashSet<int>>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            levels.Add([]);
            for (var x = 0; x < line.Length; x++)
            {
                var c = line[x];
                if (c == 'S')
                {
                    source = x;
                }
                else if (c == '^')
                {
                    levels[y].Add(x);
                }
            }
        }

        var cache = new Dictionary<(int, int), long>();

        return Timelines(levels.FindIndex(s => s.Contains(source)), source);

        long Timelines(int level, int splitter)
        {
            if (level >= levels.Count)
            {
                return 1;
            }
            if (cache.TryGetValue((level, splitter), out var cached))
            {
                return cached;
            }

            var nextLevel = level + 1;
            var timelines = GetTimelines(splitter - 1) + GetTimelines(splitter + 1);

            long GetTimelines(int newSplitter)
                => levels.Skip(nextLevel).Any(s => s.Contains(newSplitter))
                    ? Timelines(levels.FindIndex(nextLevel, s => s.Contains(newSplitter)), newSplitter)
                    : 1;

            cache.Add((level, splitter), timelines);
            return timelines;
        }
    }
}