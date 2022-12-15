namespace AdventOfCode2022.Day15;

public static class Day15Solver
{
    public static int PuzzleOne(IEnumerable<string> input, int y = 2000000)
    {
        var sensors = input.Select(x => new Day15Sensor(x)).ToArray();
        var row = new HashSet<int>();
        foreach (var sensor in sensors)
        {
            foreach (var scan in sensor.ScanY(y))
            {
                if (sensor.Beacon == (scan, y))
                {
                    continue;
                }

                row.Add(scan);
            }
        }

        return row.Count;
    }

    public static long PuzzleTwo(IEnumerable<string> input, int max = 4000000)
    {
        var sensors = input.Select(x => new Day15Sensor(x)).ToArray();
        for (var i = 0; i < sensors.Length; i++)
        {
            var sensor = sensors[i];
            var points = sensor
                .GetPerimeter()
                .Where(x => x.X > 0 && x.X <= max && x.Y > 0 && x.Y <= max);
            foreach (var point in points)
            {
                var overlaps = false;
                for (var j = 0; j < sensors.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var other = sensors[j];
                    if (other.Contains(point))
                    {
                        overlaps = true;
                    }
                }

                if (!overlaps)
                {
                    return point.X * 4000000L + point.Y;
                }
            }
        }

        throw new Exception();
    }
}