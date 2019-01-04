namespace AdventOfCode2017.Day12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day12Solver
    {
        public int PuzzleOne(string input)
        {
            var pipes = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day12Pipe(x));

            var recipients = pipes.ToDictionary(x => x.Id, x => x.Recipients);

            var programs = new HashSet<int>();
            var queued = new HashSet<int>();

            var queue = new Queue<int>();
            queue.Enqueue(0);
            queued.Add(0);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                programs.Add(node);

                foreach (var recipient in recipients[node])
                {
                    if (!programs.Contains(recipient) && !queued.Contains(recipient))
                    {
                        queue.Enqueue(recipient);
                        queued.Add(recipient);
                    }
                }
            }

            return programs.Count;
        }
        public int PuzzleTwo(string input)
        {
            var pipes = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day12Pipe(x));

            var recipients = pipes.ToDictionary(x => x.Id, x => x.Recipients);

            var queued = new HashSet<int>();

            var groups = 0;

            while (queued.Count < recipients.Count)
            {
                var programs = new HashSet<int>();
                var queue = new Queue<int>();
                var seed = recipients.Keys.First(x => !queued.Contains(x));
                queue.Enqueue(seed);
                queued.Add(seed);

                while (queue.Any())
                {
                    var node = queue.Dequeue();
                    programs.Add(node);

                    foreach (var recipient in recipients[node])
                    {
                        if (!programs.Contains(recipient) && !queued.Contains(recipient))
                        {
                            queue.Enqueue(recipient);
                            queued.Add(recipient);
                        }
                    }
                }
                groups++;
            }

            return groups;
        }
    }
}