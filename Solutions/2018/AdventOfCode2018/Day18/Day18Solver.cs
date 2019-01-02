namespace AdventOfCode2018.Day18
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day18Solver
    {
        public int PuzzleOne(string input, int areaSize)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var trees = new HashSet<Point>();
            var lumberyards = new HashSet<Point>();
            var opens = new HashSet<Point>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var point = new Point(j, i);

                    if (line[j] == '|')
                    {
                        trees.Add(point);
                    }
                    else if (line[j] == '#')
                    {
                        lumberyards.Add(point);
                    }
                    else
                    {
                        opens.Add(point);
                    }
                }
            }

            var minutes = 0;

            while (minutes < 10)
            {
                var copyOpens = opens.ToList();
                var copyTrees = trees.ToList();
                var copyLumberyards = lumberyards.ToList();

                foreach (var open in copyOpens)
                {
                    var surroundingTrees = 0;
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var size = new Size(i, j);
                            var point = Point.Add(open, size);
                            if (PointWithinArea(point, areaSize) && copyTrees.Contains(point))
                            {
                                surroundingTrees++;
                            }
                        }
                    }
                    if (surroundingTrees >= 3)
                    {
                        trees.Add(open);
                        opens.Remove(open);
                    }
                }

                foreach (var tree in copyTrees)
                {
                    var surroundingLumberyards = 0;
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var size = new Size(i, j);
                            var point = Point.Add(tree, size);
                            if (PointWithinArea(point, areaSize) && copyLumberyards.Contains(point))
                            {
                                surroundingLumberyards++;
                            }
                        }
                    }
                    if (surroundingLumberyards >= 3)
                    {
                        lumberyards.Add(tree);
                        trees.Remove(tree);
                    }
                }

                foreach (var lumberyard in copyLumberyards)
                {
                    var surroundingLumberyards = 0;
                    var surroundingTrees = 0;
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var size = new Size(i, j);
                            var point = Point.Add(lumberyard, size);
                            if (PointWithinArea(point, areaSize))
                            {
                                if (copyLumberyards.Contains(point))
                                {
                                    surroundingLumberyards++;
                                }
                                else if (copyTrees.Contains(point))
                                {
                                    surroundingTrees++;
                                }
                            }
                        }
                    }
                    if (surroundingLumberyards == 0 || surroundingTrees == 0)
                    {
                        opens.Add(lumberyard);
                        lumberyards.Remove(lumberyard);
                    }
                }
                minutes++;
            }

            return trees.Count * lumberyards.Count;
        }

        public int PuzzleTwo(string input, int areaSize)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var trees = new HashSet<Point>();
            var lumberyards = new HashSet<Point>();
            var opens = new HashSet<Point>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var point = new Point(j, i);

                    if (line[j] == '|')
                    {
                        trees.Add(point);
                    }
                    else if (line[j] == '#')
                    {
                        lumberyards.Add(point);
                    }
                    else
                    {
                        opens.Add(point);
                    }
                }
            }

            var minutes = 0;
            var history = new Dictionary<(int Trees, int Lumberyards), int>()
            {
                {(trees.Count, lumberyards.Count), 0}
            };
            var treeHistory = new List<HashSet<Point>>(new[] { new HashSet<Point>(trees) });
            var lumberyardHistory = new List<HashSet<Point>>(new[] { new HashSet<Point>(lumberyards) });

            var modulo = (int?)null;
            var targetModulo = (int?)null;
            var start = (int?)null;

            while (true)
            {
                var copyOpens = opens.ToList();
                var copyTrees = trees.ToList();
                var copyLumberyards = lumberyards.ToList();

                foreach (var open in copyOpens)
                {
                    var surroundingTrees = 0;
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var size = new Size(i, j);
                            var point = Point.Add(open, size);
                            if (PointWithinArea(point, areaSize) && copyTrees.Contains(point))
                            {
                                surroundingTrees++;
                            }
                        }
                    }
                    if (surroundingTrees >= 3)
                    {
                        trees.Add(open);
                        opens.Remove(open);
                    }
                }

                foreach (var tree in copyTrees)
                {
                    var surroundingLumberyards = 0;
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var size = new Size(i, j);
                            var point = Point.Add(tree, size);
                            if (PointWithinArea(point, areaSize) && copyLumberyards.Contains(point))
                            {
                                surroundingLumberyards++;
                            }
                        }
                    }
                    if (surroundingLumberyards >= 3)
                    {
                        lumberyards.Add(tree);
                        trees.Remove(tree);
                    }
                }

                foreach (var lumberyard in copyLumberyards)
                {
                    var surroundingLumberyards = 0;
                    var surroundingTrees = 0;
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var size = new Size(i, j);
                            var point = Point.Add(lumberyard, size);
                            if (PointWithinArea(point, areaSize))
                            {
                                if (copyLumberyards.Contains(point))
                                {
                                    surroundingLumberyards++;
                                }
                                else if (copyTrees.Contains(point))
                                {
                                    surroundingTrees++;
                                }
                            }
                        }
                    }
                    if (surroundingLumberyards == 0 || surroundingTrees == 0)
                    {
                        opens.Add(lumberyard);
                        lumberyards.Remove(lumberyard);
                    }
                }
                minutes++;

                var historyKey = (trees.Count, lumberyards.Count);

                if (history.ContainsKey(historyKey)
                    && lumberyardHistory[history[historyKey]].SetEquals(lumberyards)
                    && treeHistory[history[historyKey]].SetEquals(trees))
                {
                    if (!modulo.HasValue)
                    {
                        start = history[historyKey];
                        modulo = minutes - history[historyKey];
                        targetModulo = (1000000000 - start) % modulo;
                    }
                    if ((minutes - start) % modulo == targetModulo)
                    {
                        return trees.Count * lumberyards.Count;
                    }
                }
                else
                {
                    history[historyKey] = minutes;
                    treeHistory.Add(new HashSet<Point>(trees));
                    lumberyardHistory.Add(new HashSet<Point>(lumberyards));
                }
            }
        }

        private static bool PointWithinArea(Point point, int areaSize)
            => point.X >= 0 && point.X < areaSize
                && point.Y >= 0 && point.Y < areaSize;
    }
}