namespace AdventOfCode2021.Day12;

public static class Day12Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var map = input
            .SelectMany(x => new Day12Path(x).ToMap())
            .GroupBy(x => x.Start, x => x.End)
            .ToDictionary(x => x.Key, x => x.ToArray());

        IEnumerable<IEnumerable<string>> Explore(string root, List<string> path)
        {
            var destinations = map[root];
            foreach (var destination in destinations)
            {
                var copied = path.ToList();
                if (destination == "end")
                {
                    copied.Add(destination);
                    yield return copied;
                }
                else if (destination != destination.ToLower()
                    || !path.Contains(destination))
                {
                    copied.Add(destination);
                    var exploredPaths = Explore(destination, copied);
                    foreach (var exploredPath in exploredPaths)
                    {
                        yield return exploredPath;
                    }
                }
            }
        }

        var explored = Explore("start", new List<string> { "start" });

        return explored.Count();
    }

    public static long PuzzleTwo(IEnumerable<string> input)
    {
        var map = input
            .SelectMany(x => new Day12Path(x).ToMap())
            .GroupBy(x => x.Start, x => x.End)
            .ToDictionary(x => x.Key, x => x.ToArray());

        IEnumerable<IEnumerable<string>> Explore(string root, List<string> path)
        {
            var destinations = map[root];
            foreach (var destination in destinations)
            {
                var copied = path.ToList();
                if (destination == "end")
                {
                    copied.Add(destination);
                    yield return copied;
                }
                else if (destination == "start")
                {
                    continue;
                }
                else if (destination != destination.ToLower()
                    || (!path.Contains(destination)
                        || path.Where(x => x == x.ToLower())
                                .GroupBy(x => x)
                                .All(x => x.Count() == 1)))
                {
                    copied.Add(destination);
                    var exploredPaths = Explore(destination, copied);
                    foreach (var exploredPath in exploredPaths)
                    {
                        yield return exploredPath;
                    }
                }
            }
        }

        var explored = Explore("start", new List<string> { "start" });

        return explored.Count();
    }
}