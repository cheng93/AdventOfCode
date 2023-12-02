namespace AdventOfCode2023.Day02;

public class Day02Game
{
    // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    public Day02Game(string input)
    {
        var splits = input.Split(new[] { "Game ", ": ", "; " }, StringSplitOptions.RemoveEmptyEntries);
        Id = int.Parse(splits[0]);
        Sets = splits
            .Skip(1)
            .Select(x => new Day02Set(x))
            .ToList();
    }

    public int Id { get; set; }

    public IEnumerable<Day02Set> Sets { get; set; }
}