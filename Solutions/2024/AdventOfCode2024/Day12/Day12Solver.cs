using System.Numerics;

namespace AdventOfCode2024.Day12;

public static class Day12Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Dictionary<Complex, char>();
        var points = new HashSet<Complex>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var point = i + j * Complex.ImaginaryOne;
                grid.Add(point, line[j]);
                points.Add(point);
            }
        }

        var sum = 0;

        while (points.Any())
        {
            var current = points.First();
            sum += GetPrice(current);
        }

        return sum;

        int GetPrice(Complex point)
        {
            var queue = new Queue<Complex>();
            queue.Enqueue(point);
            points.Remove(point);
            var area = 0;
            var perimeter = 0;
            var plant = grid[point];

            while (queue.Any())
            {
                var current = queue.Dequeue();
                var plotParameter = 4;
                area++;
                var neighbours = GetNeighbours(current).Where(x => grid[x] == plant);
                foreach (var neighbour in neighbours)
                {
                    plotParameter--;
                    if (points.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        points.Remove(neighbour);
                    }
                }
                perimeter += plotParameter;
            }
            return area * perimeter;
        }

        IEnumerable<Complex> GetNeighbours(Complex origin)
        {
            var directions = new Complex[]
            {
                1,
                Complex.ImaginaryOne,
                -1,
                Complex.ImaginaryOne * -1
            };
            return directions
                .Select(x => origin + x)
                .Where(grid.ContainsKey);
        }
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Dictionary<Complex, char>();
        var points = new HashSet<Complex>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var point = i + j * Complex.ImaginaryOne;
                grid.Add(point, line[j]);
                points.Add(point);
            }
        }

        var sum = 0;

        while (points.Any())
        {
            var current = points.First();
            sum += GetPrice(current);
        }

        return sum;

        int GetPrice(Complex point)
        {
            var queue = new Queue<Complex>();
            queue.Enqueue(point);
            points.Remove(point);
            var area = 0;
            var perimeter = 0;
            var sides = Enumerable
                .Range(0, 4)
                .Select(x => new HashSet<Complex>())
                .ToArray();
            var directions = new Complex[]
            {
                    1,
                    Complex.ImaginaryOne,
                    -1,
                    Complex.ImaginaryOne * -1
            };

            while (queue.Any())
            {
                var current = queue.Dequeue();
                area++;
                for (var i = 0; i < directions.Length; i++)
                {
                    var neighbour = current + directions[i];
                    if (grid.TryGetValue(neighbour, out var plant)
                        && plant == grid[current])
                    {
                        if (points.Contains(neighbour))
                        {
                            queue.Enqueue(neighbour);
                            points.Remove(neighbour);
                        }
                    }
                    else
                    {
                        sides[i].Add(current);
                    }
                }
            }
            for (var i = 0; i < 4; i++)
            {
                var side = sides[i];
                while (side.Any())
                {
                    perimeter++; ;
                    queue.Enqueue(side.First());
                    side.Remove(side.First());
                    while (queue.Any())
                    {
                        var current = queue.Dequeue();
                        for (var j = 0; j < 2; j++)
                        {
                            var direction = directions[(i + 1 + 2 * j) % 4];
                            var next = current + direction;
                            if (side.Contains(next))
                            {
                                side.Remove(next);
                                queue.Enqueue(next);
                            }
                        }
                    }
                }

            }
            return area * perimeter;
        }
    }
}