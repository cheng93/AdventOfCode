namespace AdventOfCode2023.Day07;

using HandBid = (Day07Hand Hand, int Bid);
using JokerBid = (Day07Joker Hand, int Bid);

public static class Day07Solver
{
    public static int PuzzleOne(string input) =>
        input
            .Split(Environment.NewLine)
            .Select(line =>
            {
                var words = line.Split(" ");
                return new HandBid(new(words[0]), int.Parse(words[1]));
            })
            .OrderBy(handBid => handBid.Hand)
            .Select((handBid, i) => handBid.Bid * (i + 1))
            .Sum();

    public static int PuzzleTwo(string input) =>
        input
            .Split(Environment.NewLine)
            .Select(line =>
            {
                var words = line.Split(" ");
                return new JokerBid(new(words[0]), int.Parse(words[1]));
            })
            .OrderBy(handBid => handBid.Hand)
            .Select((handBid, i) => handBid.Bid * (i + 1))
            .Sum();
}