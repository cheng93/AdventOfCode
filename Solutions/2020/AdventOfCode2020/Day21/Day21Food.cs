using System.Collections.Generic;

namespace AdventOfCode2020.Day21
{
    public class Day21Food
    {
        // Input:
        // mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
        public Day21Food(string input)
        {
            var splits = input.Split(" (contains ");

            this.Ingredients = new HashSet<string>(splits[0].Split(" "));
            this.Allergens = new HashSet<string>(splits[1][..^1].Split(", "));
        }

        public HashSet<string> Ingredients { get; }

        public HashSet<string> Allergens { get; }
    }
}