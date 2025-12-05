namespace AdventOfCode2025.Day05;

public static class Day05Solver
{
    public static int PuzzleOne(string input)
    {
        var parts = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var ranges = parts[0]
            .Split(Environment.NewLine)
            .Select(x => new Day05Range(x))
            .ToArray();
        var ids = parts[1]
            .Split(Environment.NewLine)
            .Select(long.Parse)
            .ToArray();

        return ids.Count(i => ranges.Any(r => i >= r.Min && i <= r.Max));
    }

    public static long PuzzleTwo(string input)
    {
        var parts = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var ranges = parts[0]
            .Split(Environment.NewLine)
            .Select(x => new Day05Range(x))
            .ToList();

        return Merge(ranges).Sum(w => w.Max - w.Min + 1);

        List<Day05Range> Merge(List<Day05Range> list)
        {
            bool hasMerged;
            do
            {
                hasMerged = false;
                for (var i = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    for (var j = i + 1; j < list.Count; j++)
                    {
                        var next = list[j];
                        if (current.Min <= next.Min && current.Max >= next.Min
                            || current.Min <= next.Max && current.Max >= next.Max
                            || current.Min >= next.Min && current.Max <= next.Max)
                        {
                            list.Remove(current);
                            list.Remove(next);
                            list.Add(new(Math.Min(current.Min, next.Min), Math.Max(current.Max, next.Max)));
                            
                            hasMerged = true;
                            break;
                        }
                    }

                    if (hasMerged)
                    {
                        break;
                    }
                }

            } while (hasMerged);

            return list;
        }
    }
}