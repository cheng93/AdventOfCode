using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    public class Day02Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var count = 0;
            foreach (var line in input)
            {
                var splits = line.Split(": ");
                var policy = new Day02Policy(splits[0]);
                var password = splits[1];

                var letters = password.Count(x => x == policy.Letter);
                if (letters >= policy.Min && letters <= policy.Max)
                {
                    count++;
                }
            }

            return count;
        }
        public int PuzzleTwo(IEnumerable<string> input)
        {
            var count = 0;
            foreach (var line in input)
            {
                var splits = line.Split(": ");
                var policy = new Day02Policy(splits[0]);
                var password = splits[1];

                var minLetter = password[policy.Min - 1];
                var maxLetter = password[policy.Max - 1];
                if (minLetter == policy.Letter ^ maxLetter == policy.Letter)
                {
                    count++;
                }
            }

            return count;
        }
    }
}