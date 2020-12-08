using System.Collections.Generic;
using AdventOfCode2020.Day08;
using Xunit;

namespace AdventOfCode2020.Tests.Day08
{
    public class Day08SolverTests
    {
        private readonly Day08Solver subject = new Day08Solver();

        public static TheoryData<int, IEnumerable<string>> PuzzleOneTestData
            = new TheoryData<int, IEnumerable<string>>()
            {
                {
                    5,
                    new []
                    {
                        "nop +0",
                        "acc +1",
                        "jmp +4",
                        "acc +3",
                        "jmp -3",
                        "acc -99",
                        "acc +1",
                        "jmp -4",
                        "acc +6",
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
                    8,
                    new []
                    {
                        "nop +0",
                        "acc +1",
                        "jmp +4",
                        "acc +3",
                        "jmp -3",
                        "acc -99",
                        "acc +1",
                        "jmp -4",
                        "acc +6",
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