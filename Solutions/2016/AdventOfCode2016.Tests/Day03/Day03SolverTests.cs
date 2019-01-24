namespace AdventOfCode2016.Tests.Day03
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day03;
    using Xunit;

    public class Day03SolverTests
    {
        private readonly Day03Solver subject = new Day03Solver();

        private static string TestData1 =
@"5 10 25
5 10 15
5 10 14";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 1, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static string TestData2 =
@"101 301 501
102 302 502
103 303 503
201 401 601
202 402 602
203 403 603";

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 3, TestData1 },
            new object[] { 6, TestData2 }
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