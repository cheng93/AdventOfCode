namespace AdventOfCode2024.Day17;

public static class Day17Solver
{
    public static string PuzzleOne(string input)
    {
        var splits = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .ToArray();
        var registers = splits[0]
            .Split(Environment.NewLine)
            .Select(x => x.Substring("Register A: ".Length))
            .Select(long.Parse)
            .ToArray();
        var program = splits[1]
            .Substring("Program: ".Length)
            .Split(',')
            .Select(int.Parse)
            .ToArray();

        return string.Join(",", Run(registers, program));
    }

    public static long PuzzleTwo(string input)
    {
        var splits = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .ToArray();
        var registers = splits[0]
            .Split(Environment.NewLine)
            .Select(x => x.Substring("Register A: ".Length))
            .Select(long.Parse)
            .ToArray();
        var program = splits[1]
            .Substring("Program: ".Length)
            .Split(',')
            .Select(int.Parse)
            .ToArray();

        var queue = new Queue<long>(Enumerable.Range(0, 8).Select(x => x * 1L));
        for (var i = 0; i < program.Length; i++)
        {
            var nextQueue = new Queue<long>();
            while (queue.Any())
            {
                var current = queue.Dequeue();
                var newRegisters = registers.ToArray();
                newRegisters[0] = current;
                var outputted = Run(newRegisters, program);
                if (string.Join(",", outputted) == string.Join(",", program.Skip(program.Length - 1 - i)))
                {
                    if (i == program.Length - 1)
                    {
                        return current;
                    }
                    for (var j = 0; j < 8; j++)
                    {
                        nextQueue.Enqueue(current * 8 + j);
                    }
                }
            }
            queue = nextQueue;
        }

        throw new Exception();
    }

    private static List<long> Run(long[] registers, int[] program)
    {
        var output = new List<long>();

        var pointer = 0;
        while (pointer < program.Length)
        {
            var instruction = program[pointer];
            var operand = program[pointer + 1];
            if (instruction == 0)
            {
                registers[0] = Divide(operand);
            }
            else if (instruction == 1)
            {
                registers[1] ^= operand;
            }
            else if (instruction == 2)
            {
                registers[1] = GetCombo(operand) % 8;
            }
            else if (instruction == 3 && registers[0] != 0)
            {
                pointer = operand;
                continue;
            }
            else if (instruction == 4)
            {
                registers[1] ^= registers[2];
            }
            else if (instruction == 5)
            {
                output.Add(GetCombo(operand) % 8);
            }
            else if (instruction == 6)
            {
                registers[1] = Divide(operand);
            }
            else if (instruction == 7)
            {
                registers[2] = Divide(operand);
            }
            pointer += 2;
        }

        long GetCombo(int operand)
            => operand switch
            {
                4 => registers[0],
                5 => registers[1],
                6 => registers[2],
                7 => throw new Exception(),
                _ => operand
            };

        long Divide(int operand)
        {
            var combo = GetCombo(operand);
            var divisor = 1;
            for (var i = 0; i < combo; i++)
            {
                divisor *= 2;
                if (divisor > registers[0])
                {
                    return 0;
                }
            }
            return registers[0] / divisor;
        }

        return output;
    }
}