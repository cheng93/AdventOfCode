namespace AdventOfCode2022.Day21;

public static class Day21Solver
{
    public static long PuzzleOne(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var numbers = new Dictionary<string, long>();
        var operators = new Dictionary<string, Func<long>>();
        var searching = new Dictionary<string, int>();
        var dependents = new Dictionary<string, List<string>>();

        var queue = new Queue<string>();

        foreach (var line in lines)
        {
            var splits = line.Split(": ");
            var monkey = splits[0];
            dependents.TryAdd(monkey, new List<string>());

            if (int.TryParse(splits[1], out var parsed))
            {
                numbers[monkey] = parsed;
                queue.Enqueue(monkey);
            }
            else
            {
                var operationParts = splits[1].Split(" ");
                operators[monkey] = operationParts[1] switch
                {
                    "+" => () => numbers[operationParts[0]] + numbers[operationParts[2]],
                    "-" => () => numbers[operationParts[0]] - numbers[operationParts[2]],
                    "*" => () => numbers[operationParts[0]] * numbers[operationParts[2]],
                    "/" => () => numbers[operationParts[0]] / numbers[operationParts[2]],
                    _ => throw new Exception()
                };
                searching[monkey] = 2;
                dependents.TryAdd(operationParts[0], new List<string>());
                dependents[operationParts[0]].Add(monkey);
                dependents.TryAdd(operationParts[2], new List<string>());
                dependents[operationParts[2]].Add(monkey);
            }
        }

        while (queue.Any())
        {
            var current = queue.Dequeue();
            foreach (var dependent in dependents[current])
            {
                searching[dependent]--;

                if (searching[dependent] == 0)
                {
                    numbers[dependent] = operators[dependent]();
                    queue.Enqueue(dependent);
                }
            }
        }

        return numbers["root"];
    }

    public static long PuzzleTwo(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var numbers = new Dictionary<string, long>();
        var operators = new Dictionary<string, Func<long>>();
        var searching = new Dictionary<string, int>();
        var dependents = new Dictionary<string, List<string>>();
        var rootKeys = new List<string>();
        foreach (var line in lines)
        {
            var splits = line.Split(": ");
            var monkey = splits[0];
            dependents.TryAdd(monkey, new List<string>());

            if (int.TryParse(splits[1], out var parsed))
            {
                numbers[monkey] = parsed;
            }
            else if (splits[0] == "root")
            {
                var operationParts = splits[1].Split(" ");
                rootKeys.Add(operationParts[0]);
                rootKeys.Add(operationParts[2]);
            }
            else
            {
                var operationParts = splits[1].Split(" ");
                operators[monkey] = operationParts[1] switch
                {
                    "+" => () => numbers[operationParts[0]] + numbers[operationParts[2]],
                    "-" => () => numbers[operationParts[0]] - numbers[operationParts[2]],
                    "*" => () => numbers[operationParts[0]] * numbers[operationParts[2]],
                    "/" => () => numbers[operationParts[0]] / numbers[operationParts[2]],
                    _ => throw new Exception()
                };
                searching[monkey] = 2;
                dependents.TryAdd(operationParts[0], new List<string>());
                dependents[operationParts[0]].Add(monkey);
                dependents.TryAdd(operationParts[2], new List<string>());
                dependents[operationParts[2]].Add(monkey);
            }
        }
        numbers.Remove("humn");
        var queue = new Queue<string>(numbers.Keys);
        while (queue.Any())
        {
            var current = queue.Dequeue();
            foreach (var dependent in dependents[current])
            {
                searching[dependent]--;

                if (searching[dependent] == 0)
                {
                    numbers[dependent] = operators[dependent]();
                    queue.Enqueue(dependent);
                }
            }
        }

        var root = numbers.TryGetValue(rootKeys[0], out var r1)
            ? r1
            : numbers.TryGetValue(rootKeys[1], out var r2)
            ? r2
            : throw new Exception();

        operators = new Dictionary<string, Func<long>>();
        dependents = new Dictionary<string, List<string>>();

        numbers["root"] = root;
        foreach (var line in lines)
        {
            var splits = line.Split(": ");
            var monkey = splits[0];
            dependents.TryAdd(monkey, new List<string>());

            if (int.TryParse(splits[1], out var parsed))
            {
                continue;
            }
            else if (monkey == "root")
            {
                var operationParts = splits[1].Split(" ");
                numbers[operationParts[0]] = root;
                numbers[operationParts[2]] = root;
            }
            else
            {
                var operationParts = splits[1].Split(" ");
                if (numbers.TryGetValue(operationParts[0], out var n1))
                {
                    operators[operationParts[2]] = operationParts[1] switch
                    {
                        "+" => () => numbers[monkey] - numbers[operationParts[0]],
                        "-" => () => numbers[operationParts[0]] - numbers[monkey],
                        "*" => () => numbers[monkey] / numbers[operationParts[0]],
                        "/" => () => numbers[operationParts[0]] / numbers[monkey],
                        _ => throw new Exception()
                    };
                    dependents[monkey].Add(operationParts[2]);
                }
                else
                {
                    operators[operationParts[0]] = operationParts[1] switch
                    {
                        "+" => () => numbers[monkey] - numbers[operationParts[2]],
                        "-" => () => numbers[monkey] + numbers[operationParts[2]],
                        "*" => () => numbers[monkey] / numbers[operationParts[2]],
                        "/" => () => numbers[monkey] * numbers[operationParts[2]],
                        _ => throw new Exception()
                    };
                    dependents[monkey].Add(operationParts[0]);
                }
            }
        }

        queue = new Queue<string>(numbers.Keys);
        while (queue.Any())
        {
            var current = queue.Dequeue();
            foreach (var dependent in dependents[current])
            {
                numbers[dependent] = operators[dependent]();
                queue.Enqueue(dependent);
            }
        }

        return numbers["humn"];
    }
}