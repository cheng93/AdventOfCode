using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Day25
{
    public class Day25Room
    {
        public Day25Room(string input)
        {
            /*
            Example input:


            == Sick Bay ==
            Supports both Red-Nosed Reindeer medicine and regular reindeer medicine.

            Doors here lead:
            - west

            Items here:
            - molten lava
            */
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var addingDoors = false;
            var doors = new List<string>();
            var items = new List<string>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (i == 0)
                {
                    this.Name = line[3..^3];
                }
                else if (i == 1)
                {
                    this.Description = line;
                }
                else if (line.StartsWith("Doors"))
                {
                    addingDoors = true;
                }
                else if (line.StartsWith("Items"))
                {
                    addingDoors = false;
                }
                else if (line.StartsWith("- "))
                {
                    if (addingDoors)
                    {
                        doors.Add(line[2..]);
                    }
                    else
                    {
                        items.Add(line[2..]);
                    }
                }
            }

            this.Doors = doors;
            this.Items = items;
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<string> Doors { get; }
        public ICollection<string> Items { get; }
    }
}