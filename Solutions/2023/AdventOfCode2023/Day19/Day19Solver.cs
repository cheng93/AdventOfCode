namespace AdventOfCode2023.Day19;

public static class Day19Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var workflows = splits[0]
            .Split(Environment.NewLine)
            .Select(x => new Day19Workflow(x))
            .ToDictionary(x => x.Name);

        var parts = splits[1]
            .Split(Environment.NewLine)
            .Select(x => new Day19Part(x))
            .ToArray();

        var accepted = new List<Day19Part>();

        foreach (var part in parts)
        {
            var current = "in";
            while (current is not "A" and not "R")
            {
                var workflow = workflows[current];
                current = workflow.Run(part);
            }

            if (current == "A")
            {
                accepted.Add(part);
            }
        }

        return accepted.Sum(x => x.Rating);
    }

    public static long PuzzleTwo(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var workflows = splits[0]
            .Split(Environment.NewLine)
            .Select(x => new Day19Workflow(x))
            .ToDictionary(x => x.Name);

        var accepted = new List<Day19Ranges>();

        var queue = new Queue<(Day19Ranges Ranges, string Destination)>();
        queue.Enqueue((new(), "in"));

        while (queue.Any())
        {
            var (ranges, destination) = queue.Dequeue();
            var workflow = workflows[destination];

            foreach (var branch in workflow.Run(ranges))
            {
                if (branch.Destination == "A")
                {
                    accepted.Add(branch.Ranges);
                }
                else if (branch.Destination != "R")
                {
                    queue.Enqueue(branch);
                }
            }
        }

        return accepted.Sum(x => x.Combinations);
    }
}