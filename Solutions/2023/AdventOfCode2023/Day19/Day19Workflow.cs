namespace AdventOfCode2023.Day19;

public class Day19Workflow
{
    // px{a<2006:qkq,m>2090:A,rfg}
    public Day19Workflow(string input)
    {
        var splits = input.Split(new char[] { '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries);
        Name = splits[0];
        rules = splits[1..^1]
            .Select(x => new Day19Rule(x))
            .ToArray();
        final = splits[^1];
    }

    private readonly Day19Rule[] rules;

    private readonly string final;

    public string Name { get; }

    public string Run(Day19Part part)
    {
        foreach (var rule in rules)
        {
            var result = rule.Run(part);
            if (result != null)
            {
                return result;
            }
        }
        return final;
    }

    public IEnumerable<(Day19Ranges Ranges, string Destination)> Run(Day19Ranges ranges)
    {
        var current = ranges;
        foreach (var rule in rules)
        {
            var newRange = rule.Run(current, out current);
            if (newRange != null)
            {
                yield return (newRange, rule.Destination);
            }

            if (current == null)
            {
                yield break;
            }
        }

        if (current != null)
        {
            yield return (current, final);
        }
    }
}