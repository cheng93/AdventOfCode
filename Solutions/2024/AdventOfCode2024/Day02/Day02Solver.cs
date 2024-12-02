namespace AdventOfCode2024.Day02;

public static class Day02Solver
{
    public static int PuzzleOne(string input) => Solve(input, 0);

    public static int PuzzleTwo(string input) => Solve(input, 1);

    private static int Solve(string input, int tolerance)
    {
        return input
            .Split(Environment.NewLine)
            .Select(x => new Day02Report(x))
            .Count(IsSafe);

        bool IsSafe(Day02Report report)
        {
            var queue = new Queue<QueueItem>();
            queue.Enqueue(new(report.Levels[0], 1, null, tolerance));

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current.Tolerance >= report.Levels.Length - current.Index)
                {
                    return true;
                }

                var level = report.Levels[current.Index];
                var diff = current.Previous - level;
                var magnitude = Math.Abs(diff);
                var sign = Math.Sign(diff);

                if ((current.Sign ?? sign) == sign
                    && magnitude is >= 1 and <= 3)
                {
                    if (current.Index == report.Levels.Length - 1)
                    {
                        return true;
                    }
                    queue.Enqueue(current with { Previous = level, Index = current.Index + 1, Sign = sign });
                }
                if (current.Tolerance > 0)
                {
                    queue.Enqueue(current with { Index = current.Index + 1, Tolerance = current.Tolerance - 1 });
                    if (current.Sign == null)
                    {
                        queue.Enqueue(current with { Previous = level, Index = current.Index + 1, Tolerance = current.Tolerance - 1 });
                    }
                }
            }

            return false;
        }
    }

    private record QueueItem(int Previous, int Index, int? Sign, int Tolerance);
}