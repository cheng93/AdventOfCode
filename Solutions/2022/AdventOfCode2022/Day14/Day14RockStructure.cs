namespace AdventOfCode2022.Day14;

public class Day14RockStructure
{
    // 498,4 -> 498,6 -> 496,6
    public Day14RockStructure(string input)
    {
        var splits = input.Split(" -> ");
        foreach (var split in splits)
        {
            var numbers = split.Split(',').Select(int.Parse).ToArray();
            points.Add((numbers[0], numbers[1]));
        }
    }

    private readonly List<(int X, int Y)> points = new();

    public IEnumerable<(int X, int Y)> GetPath()
    {
        for (var i = 0; i < points.Count; i++)
        {
            var start = points[i];
            if (i == points.Count - 1)
            {
                yield return start;
                break;
            }
            var end = points[i + 1];

            var diff = (X: end.X - start.X, Y: end.Y - start.Y);

            for (var j = 0; j < Math.Abs(diff.X); j++)
            {
                yield return (start.X + Math.Sign(diff.X) * j, start.Y);
            }
            for (var j = 0; j < Math.Abs(diff.Y); j++)
            {
                yield return (start.X, start.Y + Math.Sign(diff.Y) * j);
            }
        }
    }
}