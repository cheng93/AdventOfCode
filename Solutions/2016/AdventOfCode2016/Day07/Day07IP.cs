namespace AdventOfCode2016.Day07
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day07IP
    {
        public IEnumerable<string> Hypernets { get; }

        public IEnumerable<string> Supernets { get; }

        private const string pattern = "(?:\\[(?<hypernets>\\w+)\\]|(?<supernets>\\w+))";

        public Day07IP(string input)
        {
            // example input: wysextplwqpvipxdv[srzvtwbfzqtspxnethm]syqbzgtboxxzpwr[kljvjjkjyojzrstfgrw]obdhcczonzvbfby[svotajtpttohxsh]cooktbyumlpxostt
            var matches = Regex.Matches(input, pattern);

            this.Hypernets = matches
                .Cast<Match>()
                .Select(x => x.Groups["hypernets"])
                .Where(x => x.Success)
                .Select(x => x.Value);

            this.Supernets = matches
                .Cast<Match>()
                .Select(x => x.Groups["supernets"])
                .Where(x => x.Success)
                .Select(x => x.Value);

        }
    }
}