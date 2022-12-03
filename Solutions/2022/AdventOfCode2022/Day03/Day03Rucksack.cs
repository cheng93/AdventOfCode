namespace AdventOfCode2022.Day03;

public class Day03Rucksack
{
    //vJrwpWtwJgWrhcsFMMfFFhFp
    public Day03Rucksack(string input)
    {
        var half = input.Length / 2;
        Compartments = new List<string> { input[0..half], input[half..] };
        Items = input;
    }

    public string Items { get; }

    public ICollection<string> Compartments { get; }
}