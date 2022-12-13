namespace AdventOfCode2022.Day13;

public static class Day13Solver
{
    public static int PuzzleOne(IEnumerable<string[]> input)
    {
        var pairs = input.ToArray();

        var sum = 0;
        for (var i = 0; i < pairs.Length; i++)
        {
            var pair = pairs[i].Select(x => Day13PacketList.Create(x)).ToArray();
            if (pair[0].CompareTo(pair[1]) == -1)
            {
                sum += i + 1;
            }
        }

        return sum;
    }

    public static int PuzzleTwo(IEnumerable<string[]> input)
    {
        var dividers = new[] { "[[2]]", "[[6]]" }
            .Select(x => Day13PacketList.Create(x))
            .ToArray();

        var pairs = input.SelectMany(x => x.Select(y => Day13PacketList.Create(y)));
        var packets = pairs
            .Concat(dividers)
            .OrderBy(x => x)
            .ToList();

        return dividers
            .Select(x => packets.IndexOf(x) + 1)
            .Aggregate((agg, cur) => agg * cur);
    }
}