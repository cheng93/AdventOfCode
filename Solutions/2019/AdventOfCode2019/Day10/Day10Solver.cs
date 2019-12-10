using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2019.Day10
{
    public class Day10Solver
    {
        public (Point, int) PuzzleOne(string input)
        {
            var asteroids = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany((x, i) =>
                    x.Select((y, j) => new
                    {
                        Point = new Point(j, i),
                        Value = y
                    }))
                .Where(x => x.Value == '#')
                .ToDictionary(x => x.Point, x => x.Value);

            var visible = asteroids.ToDictionary(x => x.Key, x => new HashSet<Point>());
            var notVisible = asteroids.ToDictionary(x => x.Key, x => new HashSet<Point>());

            foreach (var home in asteroids.Keys)
            {
                foreach (var target in asteroids.Keys)
                {
                    if (target == home || notVisible[target].Contains(home))
                    {
                        continue;
                    }
                    if (visible[target].Contains(home))
                    {
                        continue;
                    }

                    var distanceX = target.X - home.X;
                    var distanceY = target.Y - home.Y;
                    var gcd = Gcd(distanceX, distanceY);

                    var isBlocked = false;
                    var incrementX = distanceX / gcd;
                    var incrementY = distanceY / gcd;
                    var size = new Size(incrementX, incrementY);
                    var point = Point.Add(home, size);
                    while (point.X != target.X || point.Y != target.Y)
                    {
                        if (visible.ContainsKey(point) && visible[point].Contains(home))
                        {
                            isBlocked = true;
                            break;
                        }
                        point = Point.Add(point, size);
                    }

                    if (!isBlocked)
                    {
                        visible[home].Add(target);
                        visible[target].Add(home);
                    }
                    else
                    {
                        notVisible[home].Add(target);
                        notVisible[target].Add(home);
                    }
                }
            }

            int Gcd(int x, int y)
            {
                while (y != 0)
                {
                    var t = y;
                    y = x % y;
                    x = t;
                }

                return Math.Abs(x);
            }

            var most = visible
                .OrderByDescending(x => x.Value.Count())
                .First();

            return (most.Key, most.Value.Count());
        }

        public Point PuzzleTwo(string input, Point home, int nth)
        {
            var asteroids = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany((x, i) =>
                    x.Select((y, j) => new
                    {
                        Point = new Point(j, i),
                        Value = y
                    }))
                .Where(x => x.Value == '#' && x.Point != home)
                .Select(x => x.Point)
                .Select(x =>
                {
                    var distanceX = x.X - home.X;
                    var distanceY = x.Y - home.Y;
                    var quadrant = 0;
                    if (distanceX >= 0 && distanceY < 0) quadrant = 0;
                    else if (distanceX > 0 && distanceY >= 0) quadrant = 1;
                    else if (distanceX <= 0 && distanceY > 0) quadrant = 2;
                    else if (distanceX < 0 && distanceY <= 0) quadrant = 3;
                    return new
                    {
                        Point = x,
                        X = distanceX,
                        Y = distanceY,
                        Angle = quadrant % 2 == 0
                            ? distanceX / (decimal)distanceY
                            : distanceY / (decimal)distanceX * -1,
                        ManhattanDistance = ManhattanDistance(home, x),
                        Quadrant = quadrant
                    };
                })
                .GroupBy(x => new { x.Angle, x.Quadrant })
                .SelectMany(x =>
                    x.OrderBy(y => y.ManhattanDistance)
                        .Select((y, i) => new
                        {
                            Point = y.Point,
                            x.Key.Quadrant,
                            x.Key.Angle,
                            Rank = i,

                        }))
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.Quadrant)
                .ThenByDescending(x => x.Angle)
                .ToList();

            return asteroids[nth - 1].Point;

            static int ManhattanDistance(Point a, Point b)
                => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}