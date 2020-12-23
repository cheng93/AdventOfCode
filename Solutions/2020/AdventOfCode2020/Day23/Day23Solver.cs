using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day23
{
    public class Day23Solver
    {
        public string PuzzleOne(string input)
        {
            var numbers = input
                .Select(x => int.Parse(x.ToString()))
                .ToList();

            var result = Run(numbers, 100, numbers.Max());

            var output = string.Empty;
            var node = result.Lookup[1];
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                node = node.Next ?? result.First;
                output += node.Value.ToString();
            }

            return output;
        }

        public long PuzzleTwo(string input)
        {
            var numbers = input
                .Select(x => int.Parse(x.ToString()))
                .ToList();

            var result = Run(numbers, 10000000, 1000000);

            var one = result.Lookup[1];
            var a = one.Next ?? result.First;
            var b = a.Next ?? result.First;
            return 1L * a.Value * b.Value;
        }

        private static (Dictionary<int, LinkedListNode<int>> Lookup, LinkedListNode<int> First) Run(List<int> numbers, int iterations, int max)
        {
            var circle = new LinkedList<int>(numbers);
            var nodeLookup = numbers.ToDictionary(x => x, x => circle.Find(x));

            for (var i = numbers.Max() + 1; i <= max; i++)
            {
                numbers.Add(i);
                var n = circle.AddLast(i);
                nodeLookup[i] = n;
            }

            var current = circle.First;

            for (var i = 0; i < iterations; i++)
            {
                var three = new LinkedListNode<int>[3];
                for (var j = 0; j < 3; j++)
                {
                    var node = GetNext(current);
                    three[j] = node;
                    circle.Remove(node);
                }

                LinkedListNode<int> destination = null;
                for (var j = 1; j <= 4; j++)
                {
                    var next = current.Value - j;
                    if (!nodeLookup.TryGetValue(next, out var node))
                    {
                        node = nodeLookup[nodeLookup.Count + next];
                    }
                    if (node.Next != null || node.Previous != null)
                    {
                        destination = node;
                        break;
                    }
                }

                for (var j = 2; j >= 0; j--)
                {
                    circle.AddAfter(destination, three[j]);
                }

                current = GetNext(current);
            }

            LinkedListNode<int> GetNext(LinkedListNode<int> node)
                => node.Next ?? circle.First;

            return (nodeLookup, circle.First);
        }

    }
}