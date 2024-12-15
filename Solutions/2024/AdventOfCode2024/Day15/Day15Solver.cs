using System.Numerics;

namespace AdventOfCode2024.Day15;

public static class Day15Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}").ToArray();
        var lines = splits[0].Split(Environment.NewLine).ToArray();
        var grid = new Dictionary<Complex, char?>();
        Complex robot = 0;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < lines.Length; j++)
            {
                var c = line[j];
                var point = j + i * Complex.ImaginaryOne;
                if (c == '@')
                {
                    robot = point;
                    grid.Add(point, null);
                }
                else
                {
                    grid.Add(point, c != '.' ? c : null);
                }
            }
        }

        var instructions = string.Join(string.Empty, splits[1].Split(Environment.NewLine));
        foreach (var c in instructions)
        {
            var dir = c switch
            {
                '>' => 1,
                'v' => Complex.ImaginaryOne,
                '<' => -1,
                '^' => -Complex.ImaginaryOne,
                _ => throw new Exception()
            };

            var i = 0;
            while (true)
            {
                i++;
                var next = grid[robot + i * dir];
                if (next == 'O')
                {
                    continue;
                }
                if (!next.HasValue)
                {
                    if (i > 1)
                    {
                        grid[robot + dir] = null;
                        grid[robot + i * dir] = 'O';
                    }
                    robot += dir;
                }
                break;
            }
        }

        return grid
            .Where(x => x.Value == 'O')
            .Sum(x => (int)x.Key.Imaginary * 100 + (int)x.Key.Real);
    }

    public static int PuzzleTwo(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}").ToArray();
        var lines = splits[0].Split(Environment.NewLine).ToArray();
        var grid = new Dictionary<Complex, char>();
        Complex robot = 0;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < lines.Length; j++)
            {
                var c = line[j];
                var point = j * 2 + i * Complex.ImaginaryOne;
                var bigPoint = j * 2 + 1 + i * Complex.ImaginaryOne;
                if (c == '@')
                {
                    robot = point;
                    grid.Add(point, '.');
                    grid.Add(bigPoint, '.');
                }
                else if (c == 'O')
                {
                    grid.Add(point, '[');
                    grid.Add(bigPoint, ']');
                }
                else
                {
                    grid.Add(point, c);
                    grid.Add(bigPoint, c);
                }
            }
        }

        var instructions = string.Join(string.Empty, splits[1].Split(Environment.NewLine));
        foreach (var c in instructions)
        {
            var dir = c switch
            {
                '>' => 1,
                'v' => Complex.ImaginaryOne,
                '<' => -1,
                '^' => -Complex.ImaginaryOne,
                _ => throw new Exception()
            };

            var queue = new Queue<Complex>();
            var seen = new HashSet<Complex>();
            queue.Enqueue(robot + dir);
            var move = new Stack<Complex>();
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (seen.Contains(current))
                {
                    continue;
                }
                seen.Add(current);
                var tile = grid[current];
                if (tile == '#')
                {
                    move = null;
                    break;
                }
                if (tile == '.')
                {
                    continue;
                }
                move.Push(current);
                if (dir.Imaginary == 0)
                {
                    move.Push(current + dir);
                    queue.Enqueue(current + 2 * dir);
                }
                else
                {
                    var neighbour = tile == '[' ? current + 1 : current - 1;
                    queue.Enqueue(neighbour);
                    var next = current + dir;
                    queue.Enqueue(next);
                }

            }
            if (move == null)
            {
                continue;
            }
            while (move.Any())
            {
                var current = move.Pop();
                grid[current + dir] = grid[current];
                grid[current] = '.';
            }
            robot += dir;
        }

        return grid
            .Where(x => x.Value == '[')
            .Sum(x => (int)x.Key.Imaginary * 100 + (int)x.Key.Real);
    }
}