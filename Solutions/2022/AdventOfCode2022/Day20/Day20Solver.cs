namespace AdventOfCode2022.Day20;

public static class Day20Solver
{
    public static long PuzzleOne(IEnumerable<int> input) => Solve(input, 1, 1);

    public static long PuzzleTwo(IEnumerable<int> input) => Solve(input, 811589153, 10);

    private static long Solve(IEnumerable<int> input, long key, int iterations)
    {
        var numbers = input.Select(x => x * key).ToArray();
        var mixed = new LinkedList<long>(numbers);
        var lookup = new List<LinkedListNode<long>>();

        var node = mixed.First!;
        do
        {
            lookup.Add(node);
            node = node.Next;
        }
        while (node != null);

        for (var i = 0; i < iterations; i++)
        {
            for (var j = 0; j < numbers.Length; j++)
            {
                var current = lookup[j];
                var number = current.Value;
                var search = current.Previous ?? mixed.Last;
                mixed.Remove(current);

                var remainder = number % (numbers.Length - 1);

                if (number > 0)
                {
                    for (var k = 0; k < remainder; k++)
                    {
                        search = search!.Next ?? mixed.First;
                    }
                }
                else if (number < 0)
                {
                    for (var k = 0; k > remainder; k--)
                    {
                        search = search!.Previous ?? mixed.Last;
                    }
                }

                mixed.AddAfter(search!, current);
            }
        }

        node = mixed.Find(0);
        var sum = 0L;
        for (var i = 1; i <= 3000; i++)
        {
            node = node!.Next ?? mixed.First;
            if (i % 1000 == 0)
            {
                sum += node!.Value;
            }
        }

        return sum;
    }
}