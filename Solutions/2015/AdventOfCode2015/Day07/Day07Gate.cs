namespace AdventOfCode2015.Day07;

public class Day07Gate
{
    // 123 -> x
    // x AND y -> z
    // NOT e -> f
    public Day07Gate(string input)
    {
        var splits = input.Split(' ');
        if (splits.Length == 3)
        {
            var a = splits[0];
            Inputs = [a];
            Run = x => GetValue(x, a);
        }
        else if (splits.Length == 4)
        {
            var a = splits[1];
            Inputs = [a];
            Run = x => ~GetValue(x, a);
        }
        else
        {
            var a = splits[0];
            var op = splits[1];
            var b = splits[2];
            Inputs = [a, b];

            Run = op switch
            {
                "AND" => x => GetValue(x, a) & GetValue(x, b),
                "OR" => x => GetValue(x, a) | GetValue(x, b),
                "LSHIFT" => x => GetValue(x, a) << GetValue(x, b),
                "RSHIFT" => x => GetValue(x, a) >> GetValue(x, b),
                _ => throw new Exception()
            };
        }
        Inputs = Inputs
                .Where(x => !int.TryParse(x, out var _))
                .ToArray();
        Output = splits.Last();

        int GetValue(Dictionary<string, int> x, string y)
            => int.TryParse(y, out var parsed)
                ? parsed
                : x[y];
    }

    public string[] Inputs { get; }

    public string Output { get; }

    public Func<Dictionary<string, int>, int> Run { get; }
}