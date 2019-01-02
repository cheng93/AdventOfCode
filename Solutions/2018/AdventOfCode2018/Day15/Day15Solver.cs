namespace AdventOfCode2018.Day15
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day15Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var pointComparer = new Day15PointComparer();

            var map = new Dictionary<Point, char>();
            var elves = new List<Day15Unit>();
            var goblins = new List<Day15Unit>();
            var units = new SortedList<Point, Day15Unit>(pointComparer);

            var shortestPathsAlgorithm = new Day15ShortestPaths();

            for (var i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];
                for (var j = 0; j < currentLine.Length; j++)
                {
                    var currentPoint = new Point(j, i);
                    map[currentPoint] = currentLine[j];

                    if (currentLine[j] == 'G')
                    {
                        var unit = new Day15Unit(currentPoint, currentLine[j]);
                        units.Add(unit.Position, unit);
                        goblins.Add(unit);
                    }
                    else if (currentLine[j] == 'E')
                    {
                        var unit = new Day15Unit(currentPoint, currentLine[j]);
                        units.Add(unit.Position, unit);
                        elves.Add(unit);
                    }
                }
            }

            var rounds = 0;

            while (elves.Any() && goblins.Any())
            {
                var deadUnitPoints = new HashSet<Point>();
                foreach (var unit in units.Values.ToList())
                {
                    if (deadUnitPoints.Contains(unit.Position))
                    {
                        continue;
                    }

                    var enemies = unit.Icon == 'E' ? goblins : elves;
                    if (!enemies.Any())
                    {
                        return rounds * Math.Max(1, elves.Sum(x => x.HitPoints)) * Math.Max(1, goblins.Sum(x => x.HitPoints));
                    }

                    if (!IsNextToEnemy(map, unit.Position))
                    {
                        var inRangePoints = new List<Point>();
                        foreach (var enemy in enemies)
                        {
                            foreach (var i in new[] { -1, 1 })
                            {
                                foreach (var size in new[] { new Size(i, 0), new Size(0, i) })
                                {
                                    var adjacentPoint = Point.Add(enemy.Position, size);
                                    if (map.ContainsKey(adjacentPoint) && map[adjacentPoint] == '.')
                                    {
                                        inRangePoints.Add(adjacentPoint);
                                    }
                                }
                            }
                        }

                        ICollection<Point> path = null;
                        foreach (var point in inRangePoints)
                        {
                            var shortestPaths = shortestPathsAlgorithm.Get(map, unit.Position, point);
                            if (shortestPaths.Any())
                            {
                                foreach (var shortestPath in shortestPaths)
                                {
                                    if (path == null || shortestPath.Count < path.Count)
                                    {
                                        path = shortestPath;
                                    }
                                    else if (shortestPath.Count == path.Count)
                                    {
                                        if (pointComparer.Compare(point, path.Last()) < 0)
                                        {
                                            path = shortestPath;
                                        }
                                        else if (point == path.Last()
                                            && pointComparer.Compare(shortestPath.First(), path.First()) < 0)
                                        {
                                            path = shortestPath;
                                        }
                                    }
                                }
                            }
                        }

                        if (path != null)
                        {
                            var destination = path.First();
                            map[unit.Position] = '.';
                            units.Remove(unit.Position);
                            unit.Position = destination;
                            map[unit.Position] = unit.Icon;
                            units.Add(unit.Position, unit);
                        }
                    }

                    if (IsNextToEnemy(map, unit.Position))
                    {
                        Day15Unit targetEnemy = null;

                        foreach (var enemy in enemies)
                        {
                            if ((unit.Position.X - enemy.Position.X == 0
                                && Math.Abs(unit.Position.Y - enemy.Position.Y) == 1)
                                || (Math.Abs(unit.Position.X - enemy.Position.X) == 1
                                    && unit.Position.Y - enemy.Position.Y == 0))
                            {
                                if (targetEnemy == null
                                    || enemy.HitPoints < targetEnemy.HitPoints)
                                {
                                    targetEnemy = enemy;
                                }
                                else if (enemy.HitPoints == targetEnemy.HitPoints
                                    && pointComparer.Compare(enemy.Position, targetEnemy.Position) < 0)
                                {
                                    targetEnemy = enemy;
                                }
                            }
                        }

                        targetEnemy.HitPoints -= unit.AttackPower;

                        if (targetEnemy.HitPoints <= 0)
                        {
                            deadUnitPoints.Add(targetEnemy.Position);
                            enemies.Remove(targetEnemy);
                            units.Remove(targetEnemy.Position);
                            map[targetEnemy.Position] = '.';
                        }
                    }
                }
                rounds++;
            }

            return rounds * Math.Max(1, elves.Sum(x => x.HitPoints)) * Math.Max(1, goblins.Sum(x => x.HitPoints));
        }

        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var pointComparer = new Day15PointComparer();

            var shortestPathsAlgorithm = new Day15ShortestPaths();

            var attackPower = 3;

            while (true)
            {
                attackPower++;
                var map = new Dictionary<Point, char>();
                var elves = new List<Day15Unit>();
                var goblins = new List<Day15Unit>();
                var units = new SortedList<Point, Day15Unit>(pointComparer);

                for (var i = 0; i < lines.Length; i++)
                {
                    var currentLine = lines[i];
                    for (var j = 0; j < currentLine.Length; j++)
                    {
                        var currentPoint = new Point(j, i);
                        map[currentPoint] = currentLine[j];

                        if (currentLine[j] == 'G')
                        {
                            var unit = new Day15Unit(currentPoint, currentLine[j]);
                            units.Add(unit.Position, unit);
                            goblins.Add(unit);
                        }
                        else if (currentLine[j] == 'E')
                        {
                            var unit = new Day15Unit(currentPoint, currentLine[j])
                            {
                                AttackPower = attackPower
                            };
                            units.Add(unit.Position, unit);
                            elves.Add(unit);
                        }
                    }
                }

                var rounds = 0;
                var hasDeadElf = false;

                while (elves.Any() && goblins.Any())
                {
                    if (hasDeadElf)
                    {
                        break;
                    }
                    var deadUnitPoints = new HashSet<Point>();
                    foreach (var unit in units.Values.ToList())
                    {
                        if (deadUnitPoints.Contains(unit.Position))
                        {
                            continue;
                        }

                        var enemies = unit.Icon == 'E' ? goblins : elves;
                        if (!enemies.Any())
                        {
                            return rounds * Math.Max(1, elves.Sum(x => x.HitPoints)) * Math.Max(1, goblins.Sum(x => x.HitPoints));
                        }

                        if (!IsNextToEnemy(map, unit.Position))
                        {
                            var inRangePoints = new List<Point>();
                            foreach (var enemy in enemies)
                            {
                                foreach (var i in new[] { -1, 1 })
                                {
                                    foreach (var size in new[] { new Size(i, 0), new Size(0, i) })
                                    {
                                        var adjacentPoint = Point.Add(enemy.Position, size);
                                        if (map.ContainsKey(adjacentPoint) && map[adjacentPoint] == '.')
                                        {
                                            inRangePoints.Add(adjacentPoint);
                                        }
                                    }
                                }
                            }

                            ICollection<Point> path = null;
                            foreach (var point in inRangePoints)
                            {
                                var shortestPaths = shortestPathsAlgorithm.Get(map, unit.Position, point);
                                if (shortestPaths.Any())
                                {
                                    foreach (var shortestPath in shortestPaths)
                                    {
                                        if (path == null || shortestPath.Count < path.Count)
                                        {
                                            path = shortestPath;
                                        }
                                        else if (shortestPath.Count == path.Count)
                                        {
                                            if (pointComparer.Compare(point, path.Last()) < 0)
                                            {
                                                path = shortestPath;
                                            }
                                            else if (point == path.Last()
                                                && pointComparer.Compare(shortestPath.First(), path.First()) < 0)
                                            {
                                                path = shortestPath;
                                            }
                                        }
                                    }
                                }
                            }

                            if (path != null)
                            {
                                var destination = path.First();
                                map[unit.Position] = '.';
                                units.Remove(unit.Position);
                                unit.Position = destination;
                                map[unit.Position] = unit.Icon;
                                units.Add(unit.Position, unit);
                            }
                        }

                        if (IsNextToEnemy(map, unit.Position))
                        {
                            Day15Unit targetEnemy = null;

                            foreach (var enemy in enemies)
                            {
                                if ((unit.Position.X - enemy.Position.X == 0
                                    && Math.Abs(unit.Position.Y - enemy.Position.Y) == 1)
                                    || (Math.Abs(unit.Position.X - enemy.Position.X) == 1
                                        && unit.Position.Y - enemy.Position.Y == 0))
                                {
                                    if (targetEnemy == null
                                        || enemy.HitPoints < targetEnemy.HitPoints)
                                    {
                                        targetEnemy = enemy;
                                    }
                                    else if (enemy.HitPoints == targetEnemy.HitPoints
                                        && pointComparer.Compare(enemy.Position, targetEnemy.Position) < 0)
                                    {
                                        targetEnemy = enemy;
                                    }
                                }
                            }

                            targetEnemy.HitPoints -= unit.AttackPower;

                            if (targetEnemy.HitPoints <= 0)
                            {
                                deadUnitPoints.Add(targetEnemy.Position);
                                enemies.Remove(targetEnemy);
                                units.Remove(targetEnemy.Position);
                                map[targetEnemy.Position] = '.';
                                if (targetEnemy.Icon == 'E')
                                {
                                    hasDeadElf = true;
                                    break;
                                }
                            }
                        }
                    }
                    rounds++;
                }

                if (!hasDeadElf)
                {
                    return rounds * Math.Max(1, elves.Sum(x => x.HitPoints)) * Math.Max(1, goblins.Sum(x => x.HitPoints));
                }
            }
        }

        private static bool IsNextToEnemy(Dictionary<Point, char> map, Point point)
        {
            var unit = map[point];
            foreach (var i in new[] { -1, 1 })
            {
                foreach (var size in new[] { new Size(i, 0), new Size(0, i) })
                {
                    var adjacentPoint = Point.Add(point, size);
                    if (!map.ContainsKey(adjacentPoint))
                    {
                        continue;
                    }
                    var mapItem = map[adjacentPoint];
                    if ((unit == 'E' && mapItem == 'G')
                        || (unit == 'G' && mapItem == 'E'))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}