using System.Linq;

namespace AdventOfCode2019.Day04
{
    public class Day04Solver
    {
        public int PuzzleOne(int min, int max)
        {
            var validator = new Day04Validator();
            return Enumerable.Range(min, max - min)
                .Count(validator.IsValidOne);
        }

        public int PuzzleTwo(int min, int max)
        {
            var validator = new Day04Validator();
            return Enumerable.Range(min, max - min)
                .Count(validator.IsValidTwo);
        }
    }
}