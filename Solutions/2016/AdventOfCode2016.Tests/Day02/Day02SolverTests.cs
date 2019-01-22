namespace AdventOfCode2016.Tests.Day02
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day02;
    using Xunit;

    public class Day02SolverTests
    {
        private Day02Solver subject = new Day02Solver();

        private static string TestData =
@"ULL
RRDDD
LURDL
UUUUD";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { "1985", TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(string expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { "5DB3", TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(string expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}