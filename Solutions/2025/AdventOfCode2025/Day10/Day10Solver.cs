namespace AdventOfCode2025.Day10;

using PuzzleOneQueueItem = (bool[] Lights, int[] Button, int Depth);
using PuzzleTwoQueueItem = (int[] Joltage, int[] Button, int Depth);

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
            var queue = new Queue<PuzzleOneQueueItem>(
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
            var cache = new Dictionary<string, int?>();
            var stack = new Stack<int[]>();
            stack.Push(machine.Joltages);

            while (stack.Any())
            {
                var current = stack.Pop();
            }

            string CacheKey(int[] joltages) => string.Join('|', joltages);

            return 0;
        }
    }
}