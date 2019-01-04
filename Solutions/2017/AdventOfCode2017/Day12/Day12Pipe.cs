namespace AdventOfCode2017.Day12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day12Pipe
    {
        public int Id { get; }

        public IEnumerable<int> Recipients { get; }

        public Day12Pipe(string input)
        {
            // Example input: 2 <-> 0, 3, 4
            var splits = input.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);

            this.Id = int.Parse(splits[0]);

            this.Recipients = splits[1]
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}