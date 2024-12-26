using System.Numerics;

namespace AdventOfCode2024.Day20;

public static class Day20Solver
{
    public static int PuzzleOne(string input, int save = 100) => Solve(input, 2, save);

    public static int PuzzleTwo(string input, int save = 100) => Solve(input, 20, save);

    private static int Solve(string input, int cheatTime, int save = 100)
    {
        var lines = input.Split(Environment.NewLine);

        var track = new HashSet<Complex>();
        var walls = new HashSet<Complex>();
        Complex start = 0;
        Complex end = 0;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                var point = j + i * Complex.ImaginaryOne;
                if (c == 'S')
                {
                    start = point;
                }
                else if (c == 'E')
                {
                    end = point;
                }
                if (c == '#')
                {
                    walls.Add(point);
                }
                else
                {
                    track.Add(point);
                }
            }
        }

        var directions = new[] { 1, Complex.ImaginaryOne, -1, -Complex.ImaginaryOne };

        var queue = new PriorityQueue<Complex, int>();
        var scores = new Dictionary<Complex, int>();
        queue.Enqueue(start, 0);
        scores[queue.Peek()] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == end)
            {
                break;
            }
            for (var i = 0; i < 4; i++)
            {
                var neighbour = current + directions[i];
                if (!track.Contains(neighbour))
                {
                    continue;
                }
                var tentative = scores[current] + 1;
                if (!scores.TryGetValue(neighbour, out var score) || tentative < score)
                {
                    scores[neighbour] = tentative;
                    queue.Enqueue(neighbour, tentative);
                }
            }
        }

        var cheats = 0;
        foreach (var score in scores)
        {
            var seen = new HashSet<Complex> { score.Key };
            var q = new Queue<Complex>();
            q.Enqueue(seen.First());
            for (var i = 0; i <= cheatTime; i++)
            {
                var newQ = new Queue<Complex>();
                while (q.Any())
                {
                    var current = q.Dequeue();
                    if (i == cheatTime && !track.Contains(current))
                    {
                        continue;
                    }
                    if (scores.TryGetValue(current, out var nonCheatScore)
                        && score.Value + i <= nonCheatScore - save)
                    {
                        cheats++;
                    }
                    for (var j = 0; j < 4; j++)
                    {
                        var neighbour = current + directions[j];
                        if (seen.Contains(neighbour)
                            || (!track.Contains(neighbour) && !walls.Contains(neighbour)))
                        {
                            continue;
                        }
                        seen.Add(neighbour);
                        newQ.Enqueue(neighbour);
                    }
                }
                q = newQ;
            }
        }

        return cheats;
    }
}