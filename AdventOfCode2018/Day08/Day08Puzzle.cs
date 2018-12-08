namespace AdventOfCode2018.Day08
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Day08Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day08.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day08Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day08.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day08Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<int>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(' ')
                .Select(int.Parse);
        }
    }
}