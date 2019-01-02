namespace AdventOfCode2017.Day04
{
    using System;
    using System.Linq;

    public class Day04Solver
    {
        public int PuzzleOne(string input)
        {
            var passphrases = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0;

            foreach (var passphrase in passphrases)
            {
                var words = passphrase.Split(' ');

                var duplicateWords = words
                    .GroupBy(x => x)
                    .Where(x => x.Count() > 1);

                if (!duplicateWords.Any())
                {
                    sum++;
                }
            }

            return sum;
        }

        public int PuzzleTwo(string input)
        {
            var passphrases = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0;

            foreach (var passphrase in passphrases)
            {
                var words = passphrase.Split(' ');

                var duplicateWords = words
                    .GroupBy(x => string.Join("", x.OrderBy(y => y)))
                    .Where(x => x.Count() > 1);

                if (!duplicateWords.Any())
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}