namespace AdventOfCode2016.Day25;

public class Day25Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var lines = input.ToArray();

        var a = 0;
        while (true)
        {
            ;
            var registers = new int[4];
            registers[0] = a;

            var clockSignal = new List<int>();
            for (var i = 0; i < lines.Length; i++)
            {
                var splits = lines[i].Split(" ");

                if (i == 4)
                {
                    registers[1]--;
                    registers[3] += registers[1];
                    registers[1] = 0;
                    continue;
                }

                if (i == 6)
                {
                    registers[2]--;
                    registers[3] += 231 * registers[2];
                    registers[2] = 0;
                    continue;
                }
                if (i == 13)
                {
                    registers[0] = registers[1] / 2;
                    registers[2] = registers[1] % 2 == 0 ? 2 : 1;
                    registers[1] = 0;
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
                else if (splits[0] == "out")
                {
                    var value = int.TryParse(splits[1], out var parsed) ? parsed : registers[GetRegister(splits[1]).Value];
                    clockSignal.Add(value);

                    if (clockSignal.Count > 1 && clockSignal[^2] == clockSignal.Last()
                        || clockSignal.Count > 100)
                    {
                        break;
                    }
                }
            }

            if (clockSignal.Count > 100)
            {
                break;
            }

            a++;
        }

        return a;

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