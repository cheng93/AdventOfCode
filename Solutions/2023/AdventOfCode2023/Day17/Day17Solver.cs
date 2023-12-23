namespace AdventOfCode2023.Day17;

using Coord = (int X, int Y);

public static class Day17Solver
{
    public static int PuzzleOne(string input) => Solve(input, 0, 3);

    public static int PuzzleTwo(string input) => Solve(input, 4, 10);

    private static int Solve(string input, int min, int max)
    {
        var lines = input.Split(Environment.NewLine);

        var map = new Dictionary<Coord, int>();
        var lengthX = lines[0].Length;
        var lengthY = lines.Length;
        for (var y = 0; y < lengthY; y++)
        {
            for (var x = 0; x < lengthX; x++)
            {
                map.Add((x, y), int.Parse(lines[y][x].ToString()));
            }
        }

        var modifiers = new Coord[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };

        var queue = new PriorityQueue<(Coord Position, int Direction, int Steps), int>();
        queue.Enqueue(((0, 0), 0, 0), 0);
        var seen = new HashSet<(Coord Position, int Direction, int Steps)>();

        while (queue.TryPeek(out var _, out var totalHeatLoss))
        {
            var current = queue.Dequeue();
            var (position, direction, steps) = current;

            if (position == (lengthX - 1, lengthY - 1) && steps >= min)
            {
                return totalHeatLoss;
            }

            if (seen.Contains(current))
            {
                continue;
            }

            seen.Add(current);

            if (steps >= min || steps == 0)
            {
                Move(position, (direction + 5) % 4, 1);
                Move(position, (direction + 3) % 4, 1);
            }

            if (steps < max)
            {
                Move(position, direction, steps + 1);
            }

            void Move(Coord position, int direction, int steps)
            {
                var modifier = modifiers[direction];
                var newPosition = (position.X + modifier.X, position.Y + modifier.Y);
                if (map.TryGetValue(newPosition, out var heatLoss))
                {
                    queue.Enqueue((newPosition, direction, steps), totalHeatLoss + heatLoss);
                }
            }
        }

        throw new Exception();
    }
}