namespace AdventOfCode2023.Day12;

public class Day12Row
{
    // input: ???.### 1,1,3
    public Day12Row(string input)
    {
        var splits = input.Split(' ');

        Condition = splits[0];
        Lengths = splits[1]
            .Split(',')
            .Select(int.Parse)
            .ToArray();
    }

    private Day12Row(string condition, int[] lengths)
    {
        Condition = condition;
        Lengths = lengths;
    }

    public string Condition { get; }

    public int[] Lengths { get; }

    public Day12Row Unfold()
    {
        var condition = string.Join('?', Enumerable.Repeat(Condition, 5));
        var lengths = Enumerable
            .Repeat(Lengths, 5)
            .SelectMany(x => x)
            .ToArray();

        return new(condition, lengths);
    }
}