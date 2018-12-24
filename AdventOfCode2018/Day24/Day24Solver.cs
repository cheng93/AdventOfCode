namespace AdventOfCode2018.Day24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day24Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var immuneGroups = new List<Day24Group>();
            var infectionGroups = new List<Day24Group>();

            var readingImmune = false;
            foreach (var line in lines)
            {
                if (line == "Immune System:")
                {
                    readingImmune = true;
                }
                else if (line == "Infection:")
                {
                    readingImmune = false;
                }
                else
                {
                    var group = new Day24Group(line);
                    if (readingImmune)
                    {
                        immuneGroups.Add(group);
                    }
                    else
                    {
                        infectionGroups.Add(group);
                    }
                }
            }

            while (immuneGroups.Any() && infectionGroups.Any())
            {
                var targets = new Dictionary<Day24Group, Day24Group>();
                var copyImmune = immuneGroups.ToList();
                var copyInfections = infectionGroups.ToList();
                foreach (var immune in immuneGroups.OrderByDescending(x => x.EffectivePower))
                {
                    var enemy = copyInfections
                        .Where(x => CalculateDamage(immune, x) > 0)
                        .OrderByDescending(x => CalculateDamage(immune, x))
                        .ThenByDescending(x => x.EffectivePower)
                        .ThenByDescending(x => x.Initiative)
                        .FirstOrDefault();

                    if (enemy != null)
                    {
                        targets.Add(immune, enemy);
                        copyInfections.Remove(enemy);
                    }
                }
                foreach (var infection in infectionGroups.OrderByDescending(x => x.EffectivePower))
                {
                    var enemy = copyImmune
                        .Where(x => CalculateDamage(infection, x) > 0)
                        .OrderByDescending(x => CalculateDamage(infection, x))
                        .ThenByDescending(x => x.EffectivePower)
                        .ThenByDescending(x => x.Initiative)
                        .FirstOrDefault();

                    if (enemy != null)
                    {
                        targets.Add(infection, enemy);
                        copyImmune.Remove(enemy);
                    }
                }

                foreach (var attacker in targets.Keys.OrderByDescending(x => x.Initiative))
                {
                    var target = targets[attacker];
                    var damage = CalculateDamage(attacker, target);
                    var killed = Math.Min(target.Units, damage / target.Hitpoints);

                    target.Units -= killed;
                    if (target.Units <= 0)
                    {
                        immuneGroups.Remove(target);
                        infectionGroups.Remove(target);
                    }
                }
            }

            return immuneGroups.Sum(x => x.Units) + infectionGroups.Sum(x => x.Units);
        }
        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var boost = 0;

            while (true)
            {
                var immuneGroups = new List<Day24Group>();
                var infectionGroups = new List<Day24Group>();

                var readingImmune = false;

                foreach (var line in lines)
                {
                    if (line == "Immune System:")
                    {
                        readingImmune = true;
                    }
                    else if (line == "Infection:")
                    {
                        readingImmune = false;
                    }
                    else
                    {
                        var group = new Day24Group(line);
                        if (readingImmune)
                        {
                            group.AttackDamage += boost;
                            immuneGroups.Add(group);
                        }
                        else
                        {
                            infectionGroups.Add(group);
                        }
                    }
                }

                var immunes = immuneGroups.Sum(x => x.Units);
                var infections = infectionGroups.Sum(x => x.Units);

                while (immuneGroups.Any() && infectionGroups.Any())
                {
                    var targets = new Dictionary<Day24Group, Day24Group>();
                    var copyImmune = immuneGroups.ToList();
                    var copyInfections = infectionGroups.ToList();
                    foreach (var immune in immuneGroups.OrderByDescending(x => x.EffectivePower))
                    {
                        var enemy = copyInfections
                            .Where(x => CalculateDamage(immune, x) > 0)
                            .OrderByDescending(x => CalculateDamage(immune, x))
                            .ThenByDescending(x => x.EffectivePower)
                            .ThenByDescending(x => x.Initiative)
                            .FirstOrDefault();

                        if (enemy != null)
                        {
                            targets.Add(immune, enemy);
                            copyInfections.Remove(enemy);
                        }
                    }
                    foreach (var infection in infectionGroups.OrderByDescending(x => x.EffectivePower))
                    {
                        var enemy = copyImmune
                            .Where(x => CalculateDamage(infection, x) > 0)
                            .OrderByDescending(x => CalculateDamage(infection, x))
                            .ThenByDescending(x => x.EffectivePower)
                            .ThenByDescending(x => x.Initiative)
                            .FirstOrDefault();

                        if (enemy != null)
                        {
                            targets.Add(infection, enemy);
                            copyImmune.Remove(enemy);
                        }
                    }

                    foreach (var attacker in targets.Keys.OrderByDescending(x => x.Initiative))
                    {
                        var target = targets[attacker];
                        var damage = CalculateDamage(attacker, target);
                        var killed = Math.Min(target.Units, damage / target.Hitpoints);

                        target.Units -= killed;
                        if (target.Units <= 0)
                        {
                            immuneGroups.Remove(target);
                            infectionGroups.Remove(target);
                        }
                    }
                    var newImmunes = immuneGroups.Sum(x => x.Units);
                    var newInfections = infectionGroups.Sum(x => x.Units);
                    if (newImmunes == immunes && newInfections == infections)
                    {
                        break;
                    }
                    else
                    {
                        immunes = newImmunes;
                        infections = newInfections;
                    }
                }

                if (immuneGroups.Any() && !infectionGroups.Any())
                {
                    return immunes;
                }
                boost++;
            }
        }

        private static int CalculateDamage(Day24Group attacker, Day24Group target)
        {
            var damage = attacker.EffectivePower;
            if (target.Weaknesses.Contains(attacker.AttackType))
            {
                damage *= 2;
            }
            else if (target.Immunities.Contains(attacker.AttackType))
            {
                damage = 0;
            }

            return damage;
        }
    }
}