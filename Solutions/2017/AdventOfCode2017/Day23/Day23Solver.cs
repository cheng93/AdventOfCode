namespace AdventOfCode2017.Day23
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day23Solver
    {
        public int PuzzleOne(string input)
        {
            var instructions = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day23Instruction(x))
                .ToList();

            var registers = Enumerable.Range('a', 8).ToDictionary(x => ((char)x).ToString(), x => 0L);

            var count = 0;

            for (var i = 0; i < instructions.Count; i++)
            {
                var instruction = instructions[i];
                var y = instruction.YNumber ?? (instruction.Y != null ? registers[instruction.Y] : (long?)null);
                var x = instruction.XNumber ?? (instruction.X != null ? registers[instruction.X] : (long?)null);
                switch (instruction.Operation)
                {
                    case "set":
                        registers[instruction.X] = y.Value;
                        break;
                    case "sub":
                        registers[instruction.X] -= y.Value;
                        break;
                    case "mul":
                        registers[instruction.X] *= y.Value;
                        count++;
                        break;
                    case "jnz":
                        if (x != 0)
                        {
                            i += (int)y.Value - 1;
                        }
                        break;
                }
            }

            return count;
        }
        public long PuzzleTwo(string input)
        {
            var instructions = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day23Instruction(x))
                .ToList();

            var registers = Enumerable.Range('a', 8).ToDictionary(x => ((char)x).ToString(), x => 0L);
            registers["a"] = 1;

            for (var i = 0; i < instructions.Count; i++)
            {
                //Console.WriteLine($"{i}: [{string.Join(", ", registers.Values)}]");
                var instruction = instructions[i];
                var y = instruction.YNumber ?? (instruction.Y != null ? registers[instruction.Y] : (long?)null);
                var x = instruction.XNumber ?? (instruction.X != null ? registers[instruction.X] : (long?)null);

                if (i == 19)
                {
                    if (registers["g"] == 0)
                    {
                        continue;
                    }
                    var b = registers["b"];
                    var d = registers["d"];
                    var e = registers["e"];
                    if (((d == 0 || e == 0) && b == 0)
                        || (d != 0 && b % d == 0 && b / d >= e))
                    {
                        registers["f"] = 0;
                    }
                    registers["e"] = b;
                    registers["g"] = 0;
                }
                else if (i == 23)
                {
                    if (registers["g"] == 0)
                    {
                        continue;
                    }
                    var b = registers["b"];
                    registers["f"] = 1;
                    if (!IsPrime(b))
                    {
                        registers["f"] = 0;
                    }
                    registers["e"] = b;
                    registers["d"] = b;
                    registers["g"] = 0;
                }
                else
                {
                    switch (instruction.Operation)
                    {
                        case "set":
                            registers[instruction.X] = y.Value;
                            break;
                        case "sub":
                            registers[instruction.X] -= y.Value;
                            break;
                        case "mul":
                            registers[instruction.X] *= y.Value;
                            break;
                        case "jnz":
                            if (x != 0)
                            {
                                i += (int)y.Value - 1;
                            }
                            break;
                    }
                }
            }

            return registers["h"];
        }

        private static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (var i = 2L; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}