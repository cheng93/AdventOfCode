namespace AdventOfCode2023.Day04;

public static class Day04Solver
{
    public static int PuzzleOne(string input)
        => input
            .Split(Environment.NewLine)
            .Select(line => new Day04Card(line))
            .Sum(card => card.GetScore());


    public static int PuzzleTwo(string input)
    {
        var cards = input
            .Split(Environment.NewLine)
            .Select(line => new Day04Card(line))
            .ToArray();

        var counts = Enumerable
            .Range(1, cards.Length)
            .Select(x => 1)
            .ToArray();

        for (var i = 0; i < cards.Length; i++)
        {
            var card = cards[i];
            var matches = card.GetMatches();

            for (var j = 1; j <= matches; j++)
            {
                counts[i + j] += counts[i];
            }
        }

        return counts.Sum();
    }
}