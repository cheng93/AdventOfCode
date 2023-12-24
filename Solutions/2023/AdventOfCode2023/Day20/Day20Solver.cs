namespace AdventOfCode2023.Day20;

public static class Day20Solver
{
    public static long PuzzleOne(string input)
    {
        var modules = input
            .Split(Environment.NewLine)
            .Select<string, IDay20Module>(x => x[0] switch
            {
                '%' => new Day20FlipFlop(x),
                '&' => new Day20Conjunction(x),
                _ => new Day20Broadcast(x)
            })
            .ToDictionary(x => x.Name, x => x);

        var conjuctions = modules
            .Values
            .OfType<Day20Conjunction>()
            .Select(x => x.Name)
            .ToHashSet();

        foreach (var module in modules.Values)
        {
            var destinations = module.Destinations.Where(conjuctions.Contains);
            foreach (var destination in destinations)
            {
                ((Day20Conjunction)modules[destination]).AddSource(module.Name);
            }
        }

        var lowCount = 0;
        var highCount = 0;

        for (var i = 0; i < 1000; i++)
        {
            var queue = new Queue<(string Source, string Destination, bool Low)>();
            queue.Enqueue(("button", "broadcaster", true));
            while (queue.Any())
            {
                var (source, destination, low) = queue.Dequeue();
                if (low)
                {
                    lowCount++;
                }
                else
                {
                    highCount++;
                }

                if (modules.TryGetValue(destination, out var module))
                {
                    foreach (var send in module.Receive(source, low))
                    {
                        queue.Enqueue((destination, send.Destination, send.Low));
                    }
                }
            }
        }

        return 1L * lowCount * highCount;
    }

    public static long PuzzleTwo(string input)
    {
        var modules = input
            .Split(Environment.NewLine)
            .Select<string, IDay20Module>(x => x[0] switch
            {
                '%' => new Day20FlipFlop(x),
                '&' => new Day20Conjunction(x),
                _ => new Day20Broadcast(x)
            })
            .ToDictionary(x => x.Name, x => x);

        var conjuctions = modules
            .Values
            .OfType<Day20Conjunction>()
            .Select(x => x.Name)
            .ToHashSet();

        foreach (var module in modules.Values)
        {
            var destinations = module.Destinations.Where(conjuctions.Contains);
            foreach (var destination in destinations)
            {
                ((Day20Conjunction)modules[destination]).AddSource(module.Name);
            }
        }

        var query = new[] { "dd", "fh", "xp", "fc" };
        var seen = new Dictionary<string, int>();
        var i = 0;
        while (true)
        {
            var queue = new Queue<(string Source, string Destination, bool Low)>();
            queue.Enqueue(("button", "broadcaster", true));
            while (queue.Any())
            {
                var (source, destination, low) = queue.Dequeue();

                if (modules.TryGetValue(destination, out var module))
                {
                    if (i > 0
                        && query.Contains(destination)
                        && module is Day20Conjunction conjunction
                        && !conjunction.Low)
                    {
                        seen[destination] = i + 1;
                    }

                    if (seen.Count == query.Length)
                    {
                        return seen
                            .Values
                            .Aggregate(1L, (agg, cur) => Lcm(agg, cur));
                    }

                    foreach (var send in module.Receive(source, low))
                    {
                        queue.Enqueue((destination, send.Destination, send.Low));
                    }
                }
            }
            i++;
        }

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