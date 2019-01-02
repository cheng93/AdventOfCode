using AdventOfCode2018.Day05;
using Xunit;

namespace AdventOfCode2018.Tests.Day05
{
    public class Day05SolverTests
    {
        private readonly Day05Solver subject = new Day05Solver();

        [Theory]
        [InlineData(0, "aA")]
        [InlineData(0, "abBA")]
        [InlineData(4, "abAB")]
        [InlineData(6, "aabAAB")]
        [InlineData(10, "dabAcCaCBAcCcaDA")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, "abBA")]
        [InlineData(0, "abAB")]
        [InlineData(0, "aabAAB")]
        [InlineData(4, "dabAcCaCBAcCcaDA")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}