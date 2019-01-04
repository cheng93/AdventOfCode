namespace AdventOfCode2017.Day16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day16Solver
    {
        public string PuzzleOne(string input, int programs)
        {
            var danceMoves = input.Split(',');

            var positions = Enumerable.Range('a', programs).Select(x => (char)x);

            var linkedList = new LinkedList<char>();

            foreach (var position in positions)
            {
                linkedList.AddLast(position);
            }

            foreach (var move in danceMoves)
            {
                var splits = move.Split('/');
                var type = splits[0][0];

                switch (type)
                {
                    case 's':
                        Spin(splits, linkedList);
                        break;
                    case 'x':
                        Exchange(splits, linkedList);
                        break;
                    case 'p':
                        Partner(splits, linkedList);
                        break;
                }
            }

            return string.Join("", linkedList);
        }
        public string PuzzleTwo(string input, int programs)
        {
            var danceMoves = input.Split(',');

            var positions = Enumerable.Range('a', programs).Select(x => (char)x);

            var linkedList = new LinkedList<char>();

            foreach (var position in positions)
            {
                linkedList.AddLast(position);
            }

            var seen = new Dictionary<string, int>();
            var iterationSize = 0;
            var offset = 0;

            for (var i = 0; i < 1000000000; i++)
            {
                var positionString = string.Join("", linkedList);
                if (!seen.ContainsKey(positionString))
                {
                    seen.Add(positionString, i);
                }
                else
                {
                    iterationSize = i - seen[positionString];
                    offset = seen[positionString];
                    break;
                }
                Dance(danceMoves, linkedList);
            }

            var remainder = (1000000000 - offset) % iterationSize;

            for (var i = 0; i < remainder; i++)
            {
                Dance(danceMoves, linkedList);
            }

            return string.Join("", linkedList);
        }

        private static void Dance(string[] danceMoves, LinkedList<char> linkedList)
        {
            foreach (var move in danceMoves)
            {
                var splits = move.Split('/');
                var type = splits[0][0];

                switch (type)
                {
                    case 's':
                        Spin(splits, linkedList);
                        break;
                    case 'x':
                        Exchange(splits, linkedList);
                        break;
                    case 'p':
                        Partner(splits, linkedList);
                        break;
                }
            }
        }

        private static void Spin(string[] splits, LinkedList<char> linkedList)
        {
            var count = int.Parse(splits[0].Substring(1));
            var queue = new Queue<LinkedListNode<char>>();
            for (var i = 0; i < count; i++)
            {
                var last = linkedList.Last;
                queue.Enqueue(last);
                linkedList.Remove(last);
            }
            while (queue.Any())
            {
                var node = queue.Dequeue();
                linkedList.AddFirst(node);
            }
        }

        private static void Exchange(string[] splits, LinkedList<char> linkedList)
        {
            var left = int.Parse(splits[0].Substring(1));
            var right = int.Parse(splits[1]);

            if (left > right)
            {
                var oldLeft = left;
                left = right;
                right = oldLeft;
            }

            var current = linkedList.First;
            var leftNode = current;
            var rightNode = current;
            for (var i = 0; i <= right; i++)
            {
                if (i == left)
                {
                    leftNode = current;
                }
                else if (i == right)
                {
                    rightNode = current;
                }

                current = current.Next;
            }

            Swap(linkedList, leftNode, rightNode);
        }

        private static void Partner(string[] splits, LinkedList<char> linkedList)
        {
            var left = splits[0].Substring(1)[0];
            var right = splits[1][0];

            var found = false;
            var current = linkedList.First;
            var leftNode = current;
            var rightNode = current;

            while (true)
            {
                if (current.Value == left || current.Value == right)
                {
                    if (!found)
                    {
                        leftNode = current;
                        found = true;
                    }
                    else
                    {
                        rightNode = current;
                        break;
                    }
                }

                current = current.Next;
            }

            Swap(linkedList, leftNode, rightNode);
        }

        private static void Swap(LinkedList<char> linkedList, LinkedListNode<char> leftNode, LinkedListNode<char> rightNode)
        {
            var leftPrevious = leftNode.Previous;
            var rightNext = rightNode.Next;

            linkedList.Remove(leftNode);
            linkedList.Remove(rightNode);

            if (leftPrevious == null)
            {
                linkedList.AddFirst(rightNode);
            }
            else
            {
                linkedList.AddAfter(leftPrevious, rightNode);
            }

            if (rightNext == null)
            {
                linkedList.AddLast(leftNode);
            }
            else
            {
                linkedList.AddBefore(rightNext, leftNode);
            }
        }
    }
}