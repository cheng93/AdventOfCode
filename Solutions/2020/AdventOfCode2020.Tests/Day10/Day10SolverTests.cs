using System.Collections.Generic;
using AdventOfCode2020.Day10;
using Xunit;

namespace AdventOfCode2020.Tests.Day10
{
    public class Day10SolverTests
    {
        private readonly Day10Solver subject = new Day10Solver();

        public static TheoryData<int, IEnumerable<int>> PuzzleOneTestData
            = new TheoryData<int, IEnumerable<int>>()
            {
                {
                    35,
                    new []
                    {
                        16,
                        10,
                        15,
                        5,
                        1,
                        11,
                        7,
                        19,
                        6,
                        12,
                        4,
                    }
                },
                {
                    0,
                    new []
                    {
                        28,
                        33,
                        18,
                        42,
                        31,
                        14,
                        46,
                        20,
                        48,
                        47,
                        24,
                        23,
                        49,
                        45,
                        19,
                        38,
                        39,
                        11,
                        1,
                        32,
                        25,
                        35,
                        8,
                        17,
                        7,
                        9,
                        4,
                        2,
                        34,
                        10,
                        3,
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, IEnumerable<int> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<long, IEnumerable<int>> PuzzleTwoTestData
            = new TheoryData<long, IEnumerable<int>>()
            {
                {
                    8,
                    new []
                    {
                        16,
                        10,
                        15,
                        5,
                        1,
                        11,
                        7,
                        19,
                        6,
                        12,
                        4,
                    }
                },
                {
                    19208,
                    new []
                    {
                        28,
                        33,
                        18,
                        42,
                        31,
                        14,
                        46,
                        20,
                        48,
                        47,
                        24,
                        23,
                        49,
                        45,
                        19,
                        38,
                        39,
                        11,
                        1,
                        32,
                        25,
                        35,
                        8,
                        17,
                        7,
                        9,
                        4,
                        2,
                        34,
                        10,
                        3,
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(long expected, IEnumerable<int> input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}