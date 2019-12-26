using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2019.Day22
{
    public class Day22Solver
    {
        public IEnumerable<int> PuzzleOne(IEnumerable<string> input, int size = 10007)
        {
            var cards = Enumerable.Range(0, size).ToList();
            foreach (var technique in input)
            {
                if (technique.Contains("stack"))
                {
                    cards.Reverse();
                }
                else if (technique.Contains("cut"))
                {
                    var cut = int.Parse(technique[4..]);
                    if (cut > 0)
                    {
                        cards = cards.Concat(cards.Take(cut)).Skip(cut).ToList();
                    }
                    else
                    {
                        cards = cards.TakeLast(-cut).Concat(cards).Take(size).ToList();
                    }
                }
                else if (technique.Contains("increment"))
                {
                    var increment = int.Parse(technique["deal with increment ".Length..]);
                    var clone = new List<int>(cards);

                    for (var i = 0; i < clone.Count; i++)
                    {
                        cards[(i * increment) % size] = clone[i];
                    }
                }
            }

            return cards;
        }

        public long PuzzleTwo(IEnumerable<string> input)
        {
            var inputList = input.ToList();
            var hasChanged = false;
            var cards = 119315717514047;

            do
            {
                hasChanged = false;
                var queue = new Queue<string>(inputList);
                var sortedList = new List<string>();
                var current = queue.Dequeue();

                while (queue.Any())
                {
                    var next = queue.Dequeue();
                    if (current.Contains("increment"))
                    {
                        var currentIncrement = long.Parse(current["deal with increment ".Length..]);
                        if (next.Contains("increment"))
                        {
                            hasChanged = true;
                            var nextIncrement = long.Parse(next["deal with increment ".Length..]);
                            current = $"deal with increment {ModBig(new BigInteger(currentIncrement) * new BigInteger(nextIncrement), new BigInteger(cards))}";
                        }
                        else
                        {
                            sortedList.Add(current);
                            current = next;
                        }
                    }
                    else if (current.Contains("cut"))
                    {
                        var currentCut = long.Parse(current[4..]);
                        if (next.Contains("cut"))
                        {
                            hasChanged = true;
                            var nextCut = long.Parse(next[4..]);
                            current = $"cut {Mod(currentCut + nextCut, cards)}";
                        }
                        else if (next.Contains("increment"))
                        {
                            hasChanged = true;
                            var nextIncrement = long.Parse(next["deal with increment ".Length..]);
                            sortedList.Add($"deal with increment {nextIncrement}");
                            current = $"cut {ModBig(new BigInteger(currentCut) * new BigInteger(nextIncrement), new BigInteger(cards))}";
                        }
                        else
                        {
                            sortedList.Add(current);
                            current = next;
                        }
                    }
                    else if (current.Contains("stack"))
                    {
                        if (next.Contains("stack"))
                        {
                            hasChanged = true;
                            current = sortedList.Last();
                            sortedList.RemoveAt(sortedList.Count - 1);
                        }
                        else if (next.Contains("increment"))
                        {
                            hasChanged = true;
                            var nextIncrement = long.Parse(next["deal with increment ".Length..]);
                            sortedList.Add($"deal with increment {Mod(cards - nextIncrement, cards)}");
                            current = $"cut {nextIncrement}";
                        }
                        else if (next.Contains("cut"))
                        {
                            hasChanged = true;
                            var nextCut = long.Parse(next[4..]);
                            sortedList.Add($"cut {Mod(cards - 1 - nextCut, cards)}");
                            current = $"deal with increment {cards - 1}";
                        }
                    }
                }
                sortedList.Add(current);
                inputList = sortedList;
            }
            while (hasChanged);

            var increment = long.Parse(inputList[0]["deal with increment ".Length..]);
            var cut = long.Parse(inputList[1][4..]);
            var position = 2020L;
            var iterations = 101741582076661;

            return (long)Reversal(position);

            long Mod(long x, long y) => ((x % y) + y) % y;

            BigInteger ModBig(BigInteger x, BigInteger y) => ((x % y) + y) % y;

            BigInteger Reversal(long x)
            {
                var l = new BigInteger(cards);
                var i = Inverse(new BigInteger(increment), l);
                var c = new BigInteger(cut);
                var n = new BigInteger(iterations);
                var y = new BigInteger(x);
                var inv = Inverse(i - 1, l);

                var iToN = BigInteger.ModPow(i, n, l);

                var u = ModBig(iToN * y, l);
                var v = ModBig(c * (iToN * i - 1) * inv, l);

                return ModBig(u + v - c, l);

                BigInteger Inverse(BigInteger k, BigInteger m)
                {
                    return BigInteger.ModPow(k, m - 2, m);
                }
            }
        }
    }
}