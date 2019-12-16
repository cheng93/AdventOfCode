using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day16
{
    public class Day16Solver
    {
        public IEnumerable<int> PuzzleOne(IEnumerable<int> input, int phases)
        {
            var output = input.ToList();
            for (var i = 0; i < phases; i++)
            {
                output = RunPhase(output);
            }

            List<int> RunPhase(List<int> input)
            {
                var output = new List<int>();
                for (var i = 0; i < input.Count; i++)
                {
                    var value = input
                        .Skip(i)
                        .Select((x, j) =>
                        {
                            var multiplier = ((j / (i + 1)) % 4) switch
                            {
                                0 => 1,
                                2 => -1,
                                _ => 0
                            };

                            return x * multiplier;
                        })
                        .Sum();
                    value = Math.Abs(value) % 10;
                    output.Add(value);
                }

                return output;
            }

            return output;
        }

        public string PuzzleTwo(IEnumerable<int> input)
        {
            var cloned = input.ToList();
            var skip = int.Parse(string.Join(string.Empty, cloned.Take(7)));

            var newInput = Enumerable.Range(0, 10000)
                .Aggregate(Enumerable.Empty<int>(), (acc, next) => acc.Concat(input))
                .Skip(skip);

            for (var i = 0; i < 100; i++)
            {
                newInput = RunPhase(newInput.ToList());
            }

            List<int> RunPhase(List<int> input)
            {
                var newList = new List<int>();
                var sum = 0;
                for (var i = input.Count - 1; i >= 0; i--)
                {
                    sum += input[i];
                    var value = sum % 10;
                    newList.Add(value);
                }
                newList.Reverse();
                return newList;
            }

            return string.Join(string.Empty, newInput.Take(8));
        }
    }
}