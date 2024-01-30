namespace AdventOfCode2015.Day14;

public static class Day14Solver
{
    public static int PuzzleOne(string input, int seconds = 2503)
    {
        var reindeers = input
            .Split(Environment.NewLine)
            .Select(x => new Day14Reindeer(x))
            .ToArray();

        var max = int.MinValue;

        foreach (var reindeer in reindeers)
        {
            var time = reindeer.Fly.Time + reindeer.Rest;
            var quotient = seconds / time;
            var remainder = seconds % time;

            var distance = reindeer.Fly.Speed * (quotient * reindeer.Fly.Time + Math.Min(reindeer.Fly.Time, remainder));
            max = Math.Max(max, distance);
        }

        return max;
    }

    public static int PuzzleTwo(string input, int seconds = 2503)
    {
        var reindeers = input
            .Split(Environment.NewLine)
            .Select(x => new Day14Reindeer(x))
            .ToArray();

        var distance = reindeers.Select(x => 0).ToArray();
        var points = reindeers.Select(x => 0).ToArray();

        for (var i = 0; i < seconds; i++)
        {
            for (var j = 0; j < reindeers.Length; j++)
            {
                var reindeer = reindeers[j];
                var time = reindeer.Fly.Time + reindeer.Rest;
                var remainder = i % time;
                if (remainder < reindeer.Fly.Time)
                {
                    distance[j] += reindeer.Fly.Speed;
                }
            }

            var indices = distance
                .Select((x, i) => new
                {
                    Distance = x,
                    Index = i
                })
                .Where(x => x.Distance == distance.Max())
                .Select(x => x.Index);

            foreach (var j in indices)
            {
                points[j]++;
            }
        }

        return points.Max();
    }
}