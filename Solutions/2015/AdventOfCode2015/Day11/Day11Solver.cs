namespace AdventOfCode2015.Day11;

public static class Day11Solver
{
    public static string PuzzleOne(string input) => Solve(input).First();

    public static string PuzzleTwo(string input) => Solve(input).Skip(1).First();

    public static IEnumerable<string> Solve(string input)
    {
        return Generate()
                .Where(Increasing)
                .Where(NotConfusing)
                .Where(HasOverlappingPairs);

        bool Increasing(string str)
        {
            for (var i = 0; i < str.Length - 2; i++)
            {
                var character = str[i];
                if (character + 1 == str[i + 1]
                    && character + 2 == str[i + 2])
                {
                    return true;
                }
            }

            return false;
        }

        bool NotConfusing(string str)
        {
            for (var i = 0; i < str.Length; i++)
            {
                var character = str[i];
                if (character == 'i'
                    || character == 'o'
                    || character == 'l')
                {
                    return false;
                }
            }

            return true;
        }

        bool HasOverlappingPairs(string str)
        {
            char? first = null;
            for (var i = 0; i < str.Length - 1; i++)
            {
                var character = str[i];
                if (first.HasValue && character == first.Value)
                {
                    continue;
                }

                if (str[i + 1] == character)
                {
                    if (first.HasValue)
                    {
                        return true;
                    }
                    first = character;
                    i++;
                }
            }
            return false;
        }

        IEnumerable<string> Generate()
        {
            var current = input;
            while (true)
            {
                var next = string.Empty;
                for (var i = current.Length - 1; i >= 0; i--)
                {
                    var character = current[i];
                    var prefix = character == 'z' ? 'a' : (char)(character + 1);
                    next = $"{prefix}{next}";
                    if (character != 'z' || i == 0)
                    {
                        current = $"{current[..i]}{next}";
                        break;
                    }
                }
                yield return current;
                if (current == "abcdffaa")
                {
                    yield break;
                }
            }
        }
    }
}