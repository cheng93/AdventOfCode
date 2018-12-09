namespace AdventOfCode2018.Day09
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day09ImprovedScorer : IDay09Scorer
    {
        public long GetHighestScore(int players, int length)
        {
            var scores = Enumerable.Range(0, players).ToDictionary(x => x, x => 0L);

            var tracker = new LinkedList<int>(new[] { 0 });
            var node = tracker.First;

            for (var i = 1; i <= length; i++)
            {
                if (i % 23 == 0)
                {
                    var removeNode = node;
                    for (var j = 0; j < 7; j++)
                    {
                        removeNode = removeNode.Previous == null
                            ? tracker.Last
                            : removeNode.Previous;
                    }

                    var player = i % players;
                    scores[player] = scores[player] + i + removeNode.Value;
                    node = removeNode.Next == null
                        ? tracker.First
                        : removeNode.Next;

                    tracker.Remove(removeNode);
                }
                else
                {
                    if (node.Next == tracker.Last)
                    {
                        node = tracker.AddLast(i);
                    }
                    else
                    {
                        var newNode = node.Next?.Next;
                        if (newNode == null)
                        {
                            node = tracker.AddAfter(tracker.First, i);
                        }
                        else
                        {
                            node = tracker.AddBefore(newNode, i);
                        }
                    }
                }
            }

            return scores.Values.Max();
        }
    }
}