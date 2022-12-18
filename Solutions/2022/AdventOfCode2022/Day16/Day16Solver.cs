namespace AdventOfCode2022.Day16;

public static class Day16Solver
{
    public static int PuzzleOne(IEnumerable<string> input) => Solve(input, 30, 0);

    public static long PuzzleTwo(IEnumerable<string> input) => Solve(input, 26, 1);

    private static int Solve(IEnumerable<string> input, int maxTime, int elephants)
    {
        var valves = input
            .Select(x => new Day16Valve(x))
            .ToDictionary(x => x.Id, x => x);

        var distances = valves.ToDictionary(x => x.Key, x => Dijkstra(x.Key));
        var vertices = valves.Where(x => x.Value.FlowRate > 0).Select(x => x.Key).ToArray();

        var cache = new Dictionary<string, int>();

        return Dfs("AA", maxTime, vertices, elephants);

        int Dfs(string current, int time, string[] rest, int elephants)
        {
            if (time == 0)
            {
                return 0;
            }

            var hash = $"{current}{time}{string.Join("", rest)}{elephants}";
            if (cache.TryGetValue(hash, out var cached))
            {
                return cached;
            }

            var max = elephants > 0 ? Dfs("AA", maxTime, rest, elephants - 1) : 0;
            foreach (var next in rest)
            {
                var valve = valves[next];
                var distance = distances[current][next];
                var remainingTime = time - distance - 1;
                if (remainingTime < 0)
                {
                    continue;
                }

                var newRest = rest.Where(x => x != next).ToArray();
                var pressure = valve.FlowRate * remainingTime + Dfs(next, remainingTime, newRest, elephants);
                max = Math.Max(max, pressure);
            }

            cache[hash] = max;
            return max;
        }

        Dictionary<string, int> Dijkstra(string source)
        {
            var queue = new PriorityQueue<string, int>();

            var dist = new Dictionary<string, int>();
            var prev = new Dictionary<string, string?>();
            foreach (var v in valves.Keys)
            {
                dist[v] = v == source ? 0 : int.MaxValue;
                prev[v] = null;
            }

            queue.Enqueue(source, 0);

            while (queue.Count != 0)
            {
                var u = queue.Dequeue();
                var valve = valves[u];

                foreach (var v in valve.Next)
                {
                    var alt = dist[u] + 1;
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                        queue.Enqueue(v, alt);
                    }
                }
            }

            return dist;
        }
    }
}