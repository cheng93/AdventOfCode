namespace AdventOfCode2024.Day23;

public static class Day23Solver
{
    public static int PuzzleOne(string input)
    {
        var connections = input
            .Split(Environment.NewLine)
            .Select(x => x.Split("-"))
            .ToArray();

        var network = new Dictionary<string, HashSet<string>>();
        var count = 0;

        foreach (var connection in connections)
        {
            for (var i = 0; i < 2; i++)
            {
                var computer = connection[i];
                if (!network.TryGetValue(computer, out var set))
                {
                    set = new();
                    network.Add(computer, set);
                }
                network[computer].Add(connection[(i + 1) % 2]);
            }

            var intersect = network[connection[0]].ToHashSet();
            intersect.IntersectWith(network[connection[1]]);
            foreach (var third in intersect)
            {
                string[] triConnection = [third, .. connection];
                if (triConnection.Any(x => x.StartsWith("t")))
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static string PuzzleTwo(string input)
    {
        var connections = input
            .Split(Environment.NewLine)
            .Select(x => x.Split("-"))
            .ToArray();

        var network = new Dictionary<string, HashSet<string>>();
        ICollection<string> lanParty = new List<string>();

        foreach (var connection in connections)
        {
            for (var i = 0; i < 2; i++)
            {
                var computer = connection[i];
                if (!network.TryGetValue(computer, out var set))
                {
                    set = new();
                    network.Add(computer, set);
                }
                network[computer].Add(connection[(i + 1) % 2]);
            }
        }

        var seen = new HashSet<string>();

        foreach (var computer in network)
        {
            var queue = new Queue<QueueItem>();
            queue.Enqueue(new(new([computer.Key]), computer.Value));
            seen.Add(Password(queue.Peek().Connections));
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (!current.Neighbours.Any() && current.Connections.Count > lanParty.Count)
                {
                    lanParty = current.Connections;
                    continue;
                }

                foreach (var neighbour in current.Neighbours)
                {
                    var next = new QueueItem(current.Connections.ToHashSet(), current.Neighbours.ToHashSet());
                    next.Connections.Add(neighbour);
                    next.Neighbours.IntersectWith(network[neighbour]);
                    var password = Password(next.Connections);
                    if (seen.Contains(password))
                    {
                        continue;
                    }
                    seen.Add(password);
                    queue.Enqueue(next);
                }
            }
        }

        return Password(lanParty);

        string Password(ICollection<string> group) => string.Join(",", group.OrderBy(x => x));
    }

    private class QueueItem(HashSet<string> connections, HashSet<string> neighbours)
    {
        public HashSet<string> Connections { get; } = connections;
        public HashSet<string> Neighbours { get; } = neighbours;
    }

}