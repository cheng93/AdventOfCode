using System.Collections.Generic;
using AdventOfCode2019.Day09;
using Xunit;

namespace AdventOfCode2019.Tests.Day09
{
    public class Day09SolverTests
    {
        private readonly Day09Solver subject = new Day09Solver();

        public static IEnumerable<object[]> PuzzleOneTestData = new[]
        {
            new object[]
            {
                new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 },
                new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 }
            },
            new object[]
            {
                new long[] { 1125899906842624 },
                new long[] { 104, 1125899906842624, 99 }
            }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(long[] expected, long[] input)
        {
            var actual = this.subject.PuzzleOne(input, new long[] { });

            Assert.Equal(expected, actual);
        }
    }
}