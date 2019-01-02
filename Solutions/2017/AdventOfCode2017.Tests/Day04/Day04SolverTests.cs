namespace AdventOfCode2017.Tests.Day04
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day04;
    using Xunit;

    public class Day04SolverTests
    {
        private readonly Day04Solver subject = new Day04Solver();

        private static string TestData1 =
@"aa bb cc dd ee
aa bb cc dd aa
aa bb cc dd aaa";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 2, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static string TestData2 =
@"abcde fghij
abcde xyz ecdab
a ab abc abd abf abj
iiii oiii ooii oooi oooo
oiii ioii iioi iiio";

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 3, TestData2 }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}