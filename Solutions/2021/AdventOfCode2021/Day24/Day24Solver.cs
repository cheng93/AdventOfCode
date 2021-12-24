namespace AdventOfCode2021.Day24;

public static class Day24Solver
{
    public static long PuzzleOne(IEnumerable<string> input) => Solve(input).Max();

    public static long PuzzleTwo(IEnumerable<string> input) => Solve(input).Min();

    private static IEnumerable<long> Solve(IEnumerable<string> input)
    {
        var lines = input.ToArray();

        var map = new Dictionary<string, int>()
        {
            { "w", 0 },
            { "x", 1 },
            { "y", 2 },
            { "z", 3 },
        };

        var state = new int[4];
        var i = -1;
        var div26 = false;
        var stack = new Stack<int>();
        var transforms = new List<(int A, int B, Func<int, int> Run)>();
        foreach (var line in lines)
        {
            var splits = line.Split(" ");
            var instruction = splits[0];
            var a = map[splits[1]];

            if (instruction == "inp")
            {
                i++;
                state[a] = 0;
                if (div26)
                {
                    state[map["y"]] = 0;
                    state[map["z"]] /= 26;
                    div26 = false;
                }
                else
                {
                    stack.Push(i);
                }
            }
            else
            {
                var b = int.TryParse(splits[2], out var num)
                    ? num
                    : state[map[splits[2]]];

                switch (instruction)
                {
                    case "add":
                        state[a] += b;
                        break;
                    case "mul":
                        state[a] *= b;
                        break;
                    case "div":
                        div26 = splits[1] == "z" && b == 26;
                        state[a] /= b;
                        break;
                    case "mod":
                        state[a] %= b;
                        break;
                    case "eql":
                        if (div26 && splits[2] == "w")
                        {
                            var popped = stack.Pop();
                            var diff = state[map["x"]];
                            transforms.Add((popped, i, (Func<int, int>)(x => x + diff)));
                        }
                        state[a] = state[a] == b ? 1 : 0;
                        break;
                }
            }
        }

        IEnumerable<int[]> Dfs(int depth, int[] str)
        {
            if (depth == transforms.Count)
            {
                yield return str;
            }
            else
            {
                var transform = transforms[depth];
                for (var i = 1; i <= 9; i++)
                {
                    var x = i;
                    var y = transforms[depth].Run(x);
                    if (y >= 1 && y <= 9)
                    {
                        var inners = Dfs(depth + 1, str.ToArray());
                        foreach (var inner in inners)
                        {
                            inner[transform.A] = x;
                            inner[transform.B] = y;
                            yield return inner;
                        }
                    }
                }
            }
        }

        return Dfs(0, new int[14])
            .Select(x => long.Parse(string.Join("", x)));
    }
}