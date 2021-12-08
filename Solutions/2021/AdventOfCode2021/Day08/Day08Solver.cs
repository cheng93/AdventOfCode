namespace AdventOfCode2021.Day08;

public static class Day08Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
        => input.SelectMany(x => x.Split(" | ")[1].Split(" "))
            .Count(x => new[] { 2, 4, 3, 7 }.Contains(x.Length));

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var sum = 0;

        foreach (var line in input)
        {
            var splits = line.Split(" | ");
            var display = Day08Display.Create(splits[0]);
            sum += splits[1]
                .Split(" ")
                .Select((x, i) => display.GetValue(x) * (int)Math.Pow(10, 3 - i))
                .Sum();
        }

        return sum;
    }
}