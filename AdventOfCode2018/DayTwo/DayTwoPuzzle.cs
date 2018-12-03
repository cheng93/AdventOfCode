
namespace AdventOfCode2018.DayTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DayTwoPuzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.DayTwo.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new DayTwoSolver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.DayTwo.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new DayTwoSolver().PuzzleTwo(input);
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}