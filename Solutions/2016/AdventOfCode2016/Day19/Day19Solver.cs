namespace AdventOfCode2016.Day19;

public static class Day19Solver
{
    public static int PuzzleOne(int input)
    {
        var elves = new LinkedList<int>();
        for (var i = 1; i <= input; i++)
        {
            elves.AddLast(i);
        }

        var current = elves.First;
        while (elves.Count > 1)
        {
            var next = current.Next ?? elves.First;
            elves.Remove(next);
            current = current.Next ?? elves.First;
        }

        return elves.First.Value;
    }

    public static int PuzzleTwo(int input)
    {
        var elves = new LinkedList<int>();
        LinkedListNode<int> remove = null;
        for (var i = 0; i < input; i++)
        {
            elves.AddLast(i);
            if (i == input / 2)
            {
                remove = elves.Last;
            }
        }

        while (elves.Count > 1)
        {
            var nextToRemove = remove.Next ?? elves.First;
            if (elves.Count % 2 == 1)
            {
                nextToRemove = nextToRemove.Next ?? elves.First;
            }
            elves.Remove(remove);
            remove = nextToRemove;
        }

        return elves.First.Value + 1;
    }
}