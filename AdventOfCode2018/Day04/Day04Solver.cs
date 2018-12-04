using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Day04
{
    public class Day04Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var records = input
                .Select(x => new Day04Record(x))
                .OrderBy(x => x.Date)
                .ToList();

            var totalAsleep = new Dictionary<int, int>();
            var asleepBuckets = new Dictionary<int, Dictionary<int, int>>();

            var maxId = 0;
            var currentId = 0;
            var sleepStartTime = default(DateTime);

            foreach (var record in records)
            {
                if (record.IsBeginningShift)
                {
                    currentId = record.Id.Value;
                }
                else if (record.IsFallingAsleep)
                {
                    sleepStartTime = record.Date;
                }
                else if (record.IsWakingUp)
                {
                    var difference = record.Date.Subtract(sleepStartTime).Minutes;
                    if (totalAsleep.ContainsKey(currentId))
                    {
                        totalAsleep[currentId] = totalAsleep[currentId] + difference;
                    }
                    else
                    {
                        totalAsleep.Add(currentId, difference);
                        asleepBuckets.Add(currentId, new Dictionary<int, int>());
                    }

                    if (maxId == 0)
                    {
                        maxId = currentId;
                    }
                    else if (maxId != currentId)
                    {
                        if (totalAsleep[maxId] < totalAsleep[currentId])
                        {
                            maxId = currentId;
                        }
                    }

                    var bucket = asleepBuckets[currentId];
                    foreach (var minute in Enumerable.Range(sleepStartTime.Minute, difference))
                    {
                        if (bucket.ContainsKey(minute))
                        {
                            bucket[minute] = bucket[minute] + 1;
                        }
                        else
                        {
                            bucket.Add(minute, 1);
                        }
                    }
                }
            }

            var topBucket = asleepBuckets[maxId];
            var topMinute = topBucket.First(x => x.Value == topBucket.Values.Max()).Key;

            return maxId * topMinute;
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var records = input
                .Select(x => new Day04Record(x))
                .OrderBy(x => x.Date)
                .ToList();

            var asleepBuckets = new Dictionary<int, Dictionary<int, int>>();

            var currentId = 0;
            var sleepStartTime = default(DateTime);

            foreach (var record in records)
            {
                if (record.IsBeginningShift)
                {
                    currentId = record.Id.Value;
                }
                else if (record.IsFallingAsleep)
                {
                    sleepStartTime = record.Date;
                }
                else if (record.IsWakingUp)
                {
                    var difference = record.Date.Subtract(sleepStartTime).Minutes;
                    if (!asleepBuckets.ContainsKey(currentId))
                    {
                        asleepBuckets.Add(currentId, new Dictionary<int, int>());
                    }

                    var bucket = asleepBuckets[currentId];
                    foreach (var minute in Enumerable.Range(sleepStartTime.Minute, difference))
                    {
                        if (bucket.ContainsKey(minute))
                        {
                            bucket[minute] = bucket[minute] + 1;
                        }
                        else
                        {
                            bucket.Add(minute, 1);
                        }
                    }
                }
            }

            var top = asleepBuckets
                .Select(x => new
                {
                    Key = x.Key,
                    MinuteCount = new
                    {
                        Count = x.Value.Values.Max(),
                        Minute = x.Value.First(y => y.Value == x.Value.Values.Max()).Key
                    }
                })
                .OrderByDescending(x => x.MinuteCount.Count)
                .First();

            return top.Key * top.MinuteCount.Minute;
        }
    }
}