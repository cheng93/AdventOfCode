namespace AdventOfCode2024.Day07;

public static class Day07Solver
{
    public static long PuzzleOne(string input)
        => Solve(
            input,
            [
                (x, y) => x + y,
                (x, y) => x * y,
            ]
        );

    public static long PuzzleTwo(string input)
        => Solve(
            input,
            [
                (x, y) => x + y,
                (x, y) => x * y,
                (x, y) => x * Enumerable.Range(0, (int)Math.Log10(y)).Aggregate(10L, (agg, cur) => agg * 10) + y,
            ]
        );

    private static long Solve(string input, Func<long, long, long>[] operators)
    {
        var equations = input
            .Split(Environment.NewLine)
            .Select(x => new Day07Equation(x));

        return equations
            .Where(IsPossiblyTrue)
            .Sum(x => x.Value);

        bool IsPossiblyTrue(Day07Equation equation)
        {
            var stack = new Stack<StackItem>();
            stack.Push(new(equation.Numbers[0], 1));
            while (stack.Any())
            {
                var current = stack.Pop();
                var values = operators
                    .Select(func => func(current.Value, equation.Numbers[current.Index]));

                if (current.Index + 1 == equation.Numbers.Length)
                {
                    if (values.Any(x => x == equation.Value))
                    {
                        return true;
                    }
                }
                else
                {
                    foreach (var value in values)
                    {
                        if (value <= equation.Value)
                        {
                            stack.Push(new(value, current.Index + 1));
                        }
                    }
                }
            }

            return false;
        }
    }

    private record StackItem(long Value, int Index);
}