namespace AdventOfCode2022.Day09;

public static class Day09Solver
{
    public static int PuzzleOne(IEnumerable<string> input) => SimulateKnots(input, 2);

    public static int PuzzleTwo(IEnumerable<string> input) => SimulateKnots(input, 10);

    private static int SimulateKnots(IEnumerable<string> input, int length)
    {
        var motions = input
            .Select(x => new Day09Motion(x))
            .ToArray();

        var origin = (X: 0, Y: 0);
        var knots = Enumerable
            .Range(0, length)
            .Select(_ => origin)
            .ToArray();

        var visited = new HashSet<(int X, int Y)>();
        visited.Add(origin);

        var moves = new Dictionary<string, (int X, int Y)>()
        {
            { "R", (1, 0) },
            { "U", (0, 1) },
            { "L", (-1, 0) },
            { "D", (0, -1) },
        };

        foreach (var motion in motions)
        {
            for (var i = 0; i < motion.Steps; i++)
            {
                var move = moves[motion.Direction];
                knots[0].X += move.X;
                knots[0].Y += move.Y;

                for (var j = 1; j < knots.Length; j++)
                {
                    var current = knots[j];
                    var previous = knots[j - 1];
                    var differenceX = previous.X - current.X;
                    var differenceY = previous.Y - current.Y;

                    if (Math.Abs(differenceX) <= 1 && Math.Abs(differenceY) <= 1)
                    {
                        break;
                    }
                    current.X += Math.Sign(differenceX);
                    current.Y += Math.Sign(differenceY);

                    knots[j] = current;
                }

                visited.Add(knots.Last());
            }
        }

        return visited.Count;
    }
}