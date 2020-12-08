using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day08
{
    public class Day08Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var instructions = input
                .Select(x => new Day08Instruction(x))
                .ToArray();

            var i = 0;
            var visited = new HashSet<int>();
            var acc = 0;

            while (true)
            {
                visited.Add(i);
                var instruction = instructions[i];
                var j = acc;
                switch (instruction.Operation)
                {
                    case "acc":
                        acc += instruction.Argument;
                        i++;
                        break;
                    case "jmp":
                        i += instruction.Argument;
                        break;
                    case "nop":
                        i++;
                        break;
                }
                if (visited.Contains(i))
                {
                    return j;
                }
            }
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var instructions = input
                .Select(x => new Day08Instruction(x))
                .ToArray();

            var j = 0;
            while (true)
            {
                var replaceInstruction = instructions[j];
                if (replaceInstruction.Operation == "acc")
                {
                    j++;
                    continue;
                }
                var i = 0;
                var acc = 0;
                var visited = new HashSet<int>();
                while (true)
                {
                    if (i >= instructions.Length)
                    {
                        return acc;
                    }
                    var instruction = instructions[i];
                    if (visited.Contains(i))
                    {
                        break;
                    }
                    visited.Add(i);
                    if (i == j)
                    {
                        var operation = replaceInstruction.Operation == "jmp" ? "nop" : "jmp";
                        instruction = new Day08Instruction($"{operation} {replaceInstruction.Argument}");
                    }
                    switch (instruction.Operation)
                    {
                        case "acc":
                            acc += instruction.Argument;
                            i++;
                            break;
                        case "jmp":
                            i += instruction.Argument;
                            break;
                        case "nop":
                            i++;
                            break;
                    }
                }
                j++;
            }
        }
    }
}