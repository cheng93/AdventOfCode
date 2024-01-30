namespace AdventOfCode2015.Day16;

public static class Day16Solver
{
    public static int PuzzleOne(string input)
    {
        var sues = input
            .Split(Environment.NewLine)
            .Select(x => new Day16Sue(x))
            .ToArray();

        return sues
            .Single(x =>
                IsMatch(x.Children, 3)
                && IsMatch(x.Cats, 7)
                && IsMatch(x.Samoyeds, 2)
                && IsMatch(x.Pomeranians, 3)
                && IsMatch(x.Akitas, 0)
                && IsMatch(x.Vizslas, 0)
                && IsMatch(x.Goldfish, 5)
                && IsMatch(x.Trees, 3)
                && IsMatch(x.Cars, 2)
                && IsMatch(x.Perfumes, 1))
            .Id;

        bool IsMatch(int? property, int amount)
            => !property.HasValue || property.Value == amount;
    }

    public static int PuzzleTwo(string input)
    {
        var sues = input
            .Split(Environment.NewLine)
            .Select(x => new Day16Sue(x))
            .ToArray();

        return sues
            .Single(x =>
                IsMatch(x.Children, 3)
                && IsGreaterThan(x.Cats, 7)
                && IsMatch(x.Samoyeds, 2)
                && IsFewerThan(x.Pomeranians, 3)
                && IsMatch(x.Akitas, 0)
                && IsMatch(x.Vizslas, 0)
                && IsFewerThan(x.Goldfish, 5)
                && IsGreaterThan(x.Trees, 3)
                && IsMatch(x.Cars, 2)
                && IsMatch(x.Perfumes, 1))
            .Id;

        bool IsMatch(int? property, int amount)
            => !property.HasValue || property.Value == amount;

        bool IsGreaterThan(int? property, int amount)
            => !property.HasValue || property.Value > amount;

        bool IsFewerThan(int? property, int amount)
            => !property.HasValue || property.Value < amount;
    }
}