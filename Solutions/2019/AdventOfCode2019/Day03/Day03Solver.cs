using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2019.Day03
{
    public class Day03Solver
    {
        public int PuzzleOne(IEnumerable<string> input) => Solve(input).Manhattan;

        public int PuzzleTwo(IEnumerable<string> input) => Solve(input).Sum;

        private static (int Manhattan, int Sum) Solve(IEnumerable<string> input)
        {
            var wires = input
                .Select(x => x.Split(',').Select(y => new Day03Instruction(y)))
                .ToArray();

            var routeOne = new HashSet<Point>();
            var routeTwo = new HashSet<Point>();
            var routeOneSteps = new Dictionary<Point, int>();
            var routeTwoSteps = new Dictionary<Point, int>();

            void Traverse(HashSet<Point> route, Dictionary<Point, int> steps, IEnumerable<Day03Instruction> instructions)
            {
                var current = new Point(0, 0);
                var count = 0;
                foreach (var instruction in instructions)
                {
                    var newPoints = instruction.GetPoints(current).ToList();
                    current = newPoints.Last();
                    foreach (var point in newPoints)
                    {
                        count++;
                        route.Add(point);
                        if (!steps.ContainsKey(point))
                        {
                            steps[point] = count;
                        }
                    }
                }
            }

            Traverse(routeOne, routeOneSteps, wires[0]);
            Traverse(routeTwo, routeTwoSteps, wires[1]);

            var intersects = routeOne.Intersect(routeTwo);
            var manhattan = intersects
                .Select(x => ManhattanDistance(new Point(0, 0), x))
                .Min();

            var sum = intersects
                .Select(x => routeOneSteps[x] + routeTwoSteps[x])
                .Min();

            return (manhattan, sum);
        }

        private static int ManhattanDistance(Point a, Point b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}