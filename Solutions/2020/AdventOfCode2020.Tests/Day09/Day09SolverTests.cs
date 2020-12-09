using System.Collections.Generic;
using AdventOfCode2020.Day09;
using Xunit;

namespace AdventOfCode2020.Tests.Day09
{
    public class Day09SolverTests
    {
        private readonly Day09Solver subject = new Day09Solver();

        public static TheoryData<long, IEnumerable<long>> PuzzleOneTestData
            = new TheoryData<long, IEnumerable<long>>()
            {
                {
                    127L,
                    new long[]
                    {
                        35,
                        20,
                        15,
                        25,
                        47,
                        40,
                        62,
                        55,
                        65,
                        95,
                        102,
                        117,
                        150,
                        182,
                        127,
                        219,
                        299,
                        277,
                        309,
                        576,
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(long expected, IEnumerable<long> input)
        {
            var actual = this.subject.PuzzleOne(input, 5);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<long, IEnumerable<long>> PuzzleTwoTestData
            = new TheoryData<long, IEnumerable<long>>()
            {
                {
                    62L,
                    new long[]
                    {
                        35,
                        20,
                        15,
                        25,
                        47,
                        40,
                        62,
                        55,
                        65,
                        95,
                        102,
                        117,
                        150,
                        182,
                        127,
                        219,
                        299,
                        277,
                        309,
                        576,
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(long expected, IEnumerable<long> input)
        {
            var actual = this.subject.PuzzleTwo(input, 5);

            Assert.Equal(expected, actual);
        }
    }
}