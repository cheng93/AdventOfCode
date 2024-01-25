namespace AdventOfCode2015.Day09;

public static class Day09Solver
{
    public static int PuzzleOne(string input)
    {
        var flights = input
            .Split(Environment.NewLine)
            .Select(x => new Day09Flight(x))
            .ToArray();

        var lookup = flights
            .GroupBy(x => x.From)
            .ToDictionary(
                x => x.Key,
                x => x.ToDictionary(
                    y => y.To,
                    y => y.Distance
                )
            );

        var locations = flights
            .Select(x => x.To)
            .Concat(flights.Select(x => x.From))
            .Distinct()
            .ToArray();

        return locations
            .Select((x) => Fly(0, [x]))
            .Min();

        int Fly(int total, List<string> path)
        {
            if (path.Count == locations.Length)
            {
                return total;
            }
            var current = path.Last();
            var min = int.MaxValue;
            foreach (var location in locations)
            {
                if (path.Contains(location))
                {
                    continue;
                }

                var distance = GetDistance(current, location);
                var newPath = path.ToList();
                newPath.Add(location);

                var flight = Fly(total + distance, newPath);
                min = Math.Min(min, flight);
            }

            return min;
        }

        int GetDistance(string from, string to)
            => lookup.TryGetValue(from, out var fromLookup) && fromLookup.TryGetValue(to, out var dist)
                ? dist
                : lookup[to][from];
    }

    public static int PuzzleTwo(string input)
    {
        var flights = input
            .Split(Environment.NewLine)
            .Select(x => new Day09Flight(x))
            .ToArray();

        var lookup = flights
            .GroupBy(x => x.From)
            .ToDictionary(
                x => x.Key,
                x => x.ToDictionary(
                    y => y.To,
                    y => y.Distance
                )
            );

        var locations = flights
            .Select(x => x.To)
            .Concat(flights.Select(x => x.From))
            .Distinct()
            .ToArray();

        return locations
            .Select((x) => Fly(0, [x]))
            .Max();

        int Fly(int total, List<string> path)
        {
            if (path.Count == locations.Length)
            {
                return total;
            }
            var current = path.Last();
            var max = int.MinValue;
            foreach (var location in locations)
            {
                if (path.Contains(location))
                {
                    continue;
                }

                var distance = GetDistance(current, location);
                var newPath = path.ToList();
                newPath.Add(location);

                var flight = Fly(total + distance, newPath);
                max = Math.Max(max, flight);
            }

            return max;
        }

        int GetDistance(string from, string to)
            => lookup.TryGetValue(from, out var fromLookup) && fromLookup.TryGetValue(to, out var dist)
                ? dist
                : lookup[to][from];
    }
}