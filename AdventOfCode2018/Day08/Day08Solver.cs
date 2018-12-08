namespace AdventOfCode2018.Day08
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day08Solver
    {
        public int PuzzleOne(IEnumerable<int> input)
        {
            var queue = new Queue<int>();

            foreach (var number in input)
            {
                queue.Enqueue(number);
            }

            var nodes = new Dictionary<int, int>();
            var metadataEntries = new Dictionary<int, int>();

            nodes.Add(0, 1);
            var initialNodes = queue.Dequeue();
            var initialMetaData = queue.Dequeue();

            nodes.Add(1, initialNodes);
            metadataEntries.Add(0, initialMetaData);

            var sum = 0;

            var level = 0;
            while (queue.Count > 0)
            {
                if (nodes[level + 1] == 0)
                {
                    for (var i = 0; i < metadataEntries[level]; i++)
                    {
                        var metaData = queue.Dequeue();
                        sum += metaData;
                    }

                    nodes[level] = nodes[level] - 1;

                    level -= 1;
                }
                else
                {
                    nodes[level + 2] = queue.Dequeue();
                    metadataEntries[level + 1] = queue.Dequeue();

                    level += 1;
                }
            }

            return sum;
        }

        public int PuzzleTwo(IEnumerable<int> input)
        {
            var queue = new Queue<int>();

            foreach (var number in input)
            {
                queue.Enqueue(number);
            }

            var nodes = new Dictionary<int, int>();
            var metadataEntries = new Dictionary<int, int>();
            var tracker = new Dictionary<int, List<int>>();
            var hasChildNodes = new Dictionary<int, bool>();

            nodes.Add(0, 1);
            var initialNodes = queue.Dequeue();
            var initialMetaData = queue.Dequeue();

            nodes.Add(1, initialNodes);
            metadataEntries.Add(0, initialMetaData);
            hasChildNodes.Add(0, initialNodes > 0);

            var level = 0;
            while (queue.Count > 0)
            {
                if (nodes[level + 1] == 0)
                {
                    var sum = 0;
                    for (var i = 0; i < metadataEntries[level]; i++)
                    {
                        var value = queue.Dequeue();
                        if (hasChildNodes[level])
                        {
                            if (tracker[level + 1].Count >= value)
                            {
                                value = tracker[level + 1][value - 1];
                            }
                            else
                            {
                                value = 0;
                            }
                        }

                        sum += value;
                    }
                    if (!tracker.ContainsKey(level))
                    {
                        tracker.Add(level, new List<int>());
                    }

                    tracker[level].Add(sum);
                    if (hasChildNodes[level])
                    {
                        tracker[level + 1].Clear();
                    }
                    nodes[level] = nodes[level] - 1;

                    level -= 1;
                }
                else
                {
                    var childNodes = queue.Dequeue();
                    nodes[level + 2] = childNodes;
                    metadataEntries[level + 1] = queue.Dequeue();
                    hasChildNodes[level + 1] = childNodes > 0;

                    level += 1;
                }
            }

            return tracker[0].Sum();
        }
    }
}