namespace AdventOfCode2016.Day04
{
    using System.Text.RegularExpressions;

    public class Day04Room
    {
        public string Name { get; }

        public int SectorId { get; }

        public string Checksum { get; }

        private const string pattern = "^(.+)-(\\d+)\\[(\\w+)\\]$";

        public Day04Room(string input)
        {
            // Example input: aaaaa-bbb-z-y-x-123[abxyz]
            var match = Regex.Match(input, pattern);
            var groups = match.Groups;

            this.Name = groups[1].Value;
            this.SectorId = int.Parse(groups[2].Value);
            this.Checksum = groups[3].Value;
        }
    }
}