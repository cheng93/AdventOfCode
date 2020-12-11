using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day11
{
    public class Day11Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var layout = new Dictionary<(int X, int Y), char>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    layout[(j, i)] = line[j];
                }
            }

            var changed = false;
            do
            {
                changed = false;
                var newLayout = new Dictionary<(int X, int Y), char>();
                foreach (var position in layout.Keys)
                {
                    var seat = layout[position];
                    if (seat == '.')
                    {
                        newLayout[position] = seat;
                        continue;
                    }

                    var adjacentSeats = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var adjacentPosition = (position.X + j, position.Y + i);
                            if (layout.TryGetValue(adjacentPosition, out var adjacentSeat)
                                && adjacentSeat == '#')
                            {
                                adjacentSeats++;
                            }
                        }
                    }

                    if (seat == 'L' && adjacentSeats == 0)
                    {
                        changed = true;
                        newLayout[position] = '#';
                    }
                    else if (seat == '#' && adjacentSeats >= 4)
                    {
                        changed = true;
                        newLayout[position] = 'L';
                    }
                    else
                    {
                        newLayout[position] = seat;
                    }
                }

                layout = newLayout;
            }
            while (changed);

            return layout.Values.Count(x => x == '#');
        }

        public int PuzzleTwo(string input)
        {
            var lines = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var layout = new Dictionary<(int X, int Y), char>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    layout[(j, i)] = line[j];
                }
            }

            var changed = false;
            do
            {
                changed = false;
                var newLayout = new Dictionary<(int X, int Y), char>();
                foreach (var position in layout.Keys)
                {
                    var seat = layout[position];
                    if (seat == '.')
                    {
                        newLayout[position] = seat;
                        continue;
                    }

                    var adjacentSeats = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            var factor = 1;
                            while (true)
                            {
                                var adjacentPosition = (position.X + j * factor, position.Y + i * factor);
                                if (!layout.TryGetValue(adjacentPosition, out var adjacentSeat)
                                    || adjacentSeat == 'L')
                                {
                                    break;
                                }
                                if (adjacentSeat == '#')
                                {
                                    adjacentSeats++;
                                    break;
                                }
                                factor++;
                            }
                        }
                    }

                    if (seat == 'L' && adjacentSeats == 0)
                    {
                        changed = true;
                        newLayout[position] = '#';
                    }
                    else if (seat == '#' && adjacentSeats >= 5)
                    {
                        changed = true;
                        newLayout[position] = 'L';
                    }
                    else
                    {
                        newLayout[position] = seat;
                    }
                }

                layout = newLayout;
            }
            while (changed);

            return layout.Values.Count(x => x == '#');
        }
    }
}