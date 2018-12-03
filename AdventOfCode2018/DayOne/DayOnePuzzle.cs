namespace AdventOfCode2018.DayOne
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class DayOnePuzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.DayOne.PuzzleOne.txt";
            var input = await this.GetInput(resource);

            return new DayOneSolver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.DayOne.PuzzleOne.txt";
            var input = await this.GetInput(resource);

            return new DayOneSolver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<int>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x, NumberStyles.AllowLeadingSign));
        }
    }
}
