using System.Text;

namespace AdventOfCode2022.Day10;

public static class Day10Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var signalStrengths = new List<int>();

        RunClockCircuit(input, CheckSignalStrength);

        return signalStrengths.Sum();

        void CheckSignalStrength(int cycle, int register)
        {
            if (cycle % 40 == 20)
            {
                signalStrengths.Add(cycle * register);
            }
        }
    }

    public static string PuzzleTwo(IEnumerable<string> input)
    {
        var sb = new StringBuilder();

        RunClockCircuit(input, Draw);

        return sb.ToString();

        void Draw(int cycle, int register)
        {
            var position = ((cycle + 39) % 40);
            var pixel = Math.Abs(register - position) <= 1
                ? '█'
                : '.';
            sb.Append(pixel);
            if (cycle % 40 == 0 && cycle != 240)
            {
                sb.AppendLine();
            }
        }
    }

    private static void RunClockCircuit(IEnumerable<string> input, Action<int, int> callback)
    {
        var cycle = 1;
        var register = 1;

        foreach (var line in input)
        {
            callback(cycle, register);
            if (line == "noop")
            {
                cycle++;
            }
            else
            {
                var splits = line.Split(" ");
                var value = int.Parse(splits[1]);

                cycle++;
                callback(cycle, register);
                cycle++;
                register += value;
            }
        }
    }
}