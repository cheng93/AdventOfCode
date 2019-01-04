namespace AdventOfCode2017.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day14KnotHashAlgorithm
    {
        public string Convert(string input)
        {
            var list = Enumerable.Range(0, 256);
            var linkedList = new LinkedList<int>();
            var lengths = Encoding.ASCII.GetBytes(input).ToList();
            var sequence = "17,31,73,47,23";
            lengths.AddRange(sequence.Split(',').Select(byte.Parse));

            foreach (var number in list)
            {
                linkedList.AddLast(number);
            }

            var skip = 0;
            var current = linkedList.First;

            for (var n = 0; n < 64; n++)
            {
                foreach (var length in lengths)
                {
                    var stack = new Stack<LinkedListNode<int>>();

                    var start = current.Previous;
                    var looped = false;
                    var countBeforeLast = 0;
                    var countAfterFirst = 0;

                    for (var i = 0; i < length; i++)
                    {
                        stack.Push(current);
                        var remove = current;
                        if (!looped)
                        {
                            countBeforeLast++;
                            if (current.Next == null)
                            {
                                looped = true;
                                current = linkedList.First;
                            }
                            else
                            {
                                current = current.Next;
                            }
                        }
                        else
                        {
                            countAfterFirst++;
                            current = current.Next;
                        }
                        linkedList.Remove(remove);
                    }

                    if (length > 0)
                    {
                        var last = current;
                        current = stack.Peek();
                        for (var i = 0; i < countBeforeLast; i++)
                        {
                            var node = stack.Pop();
                            if (start == null)
                            {
                                linkedList.AddFirst(node);
                            }
                            else if (linkedList.Count == 0)
                            {
                                linkedList.AddFirst(node);
                                last = linkedList.First;
                            }
                            else
                            {
                                linkedList.AddAfter(start, node);
                            }
                            start = node;
                        }
                        for (var i = 0; i < countAfterFirst; i++)
                        {
                            var node = stack.Pop();
                            linkedList.AddBefore(last, node);
                        }
                    }

                    for (var i = 0; i < length + skip; i++)
                    {
                        current = current.Next == null ? linkedList.First : current.Next;
                    }

                    skip++;
                }
            }

            var sparseHash = new List<int>();
            var sparesElements = new List<int>();
            var sparseNode = linkedList.First;

            for (var n = 0; n < linkedList.Count; n++)
            {
                sparesElements.Add(sparseNode.Value);
                sparseNode = sparseNode.Next;
                if (n % 16 == 15)
                {
                    sparseHash.Add(sparesElements.Aggregate((x, y) => x ^ y));
                    sparesElements = new List<int>();
                }
            }

            return BitConverter.ToString(sparseHash.Select(x => (byte)x).ToArray()).Replace("-", string.Empty).ToLower();
        }
    }
}