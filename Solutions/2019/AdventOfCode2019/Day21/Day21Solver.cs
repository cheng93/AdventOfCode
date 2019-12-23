using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day21
{
    public class Day21Solver
    {
        public int PuzzleOne(IEnumerable<long> input)
        {
            var script = new[]
            {
                "NOT A J",
                "NOT B T",
                "OR T J",
                "NOT C T",
                "OR T J",
                "AND D J",
                // "NOT B J",
                // "NOT C T",
                // "OR T J",
                // "AND D J",
                // "NOT A T",
                // "OR T J",
                "WALK"
            };

            return Solve(input, script);
        }

        public int PuzzleTwo(IEnumerable<long> input)
        {
            var script = new[]
            {
                "NOT F T",
                "AND I T",
                "OR F T",
                "AND E T",
                "OR T J",
                "OR H J",
                "AND D J",
                "OR J T",
                "AND A T",
                "AND B T",
                "AND C T",
                "NOT T T",
                "AND T J",
                "RUN"
            };

            return Solve(input, script);
        }

        private static int Solve(IEnumerable<long> input, IEnumerable<string> script)
        {
            var instructions = script.Aggregate(
                new List<long>(),
                (acc, curr) =>
                {
                    acc.AddRange(curr.Select(x => (long)x));
                    acc.Add(10);
                    return acc;
                });

            return (int)IntCode(input, instructions).Last();

            // var last = 0;
            // foreach (var output in IntCode(input, instructions))
            // {
            //     Console.Write((char)output);
            //     last = (int)output;
            // }

            // return last;
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