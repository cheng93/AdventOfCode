namespace AdventOfCode2018.Tests.Day11
{
    using System.Collections.Generic;
    using System.Drawing;
    using AdventOfCode2018.Day11;
    using Xunit;

    public class Day11SolverTests
    {
        private readonly Day11Solver subject = new Day11Solver();

        public static readonly IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] {  new Point(33, 45), 18},
            new object[] {  new Point(21, 61), 42}
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(Point expected, int input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
        public static readonly IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] {  (new Point(90, 269), 16), 18},
            new object[] {  (new Point(232, 251), 12), 42}
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo((Point Point, int Size) expected, int input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}