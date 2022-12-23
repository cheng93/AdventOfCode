namespace AdventOfCode2016.Day12;

public class Day12Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var registers = new int[4];

        for (var i = 0; i < lines.Length; i++)
        {
            var splits = lines[i].Split(" ");

            if (splits[0] == "cpy")
            {
                var value = int.TryParse(splits[1], out var parsed) ? parsed : registers[GetRegister(splits[1])];
                registers[GetRegister(splits[2])] = value;
            }
            else if (splits[0] == "inc")
            {
                registers[GetRegister(splits[1])]++;
            }
            else if (splits[0] == "dec")
            {
                registers[GetRegister(splits[1])]--;
            }
            else if (splits[0] == "jnz")
            {
                var value = int.TryParse(splits[1], out var parsed) ? parsed : registers[GetRegister(splits[1])];
                if (value != 0)
                {
                    i += int.Parse(splits[2]) - 1;
                }
            }
        }

        return registers[0];

        int GetRegister(string x)
        {
            return x switch
            {
                "a" => 0,
                "b" => 1,
                "c" => 2,
                "d" => 3,
                _ => throw new Exception()
            };
        }
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var registers = new int[4];
        registers[2] = 1;

        for (var i = 0; i < lines.Length; i++)
        {
            var splits = lines[i].Split(" ");

            if (splits[0] == "cpy")
            {
                var value = int.TryParse(splits[1], out var parsed) ? parsed : registers[GetRegister(splits[1])];
                registers[GetRegister(splits[2])] = value;
            }
            else if (splits[0] == "inc")
            {
                registers[GetRegister(splits[1])]++;
            }
            else if (splits[0] == "dec")
            {
                registers[GetRegister(splits[1])]--;
            }
            else if (splits[0] == "jnz")
            {
                var value = int.TryParse(splits[1], out var parsed) ? parsed : registers[GetRegister(splits[1])];
                if (value != 0)
                {
                    i += int.Parse(splits[2]) - 1;
                }
            }
        }

        return registers[0];

        int GetRegister(string x)
        {
            return x switch
            {
                "a" => 0,
                "b" => 1,
                "c" => 2,
                "d" => 3,
                _ => throw new Exception()
            };
        }
    }
}