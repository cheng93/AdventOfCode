using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day07
{
    public class Day07Solver
    {
        public int PuzzleOne(IEnumerable<int> input)
        {
            var permutations = Permutate(new[] { 0, 1, 2, 3, 4 });

            var signal = int.MinValue;
            foreach (var permutation in permutations)
            {
                var output = 0;
                foreach (var number in permutation)
                {
                    output = IntCode(input, new int[] { number, output }).First();
                }
                if (output > signal)
                {
                    signal = output;
                }
            }
            return signal;
        }

        public int PuzzleTwo(IEnumerable<int> input)
        {
            var permutations = Permutate(new[] { 5, 6, 7, 8, 9 });
            var signal = int.MinValue;
            foreach (var permutation in permutations)
            {
                var output = 0;
                var max = int.MinValue;
                var signals = permutation
                    .Select(x => new List<int> { x })
                    .ToArray();
                signals[0].Add(0);
                do
                {
                    max = output;
                    for (var i = 0; i < permutation.Count(); i++)
                    {
                        output = IntCode(input, signals[i].ToArray()).Skip(signals[i].Count - 2).FirstOrDefault();
                        signals[(i + 1) % 5].Add(output);
                    }
                }
                while (output != 0);
                if (max > signal)
                {
                    signal = max;
                }
            }
            return signal;
        }

        private static IEnumerable<IEnumerable<int>> Permutate(ICollection<int> set)
        {
            if (set.Count == 1)
            {
                yield return set;
            }
            for (var i = 0; i < set.Count; i++)
            {
                var first = set.Skip(i).Take(1);
                var rest = set.Where((x, j) => i != j).ToList();
                foreach (var permutation in Permutate(rest))
                {
                    yield return first.Concat(permutation);
                }
            }
        }

        private static IEnumerable<int> IntCode(IEnumerable<int> input, int[] signals)
        {
            var program = input.ToArray();

            var position = 0;
            var instruction = program[position];
            var opcode = int.MinValue;
            var signalCounter = 0;
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