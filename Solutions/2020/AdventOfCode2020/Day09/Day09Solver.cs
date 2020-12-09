using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day09
{
    public class Day09Solver
    {
        public long PuzzleOne(IEnumerable<long> input, int length = 25)
        {
            var queue = new Queue<long>();
            foreach (var number in input)
            {
                if (queue.Count < length)
                {
                    queue.Enqueue(number);
                    continue;
                }

                var list = queue.ToArray();
                var errored = true;
                for (var i = 0; i < queue.Count; i++)
                {
                    for (var j = i + 1; j < queue.Count; j++)
                    {
                        if (list[i] + list[j] == number)
                        {
                            errored = false;
                        }
                    }
                }

                if (errored)
                {
                    return number;
                }

                queue.Dequeue();
                queue.Enqueue(number);
            }

            throw new System.Exception();

        }

        public long PuzzleTwo(IEnumerable<long> input, int length = 25)
        {
            var target = this.PuzzleOne(input, length);

            var queues = new List<Queue<long>>();

            foreach (var number in input)
            {
                if (queues.Count < length)
                {
                    for (var i = 0; i < queues.Count; i++)
                    {
                        queues[i].Enqueue(number);
                    }
                    queues.Add(new Queue<long>(new[] { number }));
                    continue;
                }

                for (var i = 0; i < queues.Count; i++)
                {
                    var queue = queues[i];
                    queue.Dequeue();
                    queue.Enqueue(number);

                    if (queue.Sum() == target)
                    {
                        return queue.Min() + queue.Max();
                    }
                }
            }
            throw new System.Exception();
        }
    }
}