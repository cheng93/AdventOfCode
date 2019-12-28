using System.Collections.Generic;
using AdventOfCode2019.Day24;
using Xunit;

namespace AdventOfCode2019.Tests.Day24
{
    public class Day24SolverTests
    {
        private readonly Day24Solver subject = new Day24Solver();

        public static IEnumerable<object[]> PuzzleOneTestData = new[]
        {
            new object[]
            {
                2129920,
@"....#
#..#.
#..##
..#..
#...."
            }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoTestData = new[]
        {
            new object[]
            {
                99,
                10,
@"....#
#..#.
#..##
..#..
#...."
            }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(int expected, int iterations, string input)
        {
            var actual = this.subject.PuzzleTwo(input, iterations);

            Assert.Equal(expected, actual);
        }
    }
}