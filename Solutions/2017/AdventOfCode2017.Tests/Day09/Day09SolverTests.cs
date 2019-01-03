namespace AdventOfCode2017.Tests.Day09
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day09;
    using Xunit;

    public class Day09SolverTests
    {
        private Day09Solver subject = new Day09Solver();

        [Theory]
        [InlineData(1, "{}")]
        [InlineData(6, "{{{}}}")]
        [InlineData(5, "{{},{}}")]
        [InlineData(16, "{{{},{},{{}}}}")]
        [InlineData(1, "{<a>,<a>,<a>,<a>}")]
        [InlineData(9, "{{<ab>},{<ab>},{<ab>},{<ab>}}")]
        [InlineData(9, "{{<!!>},{<!!>},{<!!>},{<!!>}}")]
        [InlineData(3, "{{<a!>},{<a!>},{<a!>},{<ab>}}")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, "<>")]
        [InlineData(17, "<random characters>")]
        [InlineData(3, "<<<<>")]
        [InlineData(2, "<{!>}>")]
        [InlineData(0, "<!!>")]
        [InlineData(0, "<!!!>>")]
        [InlineData(10, "<{o\"i!a,<{i<a>")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}