using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day16
{
    public class Day16Solver
    {
        public int PuzzleOne(string input)
        {
            var sections = input.Split($"{Environment.NewLine}{Environment.NewLine}");

            var rules = sections[0]
                .Split(Environment.NewLine)
                .Select(x => new Day16Rule(x));

            var nearbyTickets = sections[2]
                .Split(Environment.NewLine)
                .Skip(1);

            var invalid = new List<int>();

            foreach (var ticket in nearbyTickets)
            {
                var fields = ticket.Split(',').Select(int.Parse);
                foreach (var field in fields)
                {
                    var ranges = rules.SelectMany(x => x.Ranges);
                    if (ranges.All(x => field < x.Min || field > x.Max))
                    {
                        invalid.Add(field);
                    }
                }
            }

            return invalid.Sum();
        }

        public long PuzzleTwo(string input)
        {
            var sections = input.Split($"{Environment.NewLine}{Environment.NewLine}");

            var rules = sections[0]
                .Split(Environment.NewLine)
                .Select(x => new Day16Rule(x));

            var nearbyTickets = sections[2]
                .Split(Environment.NewLine)
                .Skip(1);

            var ruleSets = rules
                .Select(x => new HashSet<string>(rules.Select(y => y.Name)))
                .ToArray();

            foreach (var ticket in nearbyTickets)
            {
                var fields = ticket.Split(',').Select(int.Parse);
                var valid = true;
                var possibleRuleSets = new List<HashSet<string>>();
                foreach (var field in fields)
                {
                    var possibleRules = new HashSet<string>();
                    foreach (var rule in rules)
                    {
                        if (rule.Ranges.Any(x => field >= x.Min && field <= x.Max))
                        {
                            possibleRules.Add(rule.Name);
                        }
                    }
                    if (possibleRules.Count == 0)
                    {
                        valid = false;
                        break;
                    }

                    possibleRuleSets.Add(possibleRules);
                }

                if (valid)
                {
                    for (var i = 0; i < ruleSets.Length; i++)
                    {
                        ruleSets[i].IntersectWith(possibleRuleSets[i]);
                    }
                }
            }

            var myTicket = sections[1]
                .Split(Environment.NewLine)[1]
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var ordered = ruleSets
                .Select((x, i) => new { x, i })
                .OrderBy(x => x.x.Count)
                .ToList();

            var taken = new HashSet<string>();
            for (var i = 0; i < ordered.Count; i++)
            {
                var rule = ordered[i];
                taken.UnionWith(rule.x);
                for (var j = i + 1; j < ruleSets.Length; j++)
                {
                    ruleSets[ordered[j].i].ExceptWith(taken);
                }
            }

            return ruleSets
                .Select((x, i) => new { Name = x.First(), i })
                .Where(x => x.Name.StartsWith("departure"))
                .Aggregate(
                    1L,
                    (agg, cur) => agg * myTicket[cur.i]);
        }
    }
}