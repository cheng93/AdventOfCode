using System.Linq;

namespace AdventOfCode2019.Day14
{
    public class Day14Chemical
    {
        public Day14Chemical(string name, long quantity)
        {
            this.Quantity = quantity;
            this.Name = name;
        }

        public Day14Chemical(string input)
        {
            // Example input: 10 ORE
            var split = input.Split(' ').ToArray();
            this.Quantity = long.Parse(split[0]);
            this.Name = split[1];
        }

        public long Quantity { get; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            var cast = obj as Day14Chemical;
            if (cast == null || GetType() != obj.GetType()) return false;
            return (this.Quantity, this.Name) == (cast.Quantity, cast.Name);
        }

        public override int GetHashCode()
        {
            return (this.Quantity, this.Name).GetHashCode();
        }
    }

    public static class Day14ChemicalExtensions
    {
        public static bool IsFuel(this Day14Chemical chemical) => chemical.Name == "FUEL";

        public static bool IsOre(this Day14Chemical chemical) => chemical.Name == "ORE";
    }
}