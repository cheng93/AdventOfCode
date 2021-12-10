namespace AdventOfCode2021.Day10;

public static class Day10Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
        => Solve(input).Corrupt.Sum();

    public static long PuzzleTwo(IEnumerable<string> input)
        => Solve(input).Incomplete.First();

    private static (IEnumerable<int> Corrupt, IEnumerable<long> Incomplete) Solve(IEnumerable<string> input)
    {
        var corrupt = new List<char>();
        var incomplete = new List<Stack<char>>();
        foreach (var line in input)
        {
            var isCorrupt = false;
            var stack = new Stack<char>();
            foreach (var character in line)
            {
                switch (character)
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '<':
                        stack.Push('>');
                        break;
                    default:
                        var pop = stack.Pop();
                        if (pop != character)
                        {
                            corrupt.Add(character);
                            isCorrupt = true;
                        }
                        break;
                }
                if (isCorrupt)
                {
                    break;
                }
            }

            if (!isCorrupt && stack.Any())
            {
                incomplete.Add(stack);
            }
        }

        long Score(Stack<char> stack)
        {
            var score = 0L;
            while (stack.Any())
            {
                var character = stack.Pop();

                score *= 5;
                score += character switch
                {
                    ')' => 1,
                    ']' => 2,
                    '}' => 3,
                    '>' => 4,
                    _ => throw new System.ArgumentException()
                };
            }
            return score;
        };

        var corruptPoints = corrupt
            .Select(x => x switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                _ => throw new System.ArgumentException()
            });
        var incompletePoints = incomplete
            .Select(Score)
            .OrderBy(x => x)
            .Skip(incomplete.Count / 2);

        return (corruptPoints, incompletePoints);
    }

}