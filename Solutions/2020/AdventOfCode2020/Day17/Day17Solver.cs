using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day17
{
    public class Day17Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(Environment.NewLine).ToArray();

            var active = new HashSet<(int X, int Y, int Z)>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var cube = line[j];
                    if (cube == '#')
                    {
                        active.Add((j, i, 0));
                    }
                }
            }

            for (var i = 0; i < 6; i++)
            {
                var newActive = new HashSet<(int X, int Y, int Z)>();
                var minX = active.Select(x => x.X).Min() - 1;
                var maxX = active.Select(x => x.X).Max() + 1;
                var minY = active.Select(x => x.Y).Min() - 1;
                var maxY = active.Select(x => x.Y).Max() + 1;
                var minZ = active.Select(x => x.Z).Min() - 1;
                var maxZ = active.Select(x => x.Z).Max() + 1;

                for (var a = minX; a <= maxX; a++)
                {
                    for (var b = minY; b <= maxY; b++)
                    {
                        for (var c = minZ; c <= maxZ; c++)
                        {
                            var cube = (X: a, Y: b, Z: c);
                            var activeNeighbours = 0;
                            for (var x = -1; x <= 1; x++)
                            {
                                for (var y = -1; y <= 1; y++)
                                {
                                    for (var z = -1; z <= 1; z++)
                                    {
                                        if (x == y && y == z && x == 0)
                                        {
                                            continue;
                                        }

                                        var neighbour = (cube.X + x, cube.Y + y, cube.Z + z);
                                        if (active.Contains(neighbour))
                                        {
                                            activeNeighbours++;
                                        }
                                    }
                                }
                            }

                            if (activeNeighbours == 3 || (active.Contains(cube) && activeNeighbours == 2))
                            {
                                newActive.Add(cube);
                            }
                        }
                    }
                }

                active = newActive;
            }

            return active.Count;
        }

        public int PuzzleTwo(string input)
        {
            var lines = input.Split(Environment.NewLine).ToArray();

            var active = new HashSet<(int X, int Y, int Z, int W)>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var cube = line[j];
                    if (cube == '#')
                    {
                        active.Add((j, i, 0, 0));
                    }
                }
            }

            for (var i = 0; i < 6; i++)
            {
                var newActive = new HashSet<(int X, int Y, int Z, int W)>();
                var minX = active.Select(x => x.X).Min() - 1;
                var maxX = active.Select(x => x.X).Max() + 1;
                var minY = active.Select(x => x.Y).Min() - 1;
                var maxY = active.Select(x => x.Y).Max() + 1;
                var minZ = active.Select(x => x.Z).Min() - 1;
                var maxZ = active.Select(x => x.Z).Max() + 1;
                var minW = active.Select(x => x.W).Min() - 1;
                var maxW = active.Select(x => x.W).Max() + 1;

                var region = new HashSet<(int X, int Y, int Z, int W)>();
                for (var a = minX; a <= maxX; a++)
                {
                    for (var b = minY; b <= maxY; b++)
                    {
                        for (var c = minZ; c <= maxZ; c++)
                        {
                            for (var d = minW; d <= maxW; d++)
                            {
                                var cube = (X: a, Y: b, Z: c, W: d);
                                var activeNeighbours = 0;
                                for (var x = -1; x <= 1; x++)
                                {
                                    for (var y = -1; y <= 1; y++)
                                    {
                                        for (var z = -1; z <= 1; z++)
                                        {
                                            for (var w = -1; w <= 1; w++)
                                            {
                                                if (x == y && y == z && z == w && x == 0)
                                                {
                                                    continue;
                                                }

                                                var neighbour = (cube.X + x, cube.Y + y, cube.Z + z, cube.W + w);
                                                if (active.Contains(neighbour))
                                                {
                                                    activeNeighbours++;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (activeNeighbours == 3 || (active.Contains(cube) && activeNeighbours == 2))
                                {
                                    newActive.Add(cube);
                                }
                            }
                        }
                    }
                }

                active = newActive;
            }

            return active.Count;
        }
    }
}