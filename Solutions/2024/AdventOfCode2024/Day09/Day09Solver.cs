namespace AdventOfCode2024.Day09;

public static class Day09Solver
{
    public static long PuzzleOne(string input)
    {
        var files = new Stack<int>();
        var sorted = new List<int>();
        var memory = new Queue<int?>();

        var id = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var number = int.Parse(input[i].ToString());
            var isEven = i % 2 == 0;
            for (var j = 0; j < number; j++)
            {
                if (isEven)
                {
                    files.Push(id);
                    memory.Enqueue(id);
                }
                else
                {
                    memory.Enqueue(null);
                }
            }
            if (isEven)
            {
                id++;
            }
        }

        var length = files.Count;
        while (sorted.Count < length)
        {
            var current = memory.Dequeue();
            if (current.HasValue)
            {
                sorted.Add(current.Value);
            }
            else
            {
                sorted.Add(files.Pop());
            }
        }

        return sorted
            .Select((x, i) => i * x * 1L)
            .Sum();
    }

    public static long PuzzleTwo(string input)
    {
        var files = new List<Day09Block>();
        var available = new List<Day09Block>();

        var index = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var number = int.Parse(input[i].ToString());
            var isEven = i % 2 == 0;
            if (isEven)
            {
                files.Add(new(index, number));
            }
            else
            {
                available.Add(new(index, number));
            }
            index += number;
        }

        for (var i = files.Count - 1; i >= 0; i--)
        {
            var file = files[i];
            var space = available
                .FirstOrDefault(x => x.Size >= file.Size && x.Index < file.Index);
            if (space != null)
            {
                space.Size -= file.Size;
                file.Index = space.Index;
                space.Index += file.Size;
            }
        }

        var sorted = files
            .Select((x, i) => new
            {
                Id = i,
                Index = x.Index,
                Size = x.Size
            })
            .OrderBy(x => x.Index)
            .ToArray();

        index = 0;
        var sum = 0L;
        for (var i = 0; i < sorted.Length; i++)
        {
            var current = sorted[i];
            if (i > 0)
            {
                index += current.Index - sorted[i - 1].Index;
            }

            for (var j = 0; j < current.Size; j++)
            {
                sum += (index + j) * current.Id;
            }
        }
        return sum;
    }
}