namespace AdventOfCode2017.Tests.Day23
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day23;
    using Xunit;

    public class Day23SolverTests
    {
        private Day23Solver subject = new Day23Solver();

        private static string TestData1 =
@"5 1 9 5
7 5 3
2 4 6 8";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 18, TestData1 }
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