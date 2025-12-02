using System.Collections.Generic;
using AdventOfCode2020.Day21;
using Xunit;

namespace AdventOfCode2020.Tests.Day21
{
    public class Day21SolverTests
    {
        private readonly Day21Solver subject = new Day21Solver();

        public static TheoryData<long, IEnumerable<string>> PuzzleOneTestData
            = new TheoryData<long, IEnumerable<string>>()
            {
                {
                    5,
                    new []
                    {
                        "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
                        "trh fvjkl sbzzf mxmxvkd (contains dairy)",
                        "sqjhc fvjkl (contains soy)",
                        "sqjhc mxmxvkd sbzzf (contains fish)",
                    }
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(long expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<string, IEnumerable<string>> PuzzleTwoTestData
            = new TheoryData<string, IEnumerable<string>>()
            {
                {
                    "mxmxvkd,sqjhc,fvjkl",
                    new []
                    {
                        "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
                        "trh fvjkl sbzzf mxmxvkd (contains dairy)",
                        "sqjhc fvjkl (contains soy)",
                        "sqjhc mxmxvkd sbzzf (contains fish)",
                    }
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(string expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}