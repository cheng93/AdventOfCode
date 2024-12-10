using System.Numerics;

namespace AdventOfCode2024.Day10;

public static class Day10Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Dictionary<Complex, int>();
        var trailheads = new List<Complex>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var height = int.Parse(line[j].ToString());
                var point = i + j * Complex.ImaginaryOne;
                grid.Add(point, height);
                if (height == 0)
                {
                    trailheads.Add(point);
                }
            }
        }

        return trailheads.Sum(Walk);

        int Walk(Complex origin)
        {
            var seen = new HashSet<Complex>();
            var stack = new Stack<Complex>();
            stack.Push(origin);
            var sum = 0;

            while (stack.Any())
            {
                var current = stack.Pop();
                var height = grid[current];
                seen.Add(current);
                foreach (var neighbour in GetNeighbours(current))
                {
                    if (seen.Contains(neighbour))
                    {
                        continue;
                    }
                    if (height + 1 == grid[neighbour])
                    {
                        if (height == 8)
                        {
                            sum++;
                            seen.Add(neighbour);
                        }
                        else
                        {
                            stack.Push(neighbour);
                        }
                    }
                }
            }

            return sum;
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
        var grid = new Dictionary<Complex, int>();
        var trailheads = new List<Complex>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var height = int.Parse(line[j].ToString());
                var point = i + j * Complex.ImaginaryOne;
                grid.Add(point, height);
                if (height == 0)
                {
                    trailheads.Add(point);
                }
            }
        }
        var ratings = new Dictionary<Complex, int>();

        return trailheads.Sum(Rating);

        int Rating(Complex origin)
        {
            if (ratings.TryGetValue(origin, out var rating))
            {
                return rating;
            }
            var height = grid[origin];
            if (height == 9)
            {
                ratings.Add(origin, 1);
                return 1;
            }

            var sum = GetNeighbours(origin)
                .Where(x => grid[x] == height + 1)
                .Sum(Rating);

            ratings.Add(origin, sum);
            return sum;
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
}