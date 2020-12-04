using System;
using System.Linq;

namespace AdventOfCode2020.Day04
{
    public class Day04Passport
    {
        /*
        Input:
        ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
        byr:1937 iyr:2017 cid:147 hgt:183cm
        */
        public Day04Passport(string input)
        {
            var lines = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var line in lines)
            {
                var splits = line.Split(' ');
                foreach (var kvp in splits)
                {
                    var kvpSplit = kvp.Split(':');
                    switch (kvpSplit[0])
                    {
                        case "byr":
                            this.Byr = int.Parse(kvpSplit[1]);
                            break;
                        case "iyr":
                            this.Iyr = int.Parse(kvpSplit[1]);
                            break;
                        case "eyr":
                            this.Eyr = int.Parse(kvpSplit[1]);
                            break;
                        case "hgt":
                            this.Hgt = kvpSplit[1];
                            break;
                        case "hcl":
                            this.Hcl = kvpSplit[1];
                            break;
                        case "ecl":
                            this.Ecl = kvpSplit[1];
                            break;
                        case "pid":
                            this.Pid = kvpSplit[1];
                            break;
                        case "cid":
                            this.Cid = kvpSplit[1];
                            break;

                    }
                }
            }
        }

        public int? Byr { get; }
        public int? Iyr { get; }
        public int? Eyr { get; }

        private string hgt;
        public string Hgt
        {
            get => this.hgt;
            set
            {
                this.hgt = value;
                var unit = value[^2..];
                if (unit == "cm")
                {
                    var measurement = int.Parse(value[..^2]);
                    this.HgtCM = measurement;
                }
                else if (unit == "in")
                {
                    var measurement = int.Parse(value[..^2]);
                    this.HgtIN = measurement;
                }
            }
        }
        public string Hcl { get; }
        public string Ecl { get; }
        public string Pid { get; }
        public string Cid { get; }

        public int? HgtCM { get; private set; }
        public int? HgtIN { get; private set; }
    }
}