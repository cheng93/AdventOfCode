
namespace AdventOfCode2018.DayTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DayTwoSolver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var stringParser = new DayTwoStringParser();

            var parsed = input.Select(stringParser.Parse);

            var two = 0;
            var three = 0;

            foreach (var entry in parsed)
            {
                if (entry.HasTwo)
                {
                    two++;
                }
                if (entry.HasThree)
                {
                    three++;
                }
            }

            return two * three;
        }

        public string PuzzleTwo(IEnumerable<string> input)
        {
            var splitIds = input.Select(x => new DayTwoIds(x));
            var wordLength = input.First().Length;

            for (var i = 0; i < wordLength; i++)
            {
                var match = splitIds
                    .Select(x => new { Before = x.Before[i], After = x.After[i] })
                    .GroupBy(x => x)
                    .Where(x => x.Count() > 1)
                    .Select(x => x.Key)
                    .FirstOrDefault();

                if (match != null)
                {
                    return $"{match.Before}{match.After}";
                }
            }

            throw new Exception();
        }
    }
}