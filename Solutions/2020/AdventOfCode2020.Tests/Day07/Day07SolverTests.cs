using System.Collections.Generic;
using AdventOfCode2020.Day07;
using Xunit;

namespace AdventOfCode2020.Tests.Day07
{
    public class Day07SolverTests
    {
        private readonly Day07Solver subject = new Day07Solver();

        public static TheoryData<int, IEnumerable<string>> PuzzleOneTestData
            = new TheoryData<int, IEnumerable<string>>()
            {
                {
                    4,
                    new []
                    {
                        "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                        "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                        "bright white bags contain 1 shiny gold bag.",
                        "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                        "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                        "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                        "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                        "faded blue bags contain no other bags.",
                        "dotted black bags contain no other bags.",
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<int, IEnumerable<string>> PuzzleTwoTestData
            = new TheoryData<int, IEnumerable<string>>()
            {
                {
                    32,
                    new []
                    {
                        "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                        "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                        "bright white bags contain 1 shiny gold bag.",
                        "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                        "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                        "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                        "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                        "faded blue bags contain no other bags.",
                        "dotted black bags contain no other bags.",
                    }
                },
                {
                    126,
                    new []
                    {
                        "shiny gold bags contain 2 dark red bags.",
                        "dark red bags contain 2 dark orange bags.",
                        "dark orange bags contain 2 dark yellow bags.",
                        "dark yellow bags contain 2 dark green bags.",
                        "dark green bags contain 2 dark blue bags.",
                        "dark blue bags contain 2 dark violet bags.",
                        "dark violet bags contain no other bags.",
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}