using System.Collections.Generic;
using AdventOfCode2020.Day12;
using Xunit;

namespace AdventOfCode2020.Tests.Day12
{
    public class Day12SolverTests
    {
        private readonly Day12Solver subject = new Day12Solver();

        public static TheoryData<int, IEnumerable<string>> PuzzleOneTestData
            = new TheoryData<int, IEnumerable<string>>()
            {
                {
                    25,
                    new []
                    {
                        "F10",
                        "N3",
                        "F7",
                        "R90",
                        "F11",
                    }
                },
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
                    286,
                    new []
                    {
                        "F10",
                        "N3",
                        "F7",
                        "R90",
                        "F11",
                    }
                },
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