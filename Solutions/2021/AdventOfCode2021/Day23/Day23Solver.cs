using System.Text;

namespace AdventOfCode2021.Day23;

public static class Day23Solver
{
    public static int PuzzleOne(string input) => Solve(input);

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sb = new StringBuilder();
        sb.AppendJoin(Environment.NewLine, lines[0..3]);
        sb.AppendLine();
        sb.AppendLine("  #D#C#B#A#");
        sb.AppendLine("  #D#B#A#C#");
        sb.AppendJoin(Environment.NewLine, lines[3..]);

        return Solve(sb.ToString());
    }

    private static int Solve(string input)
    {
        var initial = Day23State.Create(input);

        var min = int.MaxValue;

        var energies = new Dictionary<string, int>();
        energies.Add(initial.ToString(), 0);

        var visited = new HashSet<string>();

        var queue = new PriorityQueue<Day23State, int>();
        queue.Enqueue(initial, 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Sorted)
            {
                return energies[current.ToString()];
            }

            if (visited.Contains(current.ToString()))
            {
                continue;
            }
            visited.Add(current.ToString());

            foreach (var next in current.GetNextStates())
            {
                var totalEnergy = energies[current.ToString()] + next.Energy;
                if (!energies.TryGetValue(next.State.ToString(), out var energy)
                    || totalEnergy < energy)
                {
                    energies[next.State.ToString()] = totalEnergy;
                    queue.Enqueue(next.State, totalEnergy);
                }
            }
        }

        return min;
    }
}