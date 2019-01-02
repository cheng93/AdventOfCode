namespace AdventOfCode2017.Tests.Day06
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day06;
    using Xunit;

    public class Day06SolverTests
    {
        private readonly Day06Solver subject = new Day06Solver();

        [Theory]
        [InlineData(5, "0 2 7 0")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, "0 2 7 0")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}