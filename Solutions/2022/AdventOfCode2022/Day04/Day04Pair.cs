namespace AdventOfCode2022.Day04;

public class Day04Pair
{
    // 2-4,6-8
    public Day04Pair(string input)
    {
        var splits = input.Split(",");
        var assignments = splits
            .Select(x =>
            {
                var s = x
                    .Split("-")
                    .Select(int.Parse)
                    .ToList();
                return new Day04Interval(s.First(), s.Last());
            })
            .ToList();
        First = assignments.First();
        Last = assignments.Last();

    }

    public Day04Interval First { get; }

    public Day04Interval Last { get; }
}