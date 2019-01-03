namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day08Solver
    {
        public int PuzzleOne(string input) => Solve(input).Largest;

        public int PuzzleTwo(string input) => Solve(input).LargestEver;

        private static (int Largest, int LargestEver) Solve(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var instructions = new List<Day08Instruction>();
            var registers = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                var instruction = new Day08Instruction(line);
                instructions.Add(instruction);

                registers[instruction.Register] = 0;
            }

            var max = int.MinValue;

            foreach (var instruction in instructions)
            {
                var condition = instruction.Condition;
                if (condition.Operator(registers[condition.Register]))
                {
                    registers[instruction.Register] += instruction.Change;

                    if (registers[instruction.Register] > max)
                    {
                        max = registers[instruction.Register];
                    }
                }
            }

            return (registers.Values.Max(), max);
        }
    }
}