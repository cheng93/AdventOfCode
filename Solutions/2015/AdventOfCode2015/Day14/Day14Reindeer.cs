namespace AdventOfCode2015.Day14;

using Fly = (int Speed, int Time);

public class Day14Reindeer
{
    // Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
    public Day14Reindeer(string input)
    {
        var numbers = input
            .Split(' ')
            .Where(x => int.TryParse(x, out _))
            .Select(int.Parse)
            .ToArray();

        Fly = (numbers[0], numbers[1]);
        Rest = numbers[2];
    }

    public Fly Fly { get; }

    public int Rest { get; }
}