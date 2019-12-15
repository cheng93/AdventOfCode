using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day14
{
    public class Day14Solver
    {
        public int PuzzleOne(IEnumerable<string> input) => (int)Solve(input, 1);

        public long PuzzleTwo(IEnumerable<string> input)
        {
            var min = 0L;
            var max = (long)int.MaxValue;
            var target = 1000000000000;
            while (true)
            {
                var mid = (max + min) / 2;
                var ore = Solve(input, mid);

                if (ore < target)
                {
                    min = mid + 1;
                }
                else if (ore > target)
                {
                    max = mid - 1;
                }
                if (min > max)
                {
                    return max;
                }
            }
        }

        public static long Solve(IEnumerable<string> input, long required)
        {
            var reactions = input.Select(x => new Day14Reaction(x)).ToList();

            var outputs = reactions.ToDictionary(x => x.Output, x => x.Input);
            var index = outputs.ToDictionary(x => x.Key.Name, x => x.Key.Quantity);
            var remainders = index.Keys.ToDictionary(x => x, x => 0L);

            var queue = new Queue<Day14Chemical>();
            queue.Enqueue(new Day14Chemical("FUEL", required));
            var ore = 0L;

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current.IsOre())
                {
                    ore += current.Quantity;
                    continue;
                }
                if (current.Quantity < remainders[current.Name])
                {
                    remainders[current.Name] -= current.Quantity;
                    continue;
                }

                var chemical = new Day14Chemical(current.Name, index[current.Name]);

                var amountRequired = Math.Max(current.Quantity - remainders[current.Name], 0);
                remainders[current.Name] -= current.Quantity - amountRequired;
                if (amountRequired == 0)
                {
                    continue;
                }
                var multiplier = (amountRequired - 1) / chemical.Quantity + 1;

                var remainder = multiplier * chemical.Quantity - amountRequired;
                remainders[chemical.Name] += remainder;

                foreach (var i in outputs[chemical])
                {
                    var quantity = i.Quantity * multiplier;
                    queue.Enqueue(new Day14Chemical(i.Name, quantity));
                }
            }

            return ore;
        }
    }
}