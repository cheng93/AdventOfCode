namespace AdventOfCode2023.Day19;

public class Day19Rule
{
    // x>10:one
    public Day19Rule(string input)
    {
        var splits = input.Split(['>', '<', ':']);

        selectorChar = splits[0][0];
        selector = selectorChar switch
        {
            'x' => (Day19Part p) => p.X,
            'm' => (Day19Part p) => p.M,
            'a' => (Day19Part p) => p.A,
            's' => (Day19Part p) => p.S,
            _ => throw new Exception()
        };

        operationChar = input[1];
        operation = operationChar switch
        {
            '>' => (int a, int b) => a > b,
            '<' => (int a, int b) => a < b,
            _ => throw new Exception()
        };

        number = int.Parse(splits[1]);

        Destination = splits[2];
    }

    private readonly Func<Day19Part, int> selector;

    private readonly char selectorChar;

    private readonly Func<int, int, bool> operation;

    private readonly char operationChar;

    private readonly int number;

    public string Destination { get; }

    public string? Run(Day19Part part)
    {
        var category = selector(part);
        if (operation(category, number))
        {
            return Destination;
        }

        return null;
    }

    public Day19Ranges? Run(Day19Ranges range, out Day19Ranges? other)
    {
        if (operationChar == '<')
        {
            other = range.GetAfter(selectorChar, number - 1);
            return range.GetBefore(selectorChar, number);
        }
        else
        {
            other = range.GetBefore(selectorChar, number + 1);
            return range.GetAfter(selectorChar, number);
        }
    }
}