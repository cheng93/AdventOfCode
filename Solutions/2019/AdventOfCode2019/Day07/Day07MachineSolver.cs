using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day07
{
    public class Day07MachineSolver
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
                    output = new Machine(input.ToArray(), new int[] { number, output }).Run().First();
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
                        output = new Machine(input.ToArray(), signals[i].ToArray()).Run().Skip(signals[i].Count - 2).FirstOrDefault();
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
    }
}