namespace AdventOfCode2015.Day16;

public class Day16Sue
{
    // Sue 1: goldfish: 6, trees: 9, akitas: 0
    public Day16Sue(string input)
    {
        var splits = input
            .Replace(",", string.Empty)
            .Split(' ')
            .ToArray();

        Id = int.Parse(splits[1][..^1]);

        for (var i = 2; i < splits.Length; i += 2)
        {
            var compound = splits[i][..^1];
            var amount = int.Parse(splits[i + 1]);
            switch (compound)
            {
                case "children":
                    Children = amount;
                    break;
                case "cats":
                    Cats = amount;
                    break;
                case "samoyeds":
                    Samoyeds = amount;
                    break;
                case "pomeranians":
                    Pomeranians = amount;
                    break;
                case "akitas":
                    Akitas = amount;
                    break;
                case "vizslas":
                    Vizslas = amount;
                    break;
                case "goldfish":
                    Goldfish = amount;
                    break;
                case "trees":
                    Trees = amount;
                    break;
                case "cars":
                    Cars = amount;
                    break;
                case "perfumes":
                    Perfumes = amount;
                    break;
            }
        }
    }

    public int Id { get; }

    public int? Children { get; }

    public int? Cats { get; }

    public int? Samoyeds { get; }

    public int? Pomeranians { get; }

    public int? Akitas { get; }

    public int? Vizslas { get; }

    public int? Goldfish { get; }

    public int? Trees { get; }

    public int? Cars { get; }

    public int? Perfumes { get; }
}