using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day05
{
    public class Day05Solver
    {
        public IEnumerable<int> PuzzleOne(IEnumerable<int> input, int systemId = 1) => Solve(input, systemId);

        public IEnumerable<int> PuzzleTwo(IEnumerable<int> input, int systemId = 5) => Solve(input, systemId);

        private static IEnumerable<int> Solve(IEnumerable<int> input, int systemId)
        {
            var program = input.ToArray();

            var position = 0;
            var instruction = program[position];
            var opcode = int.MinValue;
            while (opcode != 99)
            {
                opcode = instruction % 100;
                var parameters = program
                    .Skip(position + 1)
                    .Take(3)
                    .Select((x, i)
                        => new
                        {
                            Original = x,
                            Value = (instruction / (int)Math.Pow(10, 2 + i)) % 10 == 0
                                ? program[x]
                                : x
                        });

                if (opcode == 1)
                {
                    var p = parameters.ToArray();
                    program[p[2].Original] = p[0].Value + p[1].Value;
                    position += 4;
                }
                else if (opcode == 2)
                {
                    var p = parameters.ToArray();
                    program[p[2].Original] = p[0].Value * p[1].Value;
                    position += 4;
                }
                else if (opcode == 3)
                {
                    var p = parameters.Take(1).ToArray();
                    program[p[0].Original] = systemId;
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
                        position = p[1].Value;
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
                        position = p[1].Value;
                    }
                    else
                    {
                        position += 3;
                    }
                }
                else if (opcode == 7)
                {
                    var p = parameters.ToArray();
                    program[p[2].Original] = p[0].Value < p[1].Value ? 1 : 0;
                    position += 4;
                }
                else if (opcode == 8)
                {
                    var p = parameters.ToArray();
                    program[p[2].Original] = p[0].Value == p[1].Value ? 1 : 0;
                    position += 4;
                }

                instruction = program[position];
            }
        }
    }
}