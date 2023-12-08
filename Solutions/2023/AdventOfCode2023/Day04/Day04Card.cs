namespace AdventOfCode2023.Day04;

public class Day04Card
{
    // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
    public Day04Card(string input)
    {
        var splits = input.Split(new[] { ": ", "|" }, StringSplitOptions.RemoveEmptyEntries);

        var winningNumbers = splits[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        WinningNumbers = new HashSet<int>(winningNumbers);

        var ownNumbers = splits[2]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        OwnNumbers = new HashSet<int>(ownNumbers);
    }

    public IEnumerable<int> WinningNumbers { get; set; }

    public IEnumerable<int> OwnNumbers { get; set; }

    public int GetMatches() => WinningNumbers
                .Intersect(OwnNumbers)
                .Count();

    public int GetScore()
    {
        var matches = GetMatches();

        return matches == 0
            ? 0
            : (int)Math.Pow(2, matches - 1);
    }
}