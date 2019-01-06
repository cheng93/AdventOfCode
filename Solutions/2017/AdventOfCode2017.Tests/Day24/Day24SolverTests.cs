namespace AdventOfCode2017.Tests.Day24
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day24;
    using Xunit;

    public class Day24SolverTests
    {
        private readonly Day24Solver subject = new Day24Solver();

        private static string TestData =
@"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 31, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 19, TestData }
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