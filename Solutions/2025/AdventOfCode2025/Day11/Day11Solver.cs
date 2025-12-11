namespace AdventOfCode2025.Day11;

public static class Day11Solver
{
    public static int PuzzleOne(string input)
    {
        var lookup = input.Split(Environment.NewLine)
            .Select(l => new Day11Device(l))
            .ToDictionary(d => d.Name, d => d.Outputs);

        var queue = new Queue<string>();
        queue.Enqueue("you");

        var count = 0;

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (current == "out")
            {
                count++;
                continue;
            }
            
            foreach (var device in lookup[current])
            {
                queue.Enqueue(device);
            }
        }

        return count;
    }

    public static long PuzzleTwo(string input)
    {
        var lookup = input.Split(Environment.NewLine)
            .Select(l => new Day11Device(l))
            .ToDictionary(d => d.Name, d => d.Outputs);
        
        var cache = new Dictionary<(string, bool, bool), long>();

        return Traverse("svr", false, false);

        long Traverse(string device, bool dac, bool fft)
        {
            if (cache.TryGetValue((device, dac, fft), out var cached))
            {
                return cached;
            }

            var sum = 0L;
            foreach (var next in lookup[device])
            {
                if (next == "out")
                {
                    if (dac && fft)
                    {
                        sum++;
                    }
                }
                else
                {
                    sum += Traverse(next, dac || device == "dac", fft || device == "fft");
                }
            }
            
            cache.Add((device, dac, fft), sum);
            return sum;
        }
    }
}