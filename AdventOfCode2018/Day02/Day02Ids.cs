
namespace AdventOfCode2018.Day02
{
    using System.Collections.Generic;

    public class Day02Ids
    {
        public Dictionary<int, string> Before { get; } = new Dictionary<int, string>();

        public Dictionary<int, string> After { get; } = new Dictionary<int, string>();
        public Day02Ids(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                Before.Add(i, i == 0 ? string.Empty : input.Substring(0, i));
                After.Add(i, i == input.Length - 1 ? string.Empty : input.Substring(i + 1));
            }
        }
    }
}