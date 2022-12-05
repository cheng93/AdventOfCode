namespace AdventOfCode2022.Day05;

public class Day05Crane
{
    private readonly List<Stack<char>> stacks = new List<Stack<char>>();

    /*
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 
    */
    public Day05Crane(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var lists = new List<List<char>>();
        foreach (var line in lines.SkipLast(1))
        {
            for (var i = 1; i < line.Length; i += 4)
            {
                var index = i / 4;
                if (lists.Count == index)
                {
                    lists.Add(new List<char>());
                }

                var crate = line[i];
                if (crate != ' ')
                {
                    lists[index].Add(crate);
                }
            }
        }

        foreach (var list in lists)
        {
            list.Reverse();
            stacks.Add(new Stack<char>(list));
        }
    }

    public void Move9000(Day05Instruction instruction)
    {
        for (var i = 0; i < instruction.Count; i++)
        {
            var crate = stacks[instruction.From].Pop();
            stacks[instruction.To].Push(crate);
        }
    }

    public void Move9001(Day05Instruction instruction)
    {
        var stack = new Stack<char>();
        for (var i = 0; i < instruction.Count; i++)
        {
            var crate = stacks[instruction.From].Pop();
            stack.Push(crate);
        }

        while (stack.Any())
        {
            var crate = stack.Pop();
            stacks[instruction.To].Push(crate);
        }
    }

    public string Read() => string.Join(string.Empty, stacks.Select(x => x.Peek()));
}