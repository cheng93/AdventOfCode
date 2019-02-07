namespace AdventOfCode2016.Tests.Day07
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day07;
    using Xunit;

    public class Day07SolverTests
    {
        private readonly Day07Solver subject = new Day07Solver();

        private static string TestData1 =
@"abba[mnop]qrst
abcd[bddb]xyyx
aaaa[qwer]tyui
ioxxoj[asdfgh]zxcvbn";

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
@"aba[bab]xyz
xyx[xyx]xyx
aaa[kek]eke
zazbz[bzb]cdb";

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