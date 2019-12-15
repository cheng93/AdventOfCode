using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2019.Day15
{
    public class Day15Solver
    {
        public int PuzzleOne(IEnumerable<long> input) => Solve(input).Count;

        public int PuzzleTwo(IEnumerable<long> input)
        {
            var path = Solve(input);

            var sizes = new[]
            {
                new Size(0, 1),
                new Size(0, -1),
                new Size(-1, 0),
                new Size(1, 0),
            };
            var origin = new Point(0, 0);
            var points = new HashSet<Point>();
            points.Add(origin);
            var queue = new Queue<(Point Point, List<long> Path)>();
            for (var i = 0; i < 4; i++)
            {
                var next = Point.Add(origin, sizes[i]);
                points.Add(next);
                queue.Enqueue((next, new List<long> { i + 1 }));
            }

            var depth = 0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                var newPath = path.Concat(current.Path).ToList();
                var status = IntCode(input, newPath).Take(newPath.Count).Last();
                if (status == 0)
                {
                    continue;
                }

                depth = Math.Max(depth, current.Path.Count);
                for (var i = 0; i < 4; i++)
                {
                    var next = Point.Add(current.Point, sizes[i]);
                    if (!points.Contains(next))
                    {
                        points.Add(next);
                        var copy = current.Path.ToList();
                        copy.Add(i + 1);
                        queue.Enqueue((next, copy));
                    }
                }
            }

            return depth;
        }

        private static List<long> Solve(IEnumerable<long> input)
        {
            var sizes = new[]
            {
                new Size(0, 1),
                new Size(0, -1),
                new Size(-1, 0),
                new Size(1, 0),
            };

            var origin = new Point(0, 0);
            var points = new HashSet<Point>();
            points.Add(origin);
            var queue = new Queue<(Point Point, List<long> Path)>();
            for (var i = 0; i < 4; i++)
            {
                var next = Point.Add(origin, sizes[i]);
                points.Add(next);
                queue.Enqueue((next, new List<long> { i + 1 }));
            }

            while (queue.Any())
            {
                var current = queue.Dequeue();
                var status = IntCode(input, current.Path).Take(current.Path.Count).Last();
                if (status == 2)
                {
                    return current.Path;
                }
                if (status == 0)
                {
                    continue;
                }
                for (var i = 0; i < 4; i++)
                {
                    var next = Point.Add(current.Point, sizes[i]);
                    if (!points.Contains(next))
                    {
                        points.Add(next);
                        var copy = current.Path.ToList();
                        copy.Add(i + 1);
                        queue.Enqueue((next, copy));
                    }
                }
            }

            throw new Exception();
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