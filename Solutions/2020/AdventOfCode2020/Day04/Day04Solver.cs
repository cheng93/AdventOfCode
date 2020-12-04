using System;
using System.Linq;

namespace AdventOfCode2020.Day04
{
    public class Day04Solver
    {
        public int PuzzleOne(string input)
        {
            var passports = input
                .Split(new[] { $"{Environment.NewLine}{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day04Passport(x))
                .ToArray();

            return passports.Count(x =>
                x.Byr.HasValue
                && x.Iyr.HasValue
                && x.Eyr.HasValue
                && x.Hgt != null
                && x.Hcl != null
                && x.Ecl != null
                && x.Pid != null);
        }
        public int PuzzleTwo(string input)
        {
            var passports = input
                .Split(new[] { $"{Environment.NewLine}{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day04Passport(x))
                .ToArray();

            return passports.Count(x =>
                x.Byr >= 1920 && x.Byr <= 2002
                && x.Iyr >= 2010 && x.Iyr <= 2020
                && x.Eyr >= 2020 && x.Eyr <= 2030
                && (x.HgtCM >= 150 && x.HgtCM <= 193
                    || x.HgtIN >= 59 && x.HgtIN <= 76)
                && (x.Hcl?.Length ?? 0) == 7
                && x.Hcl[0] == '#'
                && x.Hcl[1..].All(y =>
                    (y >= '0' && y <= '9')
                        || (y >= 'a' && y <= 'f'))
                && new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Any(y =>
                   y == x.Ecl)
                && (x.Pid?.Length ?? 0) == 9);
        }
    }
}