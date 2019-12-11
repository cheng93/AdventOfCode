using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day11
{
    public class Day11Solver
    {
        public int PuzzleOne(IEnumerable<long> input) => Solve(input, 0).Painted;

        public string PuzzleTwo(IEnumerable<long> input) => Solve(input, 1).Message;

        private static (string Message, int Painted) Solve(IEnumerable<long> input, long initial)
        {
            var instructions = new List<long> { initial };
            var sizes = new[]
            {
                new Size(0, 1),
                new Size(1, 0),
                new Size(0, -1),
                new Size(-1, 0)
            };
            var direction = 0;
            var points = new Dictionary<Point, int>();
            var point = new Point(0, 0);
            var iteration = 0;
            foreach (var output in IntCode(input, instructions))
            {
                if (iteration % 2 == 0)
                {
                    points[point] = (int)output;
                }
                else if (iteration % 2 == 1)
                {
                    direction = (direction + (output == 0 ? 1 : 3)) % 4;
                    point = Point.Add(point, sizes[direction]);
                    var next = points.ContainsKey(point)
                        ? points[point]
                        : 0;
                    instructions.Add(next);
                }
                iteration++;
            }

            var lines = new List<string>();
            for (var i = points.Keys.Select(x => x.Y).Max(); i >= points.Keys.Select(x => x.Y).Min(); i--)
            {
                var sb = new StringBuilder();
                for (var j = points.Keys.Select(x => x.X).Max(); j >= points.Keys.Select(x => x.X).Min(); j--)
                {
                    var p = new Point(j, i);
                    var character = points.ContainsKey(p)
                        ? points[p] == 0
                            ? ' '
                            : '█'
                        : ' ';
                    sb.Append(character);
                }
                lines.Add(sb.ToString());
            }

            return (string.Join(Environment.NewLine, lines), points.Count);
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