namespace AdventOfCode2017.Tests.Day16
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day16;
    using Xunit;

    public class Day16SolverTests
    {
        private Day16Solver subject = new Day16Solver();

        private static string TestData = "s1,x3/4,pe/b";
        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { "baedc", TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(string expected, string input)
        {
            var actual = this.subject.PuzzleOne(input, 5);

            Assert.Equal(expected, actual);
        }
    }
}