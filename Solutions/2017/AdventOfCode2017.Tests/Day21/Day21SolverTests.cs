namespace AdventOfCode2017.Tests.Day21
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day21;
    using Xunit;

    public class Day21SolverTests
    {
        private readonly Day21Solver subject = new Day21Solver();

        private static string TestData =
@"../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 12, TestData, 2 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input, int iterations)
        {
            var actual = this.subject.PuzzleOne(input, iterations);

            Assert.Equal(expected, actual);
        }
    }
}