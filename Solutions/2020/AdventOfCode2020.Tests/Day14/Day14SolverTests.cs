using System.Collections.Generic;
using AdventOfCode2020.Day14;
using Xunit;

namespace AdventOfCode2020.Tests.Day14
{
    public class Day14SolverTests
    {
        private readonly Day14Solver subject = new Day14Solver();

        public static TheoryData<long, IEnumerable<string>> PuzzleOneTestData
            = new TheoryData<long, IEnumerable<string>>()
            {
                {
                    165,
                    new []
                    {
                        "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                        "mem[8] = 11",
                        "mem[7] = 101",
                        "mem[8] = 0",
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

        public static TheoryData<long, IEnumerable<string>> PuzzleTwoTestData
            = new TheoryData<long, IEnumerable<string>>()
            {
                {
                    208,
                    new []
                    {
                        "mask = 000000000000000000000000000000X1001X",
                        "mem[42] = 100",
                        "mask = 00000000000000000000000000000000X0XX",
                        "mem[26] = 1",
                    }
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(long expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}