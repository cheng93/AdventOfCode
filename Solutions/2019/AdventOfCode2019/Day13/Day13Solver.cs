using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day13
{
    public class Day13Solver
    {
        public int PuzzleOne(IEnumerable<long> input) => Solve(input).Blocks;

        public long PuzzleTwo(IEnumerable<long> input) => Solve(input).Score;

        private static (int Blocks, long Score) Solve(IEnumerable<long> input)
        {
            var iteration = 0;
            var points = new Dictionary<Point, int>();
            var x = 0;
            var y = 0;
            var score = 0L;
            foreach (var output in IntCode(input, points))
            {
                switch (iteration % 3)
                {
                    case 0:
                        x = (int)output;
                        break;
                    case 1:
                        y = (int)output;
                        break;
                    case 2:
                        if (x != -1)
                        {
                            points[new Point(x, y)] = (int)output;
                        }
                        else
                        {
                            score = output;
                        }
                        break;
                }
                iteration++;
            }

            return (points.Values.Where(x => x == 2).Count(), score);
        }

        private static IEnumerable<long> IntCode(IEnumerable<long> input, Dictionary<Point, int> points)
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
                    var ball = points.Where(x => x.Value == 4).First().Key;
                    var paddle = points.Where(x => x.Value == 3).First().Key;
                    var i = paddle.X == ball.X
                            ? 0
                            : paddle.X - ball.X < 0
                                ? 1
                                : -1;
                            
                    program[p[0].Original] = i;
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