using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day19
{
    public class Day19Solver
    {
        public int PuzzleOne(string input)
        {
            var sections = input.Split($"{Environment.NewLine}{Environment.NewLine}");

            var rules = sections[0]
                .Split(Environment.NewLine)
                .Select(x => new Day19Rule(x))
                .ToDictionary(x => x.Id, x => x);

            string Reduce(Day19Rule rule)
            {
                if (rule.Character.HasValue)
                {
                    return rule.Character.ToString();
                }

                var patterns = rule.SubRules
                    .Select(x => string.Join("", x.Select(y => Reduce(rules[y]))))
                    .ToList();

                return patterns.Count == 1
                    ? patterns.First()
                    : $"({string.Join("|", patterns)})";
            }

            var pattern = $"^{Reduce(rules[0])}$";

            var messages = sections[1].Split(Environment.NewLine);

            return messages.Count(x => Regex.Match(x, pattern).Success);
        }

        public int PuzzleTwo(string input)
        {
            var sections = input.Split($"{Environment.NewLine}{Environment.NewLine}");

            var rules = sections[0]
                .Split(Environment.NewLine)
                .Select(x => new Day19Rule(x))
                .ToDictionary(x => x.Id, x => x);

            rules[8] = new Day19Rule("8: 42 | 42 8");
            rules[11] = new Day19Rule("11: 42 31 | 42 11 31");

            string Reduce(Day19Rule rule, int rule11)
            {
                if (rule.Character.HasValue)
                {
                    return rule.Character.ToString();
                }
                if (rule.Id == 8)
                {
                    return $"({Reduce(rules[42], rule11)})+";
                }
                if (rule.Id == 11)
                {
                    return $"({Reduce(rules[42], rule11)}){{{rule11}}}({Reduce(rules[31], rule11)}){{{rule11}}}";
                }

                var patterns = rule.SubRules
                    .Select(x => string.Join("", x.Select(y => Reduce(rules[y], rule11))))
                    .ToList();

                return patterns.Count == 1
                    ? patterns.First()
                    : $"({string.Join("|", patterns)})";
            }

            var patterns = Enumerable.Range(1, 10)
                .Select(x => $"^{Reduce(rules[0], x)}$");

            var messages = sections[1].Split(Environment.NewLine);

            return messages.Count(x => patterns.Any(y => Regex.Match(x, y).Success));
        }
    }
}