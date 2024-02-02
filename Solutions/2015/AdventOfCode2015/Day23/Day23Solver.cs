namespace AdventOfCode2015.Day23;

public static class Day23Solver
{
    public static int PuzzleOne(string input, int register = 1) => Solve(input, register, 0);

    public static int PuzzleTwo(string input) => Solve(input, 1, 1);

    private static int Solve(string input, int register, int seed)
    {
        var instructions = input
            .Split(Environment.NewLine)
            .Select(x => new Day23Instruction(x))
            .ToArray();

        var registers = new[] { seed, 0 };

        for (var i = 0; i < instructions.Length; i++)
        {
            var instruction = instructions[i];
            switch (instruction.Command)
            {
                case "hlf":
                    registers[instruction.Register] /= 2;
                    break;
                case "tpl":
                    registers[instruction.Register] *= 3;
                    break;
                case "inc":
                    registers[instruction.Register]++;
                    break;
                case "jmp":
                    i += instruction.Offset - 1;
                    break;
                case "jie":
                    if (registers[instruction.Register] % 2 == 0)
                    {
                        i += instruction.Offset - 1;
                    }
                    break;
                case "jio":
                    if (registers[instruction.Register] == 1)
                    {
                        i += instruction.Offset - 1;
                    }
                    break;
            }
        }

        return registers[register];
    }
}