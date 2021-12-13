using System.Text;

namespace AdventOfCode2021.Day13;

public static class Day13Solver
{
    public static int PuzzleOne(string input)
        => Solve(input).First().Count;

    public static string PuzzleTwo(string input)
    {
        var paper = Solve(input).Last();

        var maxX = paper.Max(x => x.X);
        var maxY = paper.Max(x => x.Y);

        var sb = new StringBuilder();
        for (var y = 0; y <= maxY; y++)
        {
            for (var x = 0; x <= maxX; x++)
            {
                sb.Append(paper.Contains((x, y)) ? '█' : ' ');
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private static IEnumerable<HashSet<(int X, int Y)>> Solve(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var coords = splits[0]
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
            {
                var y = x.Split(",").Select(int.Parse).ToArray();

                return (X: y[0], Y: y[1]);
            });
        var paper = new HashSet<(int X, int Y)>(coords);

        var instructions = splits[1]
            .Split(Environment.NewLine)
            .Select(x => new Day13Instruction(x));

        foreach (var instruction in instructions)
        {
            paper = instruction.Fold(paper);
            yield return paper;
        }
    }
}