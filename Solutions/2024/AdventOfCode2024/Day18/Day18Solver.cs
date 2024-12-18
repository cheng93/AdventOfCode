using System.Numerics;

namespace AdventOfCode2024.Day18;

public static class Day18Solver
{
    public static int PuzzleOne(string input, int size = 70, int time = 1024)
    {
        var bytes = input
            .Split(Environment.NewLine)
            .Select(x => x
                .Split(",")
                .Select(int.Parse)
                .ToArray())
            .Select(x => x[0] + x[1] * Complex.ImaginaryOne)
            .ToArray();
        var fallen = new HashSet<Complex>(bytes.Take(time));

        return AStar(size, fallen)!.Value;
    }

    public static string PuzzleTwo(string input, int size = 70, int time = 1024)
    {
        var bytes = input
            .Split(Environment.NewLine)
            .Select(x => x
                .Split(",")
                .Select(int.Parse)
                .ToArray())
            .Select(x => x[0] + x[1] * Complex.ImaginaryOne)
            .ToArray();

        var left = time;
        var right = bytes.Length;
        while (left != right)
        {
            var m = (left + right) / 2;
            var escaped = AStar(size, new(bytes.Take(m))).HasValue;
            if (escaped)
            {
                left = m + 1;
            }
            else
            {
                right = m;
            }
        }

        var b = bytes[left - 1];
        return $"{b.Real},{b.Imaginary}";
    }

    private static int? AStar(int size, HashSet<Complex> fallen)
    {
        var directions = new Complex[]
        {
            1,
            Complex.ImaginaryOne,
            -1,
            -Complex.ImaginaryOne
        };

        var goal = size + size * Complex.ImaginaryOne;
        var queue = new PriorityQueue<Complex, int>();
        var scores = new Dictionary<Complex, int>();
        queue.Enqueue(0, 0);
        scores.Add(queue.Peek(), 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == goal)
            {
                return scores[current];
            }
            for (var i = 0; i < 4; i++)
            {
                var neighbour = current + directions[i];
                if (!InGrid(neighbour) || fallen.Contains(neighbour))
                {
                    continue;
                }
                var tentative = scores[current] + 1;

                if (!scores.TryGetValue(neighbour, out var score) || tentative < score)
                {
                    scores[neighbour] = tentative;
                    queue.Enqueue(neighbour, tentative + ManhattanDistance(neighbour));
                }
            }
        }

        return null;

        bool InGrid(Complex point)
            => point.Real >= 0 && point.Real <= size
                && point.Imaginary >= 0 && point.Imaginary <= size;

        int ManhattanDistance(Complex point)
            => (int)(Math.Abs(point.Real - goal.Real) + Math.Abs(point.Imaginary - goal.Imaginary));
    }
}