namespace AdventOfCode2015.Day15;

public class Day15Ingredient
{
    // Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
    public Day15Ingredient(string input)
    {
        var numbers = input
            .Replace(":", string.Empty)
            .Replace(",", string.Empty)
            .Split(' ')
            .Where(x => int.TryParse(x, out _))
            .Select(int.Parse)
            .ToArray();

        Capacity = numbers[0];
        Durability = numbers[1];
        Flavor = numbers[2];
        Texture = numbers[3];
        Calories = numbers[4];
    }

    public int Capacity { get; }

    public int Durability { get; }

    public int Flavor { get; }

    public int Texture { get; }

    public int Calories { get; }
}