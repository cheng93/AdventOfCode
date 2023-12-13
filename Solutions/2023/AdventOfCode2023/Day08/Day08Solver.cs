namespace AdventOfCode2023.Day08;

public static class Day08Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var instructions = splits[0];
        var network = splits[1]
            .Split(Environment.NewLine)
            .Select(x => new Day08Node(x))
            .ToDictionary(x => x.Id);

        var steps = 0;
        var nodeId = "AAA";
        var i = 0;

        do
        {
            var node = network[nodeId];
            nodeId = instructions[i] switch
            {
                'L' => node.Left,
                'R' => node.Right,
                _ => throw new Exception()
            };
            steps++;
            i = (i + 1) % instructions.Length;
        }
        while (nodeId != "ZZZ");

        return steps;
    }

    public static long PuzzleTwo(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var instructions = splits[0];
        var network = splits[1]
            .Split(Environment.NewLine)
            .Select(x => new Day08Node(x))
            .ToDictionary(x => x.Id);

        var nodeIds = network.Keys
            .Where(x => x[2] == 'A')
            .ToArray();

        var steps = Enumerable
            .Repeat(0, nodeIds.Length)
            .ToArray();

        for (var i = 0; i < nodeIds.Length; i++)
        {
            var current = nodeIds[i];
            var s = 0;
            while (true)
            {
                var node = network[current];
                current = instructions[s % instructions.Length] switch
                {
                    'L' => node.Left,
                    'R' => node.Right,
                    _ => throw new Exception()
                };
                s++;
                if (current[2] == 'Z')
                {
                    steps[i] = s;
                    break;
                }
            }
        }

        return steps.Aggregate(1L, (agg, cur) => Lcm(agg, cur));

        long Gcd(long x, long y)
        {
            while (y != 0)
            {
                var t = y;
                y = x % y;
                x = t;
            }

            return Math.Abs(x);
        }

        long Lcm(long x, long y)
        {
            return Math.Abs(x * y) / Gcd(x, y);
        }
    }
}