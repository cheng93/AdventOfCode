namespace AdventOfCode2021.Day03;

public static class Day03Solver
{
    public static long PuzzleOne(IEnumerable<string> input)
    {
        var array = input.ToArray();
        var lineLength = array[0].Length;
        var zeros = new int[lineLength];
        var ones = new int[lineLength];

        foreach (var line in array)
        {
            for (var i = 0; i < lineLength; i++)
            {
                if (line[i] == '0')
                {
                    zeros[i]++;
                }
                else
                {
                    ones[i]++;
                }
            }
        }

        var max = zeros.Select((x, i) => x > ones[i] ? 0 : 1);
        var min = zeros.Select((x, i) => x < ones[i] ? 0 : 1);

        var gamma = GetNumber(max);
        var epsilon = GetNumber(min);

        return gamma * epsilon;

        long GetNumber(IEnumerable<int> binary)
        {
            var str = string.Join("", binary);
            return Convert.ToInt64(str, 2);
        }
    }

    public static long PuzzleTwo(IEnumerable<string> input)
    {
        var list = input.ToList();

        string Recurse(List<string> lines, int depth, Func<int, int, bool> predicate)
        {
            if (lines.Count == 1)
            {
                return lines.First();
            }

            var zeros = new List<string>();
            var ones = new List<string>();

            foreach (var line in lines)
            {
                var character = line[depth];
                if (character == '0')
                {
                    zeros.Add(line);
                }
                else
                {
                    ones.Add(line);
                }
            }

            var next = predicate(zeros.Count, ones.Count)
                ? zeros
                : ones;

            return Recurse(next, depth + 1, predicate);
        }

        var oxygen = Convert.ToInt64(Recurse(list, 0, (zeros, ones) => zeros > ones), 2);
        var carbon = Convert.ToInt64(Recurse(list, 0, (zeros, ones) => zeros <= ones), 2);

        return oxygen * carbon;
    }
}