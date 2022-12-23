namespace AdventOfCode2016.Day13;

public class Day13Solver
{
    public static int PuzzleOne(int input, int goalX = 31, int goalY = 39)
        => Solve(input)
            .Single(x => x.Location == (goalX, goalY))
            .Steps;

    public static int PuzzleTwo(int input)
        => Solve(input)
            .TakeWhile(x => x.Steps <= 50)
            .Count();

    private static IEnumerable<((int X, int Y) Location, int Steps)> Solve(int input)
    {
        var directions = new (int X, int Y)[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1),
        };

        var queue = new Queue<(int X, int Y)>();
        queue.Enqueue((1, 1));
        var visited = new Dictionary<(int X, int Y), int>();
        visited[queue.Peek()] = 0;

        while (queue.Any())
        {
            var current = queue.Dequeue();
            yield return (current, visited[current]);

            foreach (var direction in directions)
            {
                var next = (X: current.X + direction.X, Y: current.Y + direction.Y);
                if (next.X < 0 || next.Y < 0
                    || !IsOpenSpace(next)
                    || visited.ContainsKey(next))
                {
                    continue;
                }

                visited[next] = visited[current] + 1;
                queue.Enqueue(next);
            }
        }

        bool IsOpenSpace((int X, int Y) point)
        {
            var (x, y) = point;
            var sum = x * x + 3 * x + 2 * x * y + y + y * y;
            sum += input;

            var binary = Convert.ToString(sum, 2);
            return binary.Count(x => x == '1') % 2 == 0;
        }
    }
}