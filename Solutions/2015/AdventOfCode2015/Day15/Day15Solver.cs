namespace AdventOfCode2015.Day15;

public static class Day15Solver
{
    public static int PuzzleOne(string input) => Solve(input);

    public static int PuzzleTwo(string input) => Solve(input, 500);

    private static int Solve(string input, int? targetCalories = null)
    {
        var ingredients = input
            .Split(Environment.NewLine)
            .Select(x => new Day15Ingredient(x))
            .ToArray();

        var max = int.MinValue;

        foreach (var combinations in Generate(ingredients.Length - 1, 100))
        {
            var capacity = 0;
            var durability = 0;
            var flavor = 0;
            var texture = 0;
            var calories = 0;

            for (var i = 0; i < ingredients.Length; i++)
            {
                var ingredient = ingredients[i];
                var amount = combinations[i];
                capacity += ingredient.Capacity * amount;
                durability += ingredient.Durability * amount;
                flavor += ingredient.Flavor * amount;
                texture += ingredient.Texture * amount;
                calories += ingredient.Calories * amount;
            }

            if (targetCalories.HasValue && calories != targetCalories)
            {
                continue;
            }

            var score = new[] { capacity, durability, flavor, texture }
                .Select(x => Math.Max(0, x))
                .Aggregate(1, (agg, cur) => agg * cur);
            max = Math.Max(max, score);
        }

        return max;

        IEnumerable<int[]> Generate(int depth, int remainder)
        {
            if (depth == 0)
            {
                yield return [remainder];
                yield break;
            }

            for (var i = 0; i <= remainder; i++)
            {
                foreach (var rest in Generate(depth - 1, remainder - i))
                {
                    yield return [i, .. rest];
                }
            }
        }
    }
}