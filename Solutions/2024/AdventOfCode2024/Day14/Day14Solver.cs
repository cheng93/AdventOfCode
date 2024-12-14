using System.Numerics;

namespace AdventOfCode2024.Day14;

public static class Day14Solver
{
    public static int PuzzleOne(string input, int width = 101, int height = 103)
    {
        return input
            .Split(Environment.NewLine)
            .Select(x => Simulate(new Day14Robot(x), 100))
            .Where(x => x.Real != width / 2 && x.Imaginary != height / 2)
            .GroupBy(x => (x.Real < width / 2, x.Imaginary < height / 2))
            .Aggregate(1, (agg, cur) => agg * cur.Count());

        Complex Simulate(Day14Robot robot, int seconds)
        {
            var x = robot.Position.Real + seconds * (robot.Velocity.Real + width);
            var y = robot.Position.Imaginary + seconds * (robot.Velocity.Imaginary + height);

            return x % width + y % height * Complex.ImaginaryOne;
        }
    }

    public static int PuzzleTwo(string input, int width = 101, int height = 103)
    {
        var robots = input
            .Split(Environment.NewLine)
            .Select(x => new Day14Robot(x))
            .ToArray();
        var seen = new HashSet<string>();

        var i = 0;
        while (true)
        {
            i++;
            var set = robots.Select(x => Simulate(x, i)).ToHashSet();
            var bound = set.Count(x => x.Real > width / 4 && x.Real < width * 3 / 4);
            if (bound > robots.Length * 0.73)
            {
                Print(set);
                return i;
            }
        }

        Complex Simulate(Day14Robot robot, int seconds)
        {
            var x = robot.Position.Real + seconds * (robot.Velocity.Real + width);
            var y = robot.Position.Imaginary + seconds * (robot.Velocity.Imaginary + height);

            return x % width + y % height * Complex.ImaginaryOne;
        }

        void Print(HashSet<Complex> points)
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (points.Contains(j + i * Complex.ImaginaryOne))
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
