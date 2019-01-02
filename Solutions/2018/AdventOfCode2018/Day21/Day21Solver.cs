namespace AdventOfCode2018.Day21
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day21Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var registerPointer = int.Parse(lines[0].Split(' ')[1]);

            var instructions = lines
                .Skip(1)
                .Select(x => new Day21Instruction(x))
                .ToList();

            var instructionPointer = 0;

            var registers = new[] { 0, 0, 0, 0, 0, 0 };

            while (instructionPointer < instructions.Count)
            {
                if (instructionPointer == 28)
                {
                    break;
                }
                registers[registerPointer] = instructionPointer;
                registers = instructions[instructionPointer].Execute(registers);
                instructionPointer = registers[registerPointer] + 1;
            }
            return registers[3];
        }

        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var registerPointer = int.Parse(lines[0].Split(' ')[1]);

            var instructions = lines
                .Skip(1)
                .Select(x => new Day21Instruction(x))
                .ToList();

            var instructionPointer = 0;

            var registers = new[] { 0, 0, 0, 0, 0, 0 };

            var previous = new HashSet<int>();
            var current = new HashSet<int>();
            while (instructionPointer < instructions.Count)
            {
                registers[registerPointer] = instructionPointer;
                if (instructionPointer == 28)
                {
                    var c = registers[3];
                    if (current.Contains(c))
                    {
                        if (current.IsSubsetOf(previous))
                        {
                            break;
                        }
                        previous = new HashSet<int>(current);
                        current.Clear();
                    }
                    current.Add(c);
                }
                if (instructionPointer == 20)
                {
                    var e = registers[1] / 256;
                    registers[5] = e;
                    registers[4] = (e + 1) * 256;
                    registers[registerPointer] = 25;
                }
                else
                {
                    registers = instructions[instructionPointer].Execute(registers);
                }

                instructionPointer = registers[registerPointer] + 1;
            }
            return current.Last();
        }
    }
}