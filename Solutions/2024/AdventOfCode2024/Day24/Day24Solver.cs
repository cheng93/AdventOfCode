namespace AdventOfCode2024.Day24;

public static class Day24Solver
{
    public static long PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var values = splits[0]
            .Split(Environment.NewLine)
            .Select(x => x.Split(": "))
            .ToDictionary(x => x[0], x => x[1] == "1");

        var gates = splits[1]
            .Split(Environment.NewLine)
            .Select(x => new Day24Gate(x))
            .ToArray();

        return Run(values, gates);
    }

    public static string PuzzleTwo(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var values = splits[0]
            .Split(Environment.NewLine)
            .Select(x => x.Split(": "))
            .ToDictionary(x => x[0], x => x[1] == "1");

        var gates = splits[1]
            .Split(Environment.NewLine)
            .Select(x => new Day24Gate(x))
            .ToArray();

        var inputLookup = new Dictionary<Day24Input, string>();
        var wireLookup = new Dictionary<string, Day24Gate>();

        foreach (var gate in gates)
        {
            inputLookup.Add(gate.Input, gate.Output);
            wireLookup.Add(gate.Output, gate);
        }

        var max = wireLookup.Keys
            .Where(x => x.StartsWith("z"))
            .Select(x => int.Parse(x[1..]))
            .Max();

        var swapped = new List<string>();
        var seen = new List<Day24Input> { };
        const string xor = "XOR";
        const string or = "OR";
        const string and = "AND";

        for (var i = 0; i <= max; i++)
        {
            Fix(i);
        }

        return string.Join(",", swapped.OrderBy(x => x));

        void Fix(int i)
        {
            Console.WriteLine(i);
            var xWire = Wire("x", i);
            var yWire = Wire("y", i);
            var zWire = Wire("z", i);
            Day24Input expected = null!;
            if (i == 0)
            {
                // z0 = x0 ^ y0
                expected = new(xWire, xor, yWire);
            }
            else
            {
                var carry = seen[i - 1] with { Logic = and };

                // i == 1:  z1 = (x1 ^ y1) ^ (x0 & y0)
                if (i > 1)
                {
                    // zN = (xN ^ yN) ^ ((xN-1 & yN-1) | ((xN-1 ^ yN-1) & (xN-2 & yN-2)))
                    var ored = inputLookup[carry];
                    carry = inputLookup.Keys.First(x =>
                        x.Logic == or
                        && (x.Left == ored || x.Right == ored));
                    var carryOther = carry.Left == ored
                        ? carry.Right
                        : carry.Left;
                    var prevAnd = new Day24Input(Wire("x", i - 1), and, Wire("y", i - 1));
                    if (wireLookup[carryOther].Input != prevAnd)
                    {
                        Swap(carryOther, inputLookup[prevAnd]);
                    }
                }
                if (i < max)
                {
                    var carryWire = inputLookup[carry];
                    expected = inputLookup.Keys.First(x =>
                        x.Logic == xor
                        && (x.Left == carryWire || x.Right == carryWire));
                    var other = expected.Left == carryWire
                        ? expected.Right
                        : expected.Left;
                    var xored = new Day24Input(xWire, xor, yWire);
                    if (wireLookup[other].Input != xored)
                    {
                        Swap(other, inputLookup[xored]);
                    }
                }
                else
                {
                    // M = Max
                    // zM = (xM-1 & yM-1) | ((xM-1 ^ yM-1) & (nM-2 & yM-2))
                    expected = carry;

                }
            }

            if (wireLookup[zWire].Input != expected)
            {
                Swap(zWire, inputLookup[expected]);
            }
            seen.Add(expected);
        }

        void Swap(string a, string b)
        {
            var aGate = wireLookup[a];
            var bGate = wireLookup[b];
            aGate.Swap(bGate);
            swapped.Add(a);
            swapped.Add(b);
            inputLookup[aGate.Input] = aGate.Output;
            inputLookup[bGate.Input] = bGate.Output;
            wireLookup[aGate.Output] = aGate;
            wireLookup[bGate.Output] = bGate;
        }

        string Wire(string prefix, int number) => $"{prefix}{number:D2}";
    }

    private static long Run(Dictionary<string, bool> values, ICollection<Day24Gate> gates)
    {
        var lookup = new Dictionary<string, List<Day24Gate>>();

        foreach (var gate in gates)
        {
            if (!lookup.TryGetValue(gate.Left, out var left))
            {
                left = new();
                lookup.Add(gate.Left, left);
            }
            left.Add(gate);
            if (!lookup.TryGetValue(gate.Right, out var right))
            {
                right = new();
                lookup.Add(gate.Right, right);
            }
            right.Add(gate);
        }

        var queue = new Queue<string>();
        foreach (var wire in values.Keys)
        {
            queue.Enqueue(wire);
        }

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (!lookup.TryGetValue(current, out var currentGates))
            {
                continue;
            }
            foreach (var gate in currentGates)
            {
                if (values.ContainsKey(gate.Output))
                {
                    continue;
                }

                if (values.TryGetValue(gate.Left, out var left)
                    && values.TryGetValue(gate.Right, out var right))
                {
                    values[gate.Output] = gate.GetValue(values);
                    queue.Enqueue(gate.Output);
                }
            }
        }

        return GetValue(values, "z");
    }

    private static long GetValue(Dictionary<string, bool> values, string prefix)
    {
        var binary = string.Join(
            string.Empty,
            values
                .Where(x => x.Key.StartsWith(prefix))
                .OrderByDescending(x => int.Parse(x.Key[prefix.Length..]))
                .Select(x => x.Value ? 1 : 0));
        return Convert.ToInt64(binary, 2);
    }
}