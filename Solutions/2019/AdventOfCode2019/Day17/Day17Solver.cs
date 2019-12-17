using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day17
{
    public class Day17Solver
    {
        public int PuzzleOne(IEnumerable<long> input)
        {
            var points = new Dictionary<Point, int>();
            var point = new Point(0, 0);
            var intersections = new HashSet<Point>();

            foreach (var output in IntCode(input, new List<long>()))
            {
                if (output == 10)
                {
                    point = Point.Add(point, new Size(point.X * -1, 1));
                }
                else
                {
                    points[point] = (int)output;

                    if ((char)output == '#')
                    {
                        var up = Point.Add(point, new Size(0, -1));
                        var left = Point.Add(point, new Size(-1, 0));
                        var pointsToCheck = new[] { up, left };

                        foreach (var p in pointsToCheck)
                        {
                            if (points.ContainsKey(p) && (char)points[p] == '#')
                            {
                                if (CheckIntersections(p))
                                {
                                    intersections.Add(p);
                                }
                            }
                        }
                    }

                    point = Point.Add(point, new Size(1, 0));
                }
            }

            bool CheckIntersections(Point p)
            {
                var sizes = new Size[]
                {
                    new Size(0, -1),
                    new Size(1, 0),
                    new Size(0, 1),
                    new Size(-1, 0),
                };

                return sizes.Count(x =>
                {
                    var newPoint = Point.Add(p, x);
                    return points.ContainsKey(newPoint) && (char)points[newPoint] == '#';
                }) >= 3;
            }

            return intersections.Select(x => x.X * x.Y).Sum();
        }

        public long PuzzleTwo(IEnumerable<long> input)
        {
            var routine = "A,B,A,C,B,C,B,A,C,B";
            var a = "L,10,L,6,R,10";
            var b = "R,6,R,8,R,8,L,6,R,8";
            var c = "L,10,R,8,R,8,L,10";
            var render = "n";

            var instructions = new[] { routine, a, b, c, render }
                .Select(x => x.Select(y => (long)y))
                .Aggregate(
                    new List<long>(),
                    (acc, cur) =>
                    {
                        acc.AddRange(cur);
                        acc.Add(10);
                        return acc;
                    });

            var dust = IntCode(input, instructions).Last();
            return dust;
        }


        private static IEnumerable<long> IntCode(IEnumerable<long> input, List<long> signals)
        {
            var program = input.ToList();

            void ExpandProgram(int size)
            {
                while (program.Count <= size)
                {
                    program.Add(0);
                }
            }

            var position = 0;
            var instruction = program[position];
            var opcode = long.MinValue;
            var signalCounter = 0;
            var relativeBase = 0;

            while (opcode != 99)
            {
                opcode = instruction % 100;
                var parameters = program
                    .Skip(position + 1)
                    .Take(3)
                    .Select((x, i)
                        =>
                        {
                            var parameter = ((instruction / (long)Math.Pow(10, 2 + i)) % 10);
                            var value = x;
                            var original = value;
                            switch (parameter)
                            {
                                case 0:
                                    ExpandProgram((int)x);
                                    value = program[(int)x];
                                    break;
                                case 2:
                                    ExpandProgram((int)x + relativeBase);
                                    value = program[(int)x + relativeBase];
                                    original = x + relativeBase;
                                    break;
                            }
                            return new
                            {
                                Original = (int)original,
                                Value = value
                            };
                        });

                if (opcode == 1)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value + p[1].Value;
                    position += 4;
                }
                else if (opcode == 2)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value * p[1].Value;
                    position += 4;
                }
                else if (opcode == 3)
                {
                    var p = parameters.Take(1).ToArray();
                    ExpandProgram(p[0].Original);
                    program[p[0].Original] = signals[signalCounter];
                    signalCounter++;
                    position += 2;
                }
                else if (opcode == 4)
                {
                    var p = parameters.Take(1).ToArray();
                    yield return p[0].Value;
                    position += 2;
                }
                else if (opcode == 5)
                {
                    var p = parameters.Take(2).ToArray();
                    if (p[0].Value != 0)
                    {
                        position = (int)p[1].Value;
                    }
                    else
                    {
                        position += 3;
                    }
                }
                else if (opcode == 6)
                {
                    var p = parameters.Take(2).ToArray();
                    if (p[0].Value == 0)
                    {
                        position = (int)p[1].Value;
                    }
                    else
                    {
                        position += 3;
                    }
                }
                else if (opcode == 7)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value < p[1].Value ? 1 : 0;
                    position += 4;
                }
                else if (opcode == 8)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value == p[1].Value ? 1 : 0;
                    position += 4;
                }
                else if (opcode == 9)
                {
                    var p = parameters.Take(1).ToArray();
                    relativeBase += (int)p[0].Value;
                    position += 2;
                }

                instruction = program[position];
            }
        }
    }
}