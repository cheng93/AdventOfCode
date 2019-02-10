namespace AdventOfCode2016.Tests.Day08
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day08;
    using Xunit;

    public class Day08SolverTests
    {
        private Day08Solver subject = new Day08Solver();

        private static string TestData =
@"rect 3x2
rotate column x=1 by 1
rotate row y=0 by 4
rotate column x=1 by 1";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 6, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}