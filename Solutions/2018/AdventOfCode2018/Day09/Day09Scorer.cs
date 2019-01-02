namespace AdventOfCode2018.Day09
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day09Scorer : IDay09Scorer
    {
        public long GetHighestScore(int players, int length)
        {
            var scores = Enumerable.Range(0, players).ToDictionary(x => x, x => 0);

            var tracker = new List<int>() { 0 };
            var index = 0;

            for (var i = 1; i <= length; i++)
            {
                if (i % 23 == 0)
                {
                    var removeIndex = index - 7;
                    if (removeIndex < 0)
                    {
                        removeIndex += tracker.Count;
                    }

                    var player = i % players;
                    scores[player] = scores[player] + i + tracker[removeIndex];
                    tracker.RemoveAt(removeIndex);
                    index = removeIndex;
                }
                else
                {
                    var newIndex = index + 2;
                    if (newIndex % tracker.Count == 0)
                    {
                        tracker.Add(i);
                        index = tracker.Count - 1;
                    }
                    else
                    {
                        newIndex = newIndex % tracker.Count;
                        tracker.Insert(newIndex, i);
                        index = newIndex;
                    }
                }
            }

            return scores.Values.Max();
        }
    }
}