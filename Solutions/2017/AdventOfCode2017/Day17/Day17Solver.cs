namespace AdventOfCode2017.Day17
{
    using System;
    using System.Collections.Generic;

    public class Day17Solver
    {
        public int PuzzleOne(int input)
        {
            var buffer = new LinkedList<int>();
            var position = 0;
            for (var i = 0; i <= 2017; i++)
            {
                if (i == 0)
                {
                    buffer.AddFirst(i);
                    continue;
                }

                var current = buffer.First;
                position = (position + input) % buffer.Count;
                for (var j = 0; j < position; j++)
                {
                    current = current.Next;
                }

                var added = buffer.AddAfter(current, i);
                position++;

                if (i == 2017)
                {
                    return (added.Next ?? buffer.First).Value;
                }
            }

            throw new Exception();
        }

        public int PuzzleTwo(int input)
        {
            var position = 0;
            var value = (int?)null;
            for (var i = 1; i <= 50000000; i++)
            {
                position = (position + input) % i;
                if (position == 0)
                {
                    value = i;
                }
                position++;
            }

            return value.Value;
        }
    }
}