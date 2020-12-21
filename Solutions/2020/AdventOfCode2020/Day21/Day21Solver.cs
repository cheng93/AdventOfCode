using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day21
{
    public class Day21Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var foods = input
                .Select(x => new Day21Food(x))
                .ToArray();

            var ingredients = new HashSet<string>();
            var allergenLookup = new Dictionary<string, HashSet<string>>();

            foreach (var food in foods)
            {
                ingredients.UnionWith(food.Ingredients);
                foreach (var allergen in food.Allergens)
                {
                    if (allergenLookup.TryGetValue(allergen, out var allergenIngredients))
                    {
                        allergenIngredients.IntersectWith(food.Ingredients);
                    }
                    else
                    {
                        allergenLookup[allergen] = new HashSet<string>(food.Ingredients);
                    }
                }
            }


            foreach (var allergenIngredients in allergenLookup.Values)
            {
                ingredients.ExceptWith(allergenIngredients);
            }

            return foods
                .SelectMany(x => x.Ingredients)
                .Count(x => ingredients.Contains(x));
        }

        public string PuzzleTwo(IEnumerable<string> input)
        {
            var foods = input
                .Select(x => new Day21Food(x))
                .ToArray();

            var ingredients = new HashSet<string>();
            var allergenLookup = new Dictionary<string, HashSet<string>>();

            foreach (var food in foods)
            {
                ingredients.UnionWith(food.Ingredients);
                foreach (var allergen in food.Allergens)
                {
                    if (allergenLookup.TryGetValue(allergen, out var allergenIngredients))
                    {
                        allergenIngredients.IntersectWith(food.Ingredients);
                    }
                    else
                    {
                        allergenLookup[allergen] = new HashSet<string>(food.Ingredients);
                    }
                }
            }

            var found = new HashSet<string>();
            var taken = new HashSet<string>();

            for (var i = 0; i < allergenLookup.Count; i++)
            {
                var reducedLookup = allergenLookup
                    .Where(x => !found.Contains(x.Key))
                    .OrderBy(x => x.Value.Count)
                    .ToList();

                var kvp = reducedLookup.First();
                taken.UnionWith(kvp.Value);

                for (var j = 1; j < reducedLookup.Count; j++)
                {
                    allergenLookup[reducedLookup[j].Key].ExceptWith(taken);
                }
                found.Add(kvp.Key);
            }

            return string.Join(",", allergenLookup.OrderBy(x => x.Key).Select(x => x.Value.First()));
        }
    }
}