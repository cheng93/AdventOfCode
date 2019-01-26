namespace AdventOfCode2016.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day04Solver
    {
        public int PuzzleOne(string input)
        {
            var rooms = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day04Room(x));

            var sum = 0;

            foreach (var room in rooms)
            {
                var topFive = room.Name.Replace("-", "")
                    .GroupBy(x => x)
                    .OrderByDescending(x => x.Count())
                    .ThenBy(x => (int)x.Key)
                    .Take(5)
                    .Select(x => x.Key.ToString());

                var checksum = string.Join("", topFive);
                if (checksum == room.Checksum)
                {
                    sum += room.SectorId;
                }
            }

            return sum;
        }

        public IEnumerable<string> PuzzleTwo(string input)
        {
            var rooms = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day04Room(x));

            foreach (var room in rooms)
            {
                var topFive = room.Name.Replace("-", "")
                    .GroupBy(x => x)
                    .OrderByDescending(x => x.Count())
                    .ThenBy(x => (int)x.Key)
                    .Take(5)
                    .Select(x => x.Key.ToString());

                var checksum = string.Join("", topFive);
                if (checksum == room.Checksum)
                {
                    var letters = room.Name
                        .Select(x =>
                        {
                            return x == '-'
                                ? ' '
                                : (char)(((x - 'a' + room.SectorId) % 26) + 'a');
                        });

                    var name = string.Join("", letters);

                    if (name.Contains("north"))
                    {
                        yield return $"{room.SectorId}: {name}";
                    }
                }
            }
        }
    }
}