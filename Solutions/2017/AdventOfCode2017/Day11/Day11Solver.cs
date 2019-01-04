namespace AdventOfCode2017.Day11
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day11Solver
    {
        public int PuzzleOne(string input) => Solve(input).Steps;

        public int PuzzleTwo(string input) => Solve(input).Furthest;

        private static (int Steps, int Furthest) Solve(string input)
        {
            var path = input.Split(',');

            var directions = new[] { "n", "ne", "se", "s", "sw", "nw" };

            var indices = directions
                .Select((x, i) => new { Value = x, Index = i })
                .ToDictionary(x => x.Value, x => x.Index);

            var steps = directions.ToDictionary(x => x, x => 0);

            var equivalents = directions
                .ToDictionary(
                    x => x,
                    x => new[] { 2, 4 }.Select(y => directions[(indices[x] + y) % 6]).ToArray());

            var opposites = directions
                .ToDictionary(
                    x => x,
                    x => directions[(indices[x] + 3) % 6]);

            var max = int.MinValue;

            foreach (var direction in path)
            {
                var index = indices[direction];
                if (steps[opposites[direction]] > 0)
                {
                    steps[opposites[direction]]--;
                }
                else if (steps[equivalents[direction][0]] > 0)
                {
                    steps[equivalents[direction][0]]--;
                    steps[directions[(index + 1) % 6]]++;
                }
                else if (steps[equivalents[direction][1]] > 0)
                {
                    steps[equivalents[direction][1]]--;
                    steps[directions[(index + 5) % 6]]++;
                }
                else
                {
                    steps[direction]++;
                }

                var sum = steps.Values.Sum();
                if (sum > max)
                {
                    max = sum;
                }
            }

            return (steps.Values.Sum(), max);

        }
    }
}