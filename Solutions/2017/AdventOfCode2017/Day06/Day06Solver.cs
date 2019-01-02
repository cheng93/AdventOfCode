namespace AdventOfCode2017.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day06Solver
    {
        public int PuzzleOne(string input) => Solve(input).Cycles;

        public int PuzzleTwo(string input) => Solve(input).LoopSize;

        private static (int Cycles, int LoopSize) Solve(string input)
        {
            var banks = Regex.Replace(input, "\\s+", ",")
                .Split(',')
                .Select(int.Parse)
                .ToList();

            var seen = new Dictionary<string, int>();

            var cycles = 0;

            while (true)
            {
                var max = int.MinValue;
                var index = 0;
                for (var i = 0; i < banks.Count; i++)
                {
                    if (banks[i] > max)
                    {
                        max = banks[i];
                        index = i;
                    }
                }

                var quotient = banks[index] / banks.Count;
                var remainder = banks[index] % banks.Count;

                banks[index] = 0;

                for (var i = 0; i < banks.Count; i++)
                {
                    banks[i] += quotient;
                    if (i < remainder)
                    {
                        banks[(index + 1 + i) % banks.Count]++;
                    }
                }

                cycles++;

                var bankString = string.Join(",", banks);
                if (seen.ContainsKey(bankString))
                {
                    return (cycles, cycles - seen[bankString]);
                }
                else
                {
                    seen.Add(bankString, cycles);
                }
            }

            throw new Exception();
        }
    }
}