namespace AdventOfCode2018.Day19
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day19Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var registerPointer = int.Parse(lines[0].Split(' ')[1]);

            var instructions = lines
                .Skip(1)
                .Select(x => new Day19Instruction(x))
                .ToList();

            var instructionPointer = 0;

            var registers = new[] { 0, 0, 0, 0, 0, 0 };

            while (instructionPointer < instructions.Count)
            {
                registers[registerPointer] = instructionPointer;
                registers = instructions[instructionPointer].Execute(registers);
                instructionPointer = registers[registerPointer] + 1;
            }

            return registers[0];
        }

        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var registerPointer = int.Parse(lines[0].Split(' ')[1]);

            var instructions = lines
                .Skip(1)
                .Select(x => new Day19Instruction(x))
                .ToList();

            var registers = new[] { 1, 0, 0, 0, 0, 0 };

            var instructionPointer = 0;
            var iterations = 0;

            var seen = Enumerable.Range(0, instructions.Count)
                .ToDictionary(x => x, x => new List<int>());

            var log = new List<int>();
            var done = false;

            while (instructionPointer < instructions.Count)
            {
                registers[registerPointer] = instructionPointer;
                registers = instructions[instructionPointer].Execute(registers);

                seen[instructionPointer].Add(iterations);
                log.Add(instructionPointer);

                var repeatingInstructions = new List<int>();

                for (var i = seen[instructionPointer].Count - 2; i >= 0; i--)
                {
                    var previous = seen[instructionPointer][i];
                    var difference = iterations - previous;
                    if (previous < difference - 1)
                    {
                        break;
                    }
                    for (var j = difference - 1; j >= 0; j--)
                    {
                        repeatingInstructions.Add(log[previous - j]);
                        if (log[previous - j] != log[iterations - j])
                        {
                            repeatingInstructions.Clear();
                            break;
                        }
                    }

                    if (repeatingInstructions.Any())
                    {
                        break;
                    }
                }

                if (repeatingInstructions.Any() && !done)
                {
                    // Manual calc hack
                    registers[2] = 2;
                    registers[3] = registers[1];
                    registers[5] = registers[1];
                    registers[0] = SumFactorsOf(registers[1]);
                    done = true;
                }

                instructionPointer = registers[registerPointer] + 1;
                iterations++;
            }

            return registers[0];
        }

        private static int SumFactorsOf(long input)
        {
            var sum = 0L;

            var sqrt = (int)Math.Sqrt(input);
            for (var i = 1; i <= sqrt; i++)
            {
                if (input % i == 0)
                {
                    sum += i;
                    if (i != input / i)
                    {
                        sum += input / i;
                    }
                }
            }

            return (int)sum;
        }
    }
}