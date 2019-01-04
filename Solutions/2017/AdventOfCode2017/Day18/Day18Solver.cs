namespace AdventOfCode2017.Day18
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day18Solver
    {
        public long PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var instructions = new List<Day18Instruction>();

            var registers = new Dictionary<string, long>();

            foreach (var line in lines)
            {
                var instruction = new Day18Instruction(line);
                instructions.Add(instruction);

                if (instruction.XNumber == null)
                {
                    registers[instruction.X] = 0;
                }
            }

            var frequency = (long?)null;

            for (var i = 0; i < instructions.Count; i++)
            {
                var instruction = instructions[i];
                var y = instruction.YNumber ?? (instruction.Y != null ? registers[instruction.Y] : (long?)null);
                var x = instruction.XNumber ?? (instruction.X != null ? registers[instruction.X] : (long?)null);
                switch (instruction.Operation)
                {
                    case "snd":
                        frequency = x;
                        break;
                    case "set":
                        registers[instruction.X] = y.Value;
                        break;
                    case "add":
                        registers[instruction.X] += y.Value;
                        break;
                    case "mul":
                        registers[instruction.X] *= y.Value;
                        break;
                    case "mod":
                        registers[instruction.X] = registers[instruction.X] % y.Value;
                        break;
                    case "rcv":
                        if (x != 0)
                        {
                            return frequency.Value;
                        }
                        break;
                    case "jgz":
                        if (x > 0)
                        {
                            i += (int)y.Value - 1;
                        }
                        break;
                }
            }

            throw new Exception();
        }
        public long PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var instructions = new List<Day18Instruction>();

            var registers = new Dictionary<string, long>();

            foreach (var line in lines)
            {
                var instruction = new Day18Instruction(line);
                instructions.Add(instruction);

                if (instruction.XNumber == null)
                {
                    registers[instruction.X] = 0;
                }
            }

            var programs = new List<Day18Program>();

            for (var i = 0; i < 2; i++)
            {
                var program = new Day18Program(registers);
                programs.Add(program);

                program.Registers["p"] = i;
            }

            var count = 0;

            while (programs.Any(x => !x.Awaiting && x.Index >= 0 && x.Index < instructions.Count))
            {
                for (var i = 0; i < programs.Count; i++)
                {
                    var program = programs[i];
                    if (program.Awaiting && !program.Queue.Any())
                    {
                        continue;
                    }

                    if (program.Index < 0 || program.Index >= instructions.Count)
                    {
                        continue;
                    }

                    registers = program.Registers;
                    var instruction = instructions[program.Index];
                    var y = instruction.YNumber ?? (instruction.Y != null ? registers[instruction.Y] : (long?)null);
                    var x = instruction.XNumber ?? (instruction.X != null ? registers[instruction.X] : (long?)null);

                    switch (instruction.Operation)
                    {
                        case "snd":
                            programs[(i + 1) % programs.Count].Queue.Enqueue(x.Value);
                            if (i == 1)
                            {
                                count++;
                            }
                            break;
                        case "set":
                            registers[instruction.X] = y.Value;
                            break;
                        case "add":
                            registers[instruction.X] += y.Value;
                            break;
                        case "mul":
                            registers[instruction.X] *= y.Value;
                            break;
                        case "mod":
                            registers[instruction.X] = registers[instruction.X] % y.Value;
                            break;
                        case "rcv":
                            if (program.Queue.Any())
                            {
                                var item = program.Queue.Dequeue();
                                registers[instruction.X] = item;
                                program.Awaiting = false;
                            }
                            else
                            {
                                program.Awaiting = true;
                                continue;
                            }
                            break;
                        case "jgz":
                            if (x > 0)
                            {
                                program.Index += (int)y.Value - 1;
                            }
                            break;
                    }

                    program.Index++;
                }
            }

            return count;
        }
    }
}