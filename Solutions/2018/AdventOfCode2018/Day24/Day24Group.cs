namespace AdventOfCode2018.Day24
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Day24Group
    {
        public int Units { get; set; }

        public int Hitpoints { get; }

        public int AttackDamage { get; set; }

        public string AttackType { get; }

        public int Initiative { get; }

        public ICollection<string> Immunities { get; } = new List<string>();

        public ICollection<string> Weaknesses { get; } = new List<string>();

        public int EffectivePower => Units * AttackDamage;

        public Day24Group(string input)
        {
            // Example input: 18 units each with 729 hit points (weak to fire; immune to cold, slashing) with an attack that does 8 radiation damage at initiative 10
            var pattern = @"^(?<units>\d+) units each with (?<hitpoints>\d+) hit points (?:\((?<weaknessImmunities>.+)\) )?with an attack that does (?<attackDamage>\d+) (?<attackType>\w+) damage at initiative (?<initiative>\d+)$";
            var match = Regex.Match(input, pattern);
            var groups = match.Groups;

            this.Units = int.Parse(groups["units"].Value);
            this.Hitpoints = int.Parse(groups["hitpoints"].Value);
            this.AttackDamage = int.Parse(groups["attackDamage"].Value);
            this.AttackType = groups["attackType"].Value;
            this.Initiative = int.Parse(groups["initiative"].Value);

            if (groups["weaknessImmunities"].Success)
            {
                var splits = groups["weaknessImmunities"].Value.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                var weakTo = "weak to ";
                var immuneTo = "immune to ";
                foreach (var split in splits)
                {
                    var substringStart = split.StartsWith(weakTo)
                        ? weakTo.Length
                        : immuneTo.Length;

                    var substring = split.Substring(substringStart);
                    var types = substring.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    if (split.StartsWith(weakTo))
                    {
                        this.Weaknesses = types;
                    }
                    else
                    {
                        this.Immunities = types;
                    }
                }
            }
        }
    }
}