namespace AdventOfCode2017.Day05
{
    using System;
    using System.Linq;

    public class Day05Solver
    {
        public int PuzzleOne(string input)
        {
            var instructions = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var steps = 0;

            var index = 0;

            while (index >= 0 && index < instructions.Count)
            {
                var oldIndex = index;
                index += instructions[index];

                instructions[oldIndex]++;

                steps++;
            }

            return steps;
        }
        public int PuzzleTwo(string input)
        {
            var instructions = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var steps = 0;

            var index = 0;

            while (index >= 0 && index < instructions.Count)
            {
                var oldIndex = index;
                index += instructions[index];

                if (instructions[oldIndex] >= 3)
                {
                    instructions[oldIndex]--;
                }
                else
                {
                    instructions[oldIndex]++;
                }

                steps++;
            }

            return steps;
        }
    }
}