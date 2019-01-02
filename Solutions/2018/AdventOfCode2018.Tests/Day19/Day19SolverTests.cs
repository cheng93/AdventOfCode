namespace AdventOfCode2018.Tests.Day19
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day19;
    using Xunit;

    public class Day19SolverTests
    {
        private readonly Day19Solver subject = new Day19Solver();

        private static readonly string TestData =
@"#ip 0
seti 5 0 1
seti 6 0 2
addi 0 1 0
addr 1 2 3
setr 1 0 0
seti 8 0 4
seti 9 0 5";

        public static readonly IEnumerable<object[]> PuzzleOneData = new[]
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

        public static readonly IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 6, TestData }
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