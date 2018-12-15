namespace AdventOfCode2018.Tests.Day14
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day14;
    using Xunit;

    public class Day14SolverTests
    {
        private readonly Day14Solver subject = new Day14Solver();

        [Theory]
        [InlineData("5158916779", 9)]
        [InlineData("0124515891", 5)]
        [InlineData("9251071085", 18)]
        [InlineData("5941429882", 2018)]
        public void PuzzleOne(string expected, int input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(9, "51589")]
        [InlineData(5, "01245")]
        [InlineData(18, "92510")]
        [InlineData(2018, "59414")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}