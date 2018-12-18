namespace AdventOfCode2018.Tests.Day18
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day18;
    using Xunit;

    public class Day18SolverTests
    {
        private readonly Day18Solver subject = new Day18Solver();

        private static string TestData =
@".#.#...|#.
.....#|##|
.|..|...#.
..|#.....#
#.#|||#|#|
...#.||...
.|....|...
||...#|.#|
|.||||..|.
...#.|..|.";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 1147, TestData}
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input, 10);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 0, TestData}
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input, 10);

            Assert.Equal(expected, actual);
        }
    }
}