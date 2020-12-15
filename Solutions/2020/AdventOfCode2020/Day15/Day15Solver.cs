using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day15
{
    public class Day15Solver
    {
        public int PuzzleOne(IEnumerable<int> input) => Solve(input, 2020);

        public int PuzzleTwo(IEnumerable<int> input) => Solve(input, 30000000);

        private static int Solve(IEnumerable<int> input, int nth)
        {
            var queues = input
                .Select((x, i) => new { x, i })
                .ToDictionary(x => x.x, x => new Queue<int>(new[] { x.i }));

            var last = queues.Keys.Last();

            for (var i = queues.Count; i < nth; i++)
            {
                var queue = queues[last];
                if (queue.Count == 1)
                {
                    last = 0;
                }
                else
                {
                    var array = queue.ToArray();
                    last = array[1] - array[0];
                }
                if (queues.TryGetValue(last, out var q))
                {
                    if (q.Count == 2)
                    {
                        q.Dequeue();
                    }
                    q.Enqueue(i);
                }
                else
                {
                    queues[last] = new Queue<int>(new[] { i });
                }
            }

            return last;
        }
    }
}