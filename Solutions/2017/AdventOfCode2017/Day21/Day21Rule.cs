namespace AdventOfCode2017.Day21
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day21Rule
    {
        public string Output { get; }

        public int Size { get; }

        public HashSet<string> Inputs { get; } = new HashSet<string>();

        public Day21Rule(string input)
        {
            // Example input: .#./..#/### => #..#/..../..../#..#

            var splits = input.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);

            this.Output = splits[1];

            this.Inputs.Add(splits[0]);

            var grid = splits[0].Split('/');

            this.Size = grid.Length;

            var horizontalFlip = new List<string>();

            for (var i = 0; i < this.Size; i++)
            {
                horizontalFlip.Add(grid[this.Size - 1 - i]);
            }

            foreach (var initial in new[] { splits[0], string.Join("/", horizontalFlip) })
            {
                var rotate = initial;
                for (var i = 0; i < 3; i++)
                {
                    grid = rotate.Split('/');
                    var transpose = Enumerable.Range(0, this.Size).Select(x => "").ToArray();

                    for (var j = 0; j < this.Size; j++)
                    {
                        for (var k = 0; k < this.Size; k++)
                        {
                            transpose[k] += grid[j][k];
                        }
                    }

                    for (var j = 0; j < this.Size; j++)
                    {
                        transpose[j] = string.Join("", transpose[j].Reverse());
                    }

                    var rotated = string.Join("/", transpose);
                    this.Inputs.Add(rotated);
                    rotate = rotated;
                }
            }
        }
    }
}