namespace AdventOfCode2023.Day21;

using MoreLinq;
using Coord = (int X, int Y);

public static class Day21Solver
{
    public static long PuzzleOne(string input, int targetSteps = 64) => Solve(input, targetSteps);

    public static long PuzzleTwo(string input, int targetSteps = 26501365) => Solve(input, targetSteps);

    private static long Solve(string input, int targetSteps)
    {
        var lines = input.Split(Environment.NewLine);
        var maxLength = lines.Length;
        var map = new Dictionary<Coord, char>();
        Coord origin = default;

        for (var y = 0; y < maxLength; y++)
        {
            for (var x = 0; x < maxLength; x++)
            {
                var character = lines[y][x];
                var coord = (x, y);
                map[coord] = character;
                if (character == 'S')
                {
                    origin = coord;
                }
            }
        }

        var corners = new Coord[]
        {
            (0, 0),
            (maxLength - 1, 0),
            (maxLength - 1, maxLength - 1),
            (0, maxLength - 1),
        };

        var modifiers = new Coord[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };

        var centerScan = Scan(origin);
        var cornersScan = corners
            .Select((c, i) => Scan(corners[(i + 2 + corners.Length) % corners.Length]))
            .ToArray();

        var sum = 0L;
        sum += centerScan.Values.Count(x => x <= targetSteps && x % 2 == targetSteps % 2);
        sum += cornersScan
            .Select((scan, i) =>
            {
                var newTargetSteps = targetSteps - centerScan[corners[i]] - 2;
                if (newTargetSteps < 0)
                {
                    return 0L;
                }
                var quotient = newTargetSteps / maxLength;
                var remainder = newTargetSteps % maxLength;
                var summation = Summation(quotient);
                var evenSummation = Summation(quotient / 2) * 2;
                var oddSummation = summation - evenSummation;

                var innerSum = 0L;

                foreach (var value in scan.Values)
                {
                    if (targetSteps % 2 == newTargetSteps % 2)
                    {
                        if (value % 2 == newTargetSteps % 2)
                        {
                            innerSum += oddSummation;

                            if (value <= remainder && quotient % 2 == 0)
                            {
                                innerSum += quotient + 1;
                            }

                            if (value / maxLength == 1
                                && value % maxLength > remainder
                                && quotient % 2 == 1)
                            {
                                innerSum -= quotient;
                            }
                        }
                        else
                        {
                            innerSum += evenSummation;

                            if (value <= remainder && quotient % 2 == 1)
                            {
                                innerSum += quotient + 1;
                            }

                            if (value / maxLength == 1
                                && value % maxLength > remainder
                                && quotient % 2 == 0)
                            {
                                innerSum -= quotient;
                            }
                        }
                    }
                    else
                    {
                        if (value % 2 == newTargetSteps % 2)
                        {
                            innerSum += evenSummation;

                            if (value <= remainder && quotient % 2 == 1)
                            {
                                innerSum += quotient + 1;
                            }

                            if (value / maxLength == 1
                                && value % maxLength > remainder
                                && quotient % 2 == 0)
                            {
                                innerSum -= quotient;
                            }
                        }
                        else
                        {
                            innerSum += oddSummation;

                            if (value <= remainder && quotient % 2 == 0)
                            {
                                innerSum += quotient + 1;
                            }

                            if (value / maxLength == 1
                                && value % maxLength > remainder
                                && quotient % 2 == 1)
                            {
                                innerSum -= quotient;
                            }
                        }
                    }
                }

                return innerSum;
            })
            .Sum();

        var adjacentFactor = 5;
        var adjMin = -maxLength * (adjacentFactor - 1);
        var adjMax = maxLength * adjacentFactor;
        var adjacents = new ((int Min, int Max) X, (int Min, int Max) Y)[]
        {
            ((0, adjMax),(0, maxLength)),
            ((0, maxLength), (0, adjMax)),
            (( adjMin, maxLength),(0, maxLength)),
            ((0, maxLength), (adjMin, maxLength)),
        };
        var adjacentScan = AdjacentScan();
        var adjacentIndex = adjacentScan
            .Where(x => !centerScan.ContainsKey(x.Key))
            .Select(x => new
            {
                Coord = x.Key,
                MapCoord = (X: (x.Key.X + adjacentFactor * maxLength) % maxLength, Y: (x.Key.Y + adjacentFactor * maxLength) % maxLength),
                Index = adjacents
                    .Select((bounds, i) => new { Bounds = bounds, Index = i })
                    .First(adj => x.Key.X >= adj.Bounds.X.Min && x.Key.X < adj.Bounds.X.Max
                        && x.Key.Y >= adj.Bounds.Y.Min && x.Key.Y < adj.Bounds.Y.Max)
                    .Index
            })
            .GroupBy(x => x.Index)
            .OrderBy(x => x.Key)
            .Select(x => x
                .GroupBy(y => y.MapCoord, y => y.Coord)
                .ToDictionary(y => y.Key, y => y.ToList()))
            .ToList();

        sum += adjacents
            .Select((bounds, i) =>
            {
                var innerSum = 0L;
                foreach (var coord in centerScan.Keys)
                {
                    var scans = adjacentIndex[i][coord]
                        .Select(x => adjacentScan[x])
                        .OrderBy(x => x)
                        .ToArray();

                    var lag = scans.Lag(1, (cur, lag) => new
                    {
                        Current = cur,
                        Difference = cur - lag
                    }).ToList();

                    foreach (var l in lag)
                    {
                        if (l.Difference != maxLength)
                        {
                            if (l.Current > targetSteps)
                            {
                                break;
                            }
                            if (l.Current % 2 == targetSteps % 2)
                            {
                                innerSum++;
                            }
                        }
                        else
                        {
                            var newTargetSteps = targetSteps - l.Current;
                            if (newTargetSteps < 0)
                            {
                                break;
                            }
                            var quotient = newTargetSteps / maxLength;
                            innerSum += (quotient / 2) + 1;
                            if (quotient % 2 == 0 && l.Current % 2 != targetSteps % 2)
                            {
                                innerSum--;
                            }
                            break;
                        }
                    }
                }

                return innerSum;
            })
            .Sum();

        return sum;

        Dictionary<Coord, int> Scan(Coord start)
        {
            var dict = new Dictionary<Coord, int>();
            var queue = new Queue<(Coord Position, int Steps)>();
            queue.Enqueue((start, 0));

            while (queue.Any())
            {
                var (position, steps) = queue.Dequeue();
                if (dict.ContainsKey(position))
                {
                    continue;
                }
                dict.Add(position, steps);

                foreach (var modifier in modifiers)
                {
                    var newPosition = (position.X + modifier.X, position.Y + modifier.Y);
                    if (map.TryGetValue(newPosition, out var character) && character != '#')
                    {
                        queue.Enqueue((newPosition, steps + 1));
                    }
                }
            }

            return dict;
        }

        Dictionary<Coord, int> AdjacentScan()
        {
            var dict = new Dictionary<Coord, int>();
            var queue = new Queue<(Coord Position, int Steps)>();
            queue.Enqueue((origin, 0));

            while (queue.Any())
            {
                var (position, steps) = queue.Dequeue();
                if (dict.ContainsKey(position))
                {
                    continue;
                }
                dict.Add(position, steps);

                foreach (var modifier in modifiers)
                {
                    Coord newPosition = (position.X + modifier.X, position.Y + modifier.Y);
                    if (adjacents.All(adj => newPosition.X < adj.X.Min || newPosition.X >= adj.X.Max
                        || newPosition.Y < adj.Y.Min || newPosition.Y >= adj.Y.Max))
                    {
                        continue;
                    }
                    var mapPosition = ((newPosition.X + adjacentFactor * maxLength) % maxLength, (newPosition.Y + adjacentFactor * maxLength) % maxLength);
                    if (map.TryGetValue(mapPosition, out var character) && character != '#')
                    {
                        queue.Enqueue((newPosition, steps + 1));
                    }
                }
            }
            return dict;
        }

        long Summation(long n)
            => n * (n + 1) / 2;
    }
}