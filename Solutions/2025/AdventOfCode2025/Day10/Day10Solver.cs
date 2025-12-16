using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MoreLinq;

namespace AdventOfCode2025.Day10;

using QueueItem = (bool[] Lights, int[] Button, int Depth);

public static class Day10Solver
{
    public static int PuzzleOne(string input)
    {
        var machines = input
            .Split(Environment.NewLine)
            .Select(l => new Day10Machine(l))
            .ToArray();

        return machines.Select(FewestPresses).Sum();

        int FewestPresses(Day10Machine machine)
        {
            var queue = new Queue<QueueItem>(
                machine.Buttons.Select(b => (new bool[machine.Goal.Length], b, 0)));

            var seen = new HashSet<string>() { new('.', machine.Goal.Length) };

            while (queue.Any())
            {
                var (lights, button, depth) = queue.Dequeue();

                foreach (var index in button)
                {
                    lights[index] = !lights[index];
                }

                if (lights.SequenceEqual(machine.Goal))
                {
                    return depth + 1;
                }
                
                var cacheKey = string.Join(string.Empty, lights.Select(x => x ? '#' : '.'));
                if (!seen.Add(cacheKey))
                {
                    continue;
                }

                foreach (var next in machine.Buttons)
                {
                    queue.Enqueue((lights.ToArray(), next, depth + 1));
                }
            }

            throw new Exception();
        }
    }

    public static long PuzzleTwo(string input)
    {
        var machines = input
            .Split(Environment.NewLine)
            .Select(l => new Day10Machine(l))
            .ToArray();

        return machines.Select(FewestPresses).Sum();

        int FewestPresses(Day10Machine machine)
        {
            var buttons = machine.Buttons
                .Select(indices =>
                {
                    var vector = Vector<double>.Build.Dense(machine.Joltages.Length);
                    foreach (var index in indices)
                    {
                        vector.At(index, 1);
                    }
                    return vector;
                });
            var joltages = Vector<double>.Build.DenseOfEnumerable(machine.Joltages.Select(Convert.ToDouble));
            var matrix = Matrix<double>.Build.DenseOfColumnVectors([..buttons, joltages]);

            var h = 0;
            var k = 0;
            var m = matrix.RowCount;
            var n = matrix.ColumnCount;
            while (h < m && k < n)
            {
                var vector = matrix.Column(k, h, m - h);
                var iMax = h + vector.AbsoluteMaximumIndex();
                if (matrix[iMax, k] == 0)
                {
                    k++;
                }
                else
                {
                    if (h != iMax)
                    {
                        var hRow = matrix.Row(h);
                        var iMaxRow = matrix.Row(iMax);
                        matrix.SetRow(h, iMaxRow);
                        matrix.SetRow(iMax, hRow);
                    }

                    for (var i = h + 1; i < m; i++)
                    {
                        var f = matrix[i, k] / matrix[h, k];
                        for (var j = k; j < n; j++)
                        {
                            matrix[i, j] -= matrix[h,j] * f;
                        }
                    }

                    h++;
                    k++;
                }
            }

            // Console.WriteLine(matrix);

            var min = (int)joltages.Sum();
            var stack = new Stack<(int?[] Solution, int Depth)>();
            stack.Push((new int?[matrix.ColumnCount - 1], 0));
            var seen = new HashSet<(string, int)>();

            bool TryAddStack(int?[] solution, int depth)
            {
                var cacheItem = (string.Join('|', solution), depth);
                if (seen.Add(cacheItem))
                {
                    // Console.WriteLine(matrix);
                    // Console.WriteLine(cacheItem);
                    stack.Push((solution, depth));
                    return true;
                }
                return false;
            }

            while (stack.Any())
            {
                var (solution, depth) = stack.Pop();
                var sum = solution.Select(x => x ?? 0).Sum();
                if (sum > min)
                {
                    continue;
                }
                if (depth == matrix.RowCount)
                {
                    if (solution.Any(x => !x.HasValue))
                    {
                        continue;
                    }
                    var testVector = Vector<double>.Build.DenseOfEnumerable(solution.Select(x => x.Value).Select(Convert.ToDouble));
                    if ((Matrix<double>.Build.DenseOfColumnVectors(buttons) * testVector).Equals(joltages))
                    {
                        min = Math.Min(min, sum);
                    }
                    continue;
                }
                var vector = matrix.Row(matrix.RowCount - depth - 1);
                var last = vector.Last();
                var elements = vector.EnumerateIndexed()
                    .SkipLast(1)
                    .Where(x => Math.Abs(0 - x.Item2) > 0.000001)
                    .ToArray();
                var unknown = elements.Where(x => !solution[x.Item1].HasValue)
                    .ToArray();

                if (unknown.Length == 0)
                {
                    TryAddStack(solution, depth + 1);
                    continue;
                };
                
                var newLast = last - elements
                    .Select(x => (solution[x.Item1] ?? 0) * x.Item2)
                    .Sum();
                var currentJoltages = machine.Joltages.ToArray();
                for (var i = 0; i < solution.Length; i++)
                {
                    var presses = solution[i];
                    if (!presses.HasValue)
                    {
                        continue;
                    }
                    foreach (var index in machine.Buttons[i])
                    {
                        currentJoltages[index] -= presses.Value;
                    }
                }

                for (var i = 0; i < unknown.Length; i++)
                {
                    var element = unknown[i];
                    var value = newLast / element.Item2;
                    var maxValue = machine.Buttons[element.Item1]
                        .Select(index => currentJoltages[index])
                        .Min();
                    if (i == unknown.Length - 1)
                    {
                        var rounded = (int)Math.Round(value, 0);
                        if (Math.Abs(rounded - value) > 0.00001 || rounded < 0 || rounded > maxValue)
                        {
                            continue;
                        }

                        var copy = solution.ToArray();
                        copy[element.Item1] = rounded;

                        TryAddStack(copy, depth + 1);
                        continue;
                    }
                    for (var j = 0; j <= maxValue; j++)
                    {
                        var copy = solution.ToArray();
                        copy[element.Item1] = j;
                        TryAddStack(copy, depth);
                    }
                }
            }

            if (min == (int)joltages.Sum())
            {
                // Console.WriteLine(min);
                // Console.WriteLine(matrix);
                throw new Exception();
            }
            return min;
        }
    }
}