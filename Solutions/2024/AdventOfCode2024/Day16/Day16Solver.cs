using System.Numerics;

namespace AdventOfCode2024.Day16;

public static class Day16Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var set = new HashSet<Complex>();
        var origin = Complex.Zero;
        var goal = Complex.Zero;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                var point = j + i * Complex.ImaginaryOne;
                if (c == 'E')
                {
                    goal = point;
                }
                else if (c == 'S')
                {
                    origin = point;
                }
                if (c != '#')
                {
                    set.Add(point);
                }
            }
        }

        var queue = new PriorityQueue<Day16Reindeer, int>();
        var scores = new Dictionary<Day16Reindeer, int>();
        queue.Enqueue(new(origin, 1), 0);
        scores[queue.Peek()] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Position == goal)
            {
                return scores[current];
            }

            Complex factor = 1;
            for (var i = 0; i < 4; i++)
            {
                var direction = current.Direction * factor;
                var neighbour = current.Position + direction;
                var next = new Day16Reindeer(neighbour, direction);
                factor *= Complex.ImaginaryOne;
                if (!set.Contains(neighbour))
                {
                    continue;
                }
                var tentative = scores[current] + 1000 * i + 1;
                if (i == 3)
                {
                    tentative -= 2000;
                }
                if (!scores.TryGetValue(next, out var score) || tentative < score)
                {
                    scores[next] = tentative;
                    queue.Enqueue(next, tentative);
                }
            }
        }

        throw new Exception();
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var set = new HashSet<Complex>();
        var origin = Complex.Zero;
        var goal = Complex.Zero;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                var point = j + i * Complex.ImaginaryOne;
                if (c == 'E')
                {
                    goal = point;
                }
                else if (c == 'S')
                {
                    origin = point;
                }
                if (c != '#')
                {
                    set.Add(point);
                }
            }
        }

        var queue = new PriorityQueue<Day16Reindeer, int>();
        var scores = new Dictionary<Day16Reindeer, int>();
        var paths = new Dictionary<Day16Reindeer, HashSet<Day16Reindeer>>();
        queue.Enqueue(new(origin, 1), 0);
        scores[queue.Peek()] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Position == goal)
            {
                break;
            }

            Complex factor = 1;
            for (var i = 0; i < 4; i++)
            {
                var direction = current.Direction * factor;
                var neighbour = current.Position;
                var tentative = scores[current] + 1000 * i;
                if (i == 0)
                {
                    neighbour += direction;
                    tentative++;
                }
                if (i == 3)
                {
                    tentative -= 2000;
                }
                var next = new Day16Reindeer(neighbour, direction);
                factor *= Complex.ImaginaryOne;
                if (!set.Contains(neighbour))
                {
                    continue;
                }
                if (!scores.TryGetValue(next, out var score) || tentative <= score)
                {
                    scores[next] = tentative;
                    queue.Enqueue(next, tentative);
                    if (!paths.TryGetValue(next, out var p))
                    {
                        p = new();
                        paths.Add(next, p);
                    }
                    if (tentative < score)
                    {
                        p.Clear();
                    }
                    p.Add(current);
                }
            }
        }

        var tiles = new HashSet<Complex>();

        var stack = new Stack<Day16Reindeer>();
        var seen = new HashSet<Day16Reindeer>();
        var directions = new[]
        {
            1,
            Complex.ImaginaryOne,
            -1,
            -Complex.ImaginaryOne
        };
        foreach (var direction in directions)
        {
            stack.Push(new(goal, direction));
        }
        while (stack.Any())
        {
            var current = stack.Pop();
            if (seen.Contains(current))
            {
                continue;
            }
            seen.Add(current);
            tiles.Add(current.Position);

            if (paths.TryGetValue(current, out var from))
            {
                foreach (var p in from)
                {
                    stack.Push(p);
                }
            }
        }

        return tiles.Count;
    }
}