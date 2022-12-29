namespace AdventOfCode2016.Day23;

public class Day23Solver
{
    public static int PuzzleOne(IEnumerable<string> input) => Solve(input, 7);

    public static int PuzzleTwo(IEnumerable<string> input) => Solve(input, 12);

    private static int Solve(IEnumerable<string> input, int init)
    {
        var lines = input.ToArray();
        var registers = new int[4];
        registers[0] = init;

        for (var i = 0; i < lines.Length; i++)
        {
            var splits = lines[i].Split(" ");

            if (i == 5)
            {
                registers[0] += registers[2];
                registers[2] = 0;
                i = 7;
                continue;
            }
            if (i == 8)
            {
                registers[3]--;
                registers[0] += registers[1] * registers[3];
                registers[3] = 0;
                continue;
            }

            if (splits[0] == "cpy")
            {
                var value = int.TryParse(splits[1], out var parsed) ? parsed : registers[GetRegister(splits[1]).Value];
                var register = GetRegister(splits[2]);
                if (register != null)
                {
                    registers[register.Value] = value;
                }
            }
            else if (splits[0] == "inc")
            {
                var register = GetRegister(splits[1]);
                if (register != null)
                {
                    registers[register.Value]++;
                }
            }
            else if (splits[0] == "dec")
            {
                var register = GetRegister(splits[1]);
                if (register != null)
                {
                    registers[register.Value]--;
                }
            }
            else if (splits[0] == "jnz")
            {
                var value = int.TryParse(splits[1], out var v) ? v : registers[GetRegister(splits[1]).Value];
                var jump = int.TryParse(splits[2], out var j) ? j : registers[GetRegister(splits[2]).Value];
                if (value != 0)
                {
                    i += jump - 1;
                }
            }
            else if (splits[0] == "tgl")
            {
                var j = i + registers[GetRegister(splits[1]).Value];
                if (j >= 0 && j < lines.Length)
                {
                    var tglLine = lines[j];
                    if (tglLine.StartsWith("inc"))
                    {
                        lines[j] = tglLine.Replace("inc", "dec");
                    }
                    else if (tglLine.StartsWith("cpy"))
                    {
                        lines[j] = tglLine.Replace("cpy", "jnz");
                    }
                    else if (tglLine.StartsWith("jnz"))
                    {
                        lines[j] = tglLine.Replace("jnz", "cpy");
                    }
                    else if (tglLine.StartsWith("dec"))
                    {
                        lines[j] = tglLine.Replace("dec", "inc");
                    }
                    else if (tglLine.StartsWith("tgl"))
                    {
                        lines[j] = tglLine.Replace("tgl", "inc");
                    }
                }
            }
        }

        return registers[0];

        int? GetRegister(string x)
        {
            return x switch
            {
                "a" => 0,
                "b" => 1,
                "c" => 2,
                "d" => 3,
                _ => null
            };
        }
    }
}