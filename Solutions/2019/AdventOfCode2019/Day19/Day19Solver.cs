using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day19
{
    public class Day19Solver
    {
        public int PuzzleOne(IEnumerable<long> input)
        {
            var count = 0;
            for (var i = 0; i < 50; i++)
            {
                for (var j = 0; j < 50; j++)
                {
                    var instructions = new List<long>();
                    instructions.Add(i);
                    instructions.Add(j);

                    var output = IntCode(input, instructions).First();
                    if (output == 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int PuzzleTwo(IEnumerable<long> input)
        {
            var x = 0L;
            var y = 0L;
            var minX = (long?)null;
            while (true)
            {
                var output = IntCode(input, new List<long> { x, y }).First();
                if (output == 1)
                {
                    var topRight = IntCode(input, new List<long> { x + 99, y }).First() == 1;
                    var bottomLeft = IntCode(input, new List<long> { x, y + 99 }).First() == 1;

                    var exit = topRight && bottomLeft;
                    if (exit)
                    {
                        return (int)(x * 10000 + y);
                    }
                    else if (topRight)
                    {
                        if (!minX.HasValue)
                        {
                            minX = x;
                        }
                        x++;
                    }
                    else
                    {
                        y += minX.HasValue ? 1 : 100;
                        x = minX ?? 0;
                    }
                }
                else
                {
                    x++;
                }
            }
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