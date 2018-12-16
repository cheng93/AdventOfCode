namespace AdventOfCode2018.Day16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day16Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var samples = new List<Day16Sample>();

            Day16Sample currentSample = null;

            foreach (var line in lines)
            {
                var beforeString = "Before: [";
                var afterString = "After:  [";
                if (line.StartsWith(beforeString))
                {
                    var registers = BeforeAfterStringToArray(line, beforeString);
                    currentSample = new Day16Sample()
                    {
                        Before = registers
                    };
                }
                else if (line.StartsWith(afterString))
                {
                    var registers = BeforeAfterStringToArray(line, afterString);
                    currentSample.After = registers;
                    samples.Add(currentSample);
                }
                else
                {
                    currentSample.Instruction = new Day16Instruction(line);
                }
            }

            var sum = 0;

            foreach (var sample in samples)
            {
                var a = sample.Instruction.A;
                var b = sample.Instruction.B;
                var c = sample.Instruction.Output;
                var before = sample.Before;
                var after = sample.After;

                var ops = 0;
                if (before[a] + before[b] == after[c])
                {
                    ops++;
                }
                if (before[a] + b == after[c])
                {
                    ops++;
                }
                if (before[a] * before[b] == after[c])
                {
                    ops++;
                }
                if (before[a] * b == after[c])
                {
                    ops++;
                }
                if ((before[a] & before[b]) == after[c])
                {
                    ops++;
                }
                if ((before[a] & b) == after[c])
                {
                    ops++;
                }
                if ((before[a] | before[b]) == after[c])
                {
                    ops++;
                }
                if ((before[a] | b) == after[c])
                {
                    ops++;
                }
                if (before[a] == after[c])
                {
                    ops++;
                }
                if (a == after[c])
                {
                    ops++;
                }
                if ((a > before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    ops++;
                }
                if ((before[a] > b && after[c] == 1)
                    || after[c] == 0)
                {
                    ops++;
                }
                if ((before[a] > before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    ops++;
                }
                if ((a == before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    ops++;
                }
                if ((before[a] == b && after[c] == 1)
                    || after[c] == 0)
                {
                    ops++;
                }
                if ((before[a] == before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    ops++;
                }

                if (ops >= 3)
                {
                    sum++;
                }
            }

            return sum;
        }
        public int PuzzleTwo(string input, string testProgram)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var samples = new List<Day16Sample>();

            Day16Sample currentSample = null;

            foreach (var line in lines)
            {
                var beforeString = "Before: [";
                var afterString = "After:  [";
                if (line.StartsWith(beforeString))
                {
                    var registers = BeforeAfterStringToArray(line, beforeString);
                    currentSample = new Day16Sample()
                    {
                        Before = registers
                    };
                }
                else if (line.StartsWith(afterString))
                {
                    var registers = BeforeAfterStringToArray(line, afterString);
                    currentSample.After = registers;
                    samples.Add(currentSample);
                }
                else
                {
                    currentSample.Instruction = new Day16Instruction(line);
                }
            }

            var possibleOperations = Enumerable.Range(0, 16)
                .ToDictionary(x => x, x => new HashSet<string>());

            var opcodeHistory = Enumerable
                .Range(0, 16)
                .ToDictionary(x => x, x => new List<Day16Sample>());

            foreach (var sample in samples)
            {
                var a = sample.Instruction.A;
                var b = sample.Instruction.B;
                var c = sample.Instruction.Output;
                var opcode = sample.Instruction.Opcode;
                var before = sample.Before;
                var after = sample.After;

                var operations = new List<string>();

                if (before[a] + before[b] == after[c])
                {
                    operations.Add("addr");
                }
                if (before[a] + b == after[c])
                {
                    operations.Add("addi");
                }
                if (before[a] * before[b] == after[c])
                {
                    operations.Add("mulr");
                }
                if (before[a] * b == after[c])
                {
                    operations.Add("muli");
                }
                if ((before[a] & before[b]) == after[c])
                {
                    operations.Add("banr");
                }
                if ((before[a] & b) == after[c])
                {
                    operations.Add("bani");
                }
                if ((before[a] | before[b]) == after[c])
                {
                    operations.Add("borr");
                }
                if ((before[a] | b) == after[c])
                {
                    operations.Add("bori");
                }
                if (before[a] == after[c])
                {
                    operations.Add("setr");
                }
                if (a == after[c])
                {
                    operations.Add("seti");
                }
                if ((a > before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    operations.Add("gtir");
                }
                if ((before[a] > b && after[c] == 1)
                    || after[c] == 0)
                {
                    operations.Add("gtri");
                }
                if ((before[a] > before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    operations.Add("gtrr");
                }
                if ((a == before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    operations.Add("eqir");
                }
                if ((before[a] == b && after[c] == 1)
                    || after[c] == 0)
                {
                    operations.Add("eqri");
                }
                if ((before[a] == before[b] && after[c] == 1)
                    || after[c] == 0)
                {
                    operations.Add("eqrr");
                }

                foreach (var operation in operations)
                {
                    var pass = true;
                    foreach (var oldSample in opcodeHistory[opcode])
                    {
                        var dict = new Dictionary<int, string>() { { opcode, operation } };
                        var computedAfter = oldSample.Instruction.Execute(dict, oldSample.Before);
                        if (oldSample.After[oldSample.Instruction.Output] != computedAfter[oldSample.Instruction.Output])
                        {
                            pass = false;
                            break;
                        }
                    }

                    if (pass)
                    {
                        possibleOperations[opcode].Add(operation);
                    }
                }

                foreach (var operation in possibleOperations[opcode].ToList())
                {
                    var fail = false;
                    foreach (var oldSample in opcodeHistory[opcode])
                    {
                        var dict = new Dictionary<int, string>() { { opcode, operation } };
                        var computedAfter = oldSample.Instruction.Execute(dict, oldSample.Before);
                        if (oldSample.After[oldSample.Instruction.Output] != computedAfter[oldSample.Instruction.Output])
                        {
                            fail = true;
                            break;
                        }
                    }

                    if (fail)
                    {
                        possibleOperations[opcode].Remove(operation);
                    }
                }

                opcodeHistory[opcode].Add(sample);
            }

            var opcodeInstructions = new Dictionary<int, string>();
            while (opcodeInstructions.Count < 16)
            {
                var singleOperations = possibleOperations
                    .SelectMany(x => x.Value
                        .Select(y => new
                        {
                            Opcode = x.Key,
                            Operation = y
                        }))
                    .GroupBy(x => x.Operation)
                    .Where(x => x.Count() == 1)
                    .Select(x => new
                    {
                        Operation = x.Key,
                        Opcode = x.Single().Opcode
                    })
                    .ToList();

                foreach (var singleOperation in singleOperations)
                {
                    opcodeInstructions[singleOperation.Opcode] = singleOperation.Operation;
                    possibleOperations.Remove(singleOperation.Opcode);
                }

                var singleOpcodes = possibleOperations
                    .Where(x => x.Value.Count == 1)
                    .Select(x => new
                    {
                        Opcode = x.Key,
                        Operation = x.Value.Single()
                    })
                    .ToList();


                foreach (var singleOpcode in singleOpcodes)
                {
                    opcodeInstructions[singleOpcode.Opcode] = singleOpcode.Operation;
                    possibleOperations.Remove(singleOpcode.Opcode);
                }

                foreach (var possibleInstruction in possibleOperations)
                {
                    foreach (var takenInstruction in opcodeInstructions.Values)
                    {
                        possibleInstruction.Value.Remove(takenInstruction);
                    }
                }
            }

            var instructions = testProgram
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day16Instruction(x));

            var device = new int[4] { 0, 0, 0, 0 };

            foreach (var instruction in instructions)
            {
                device = instruction.Execute(opcodeInstructions, device);
            }

            return device[0];
        }

        private static int[] BeforeAfterStringToArray(string input, string prefix)
        {
            return input
                .Substring(0, input.Length - 1)
                .Substring(prefix.Length)
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}