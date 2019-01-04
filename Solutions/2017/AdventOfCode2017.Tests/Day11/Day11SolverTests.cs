namespace AdventOfCode2017.Tests.Day11
{
    using AdventOfCode2017.Day11;
    using Xunit;

    public class Day11SolverTests
    {
        private Day11Solver subject = new Day11Solver();

        [Theory]
        [InlineData(3, "ne,ne,ne")]
        [InlineData(0, "ne,ne,sw,sw")]
        [InlineData(2, "ne,ne,s,s")]
        [InlineData(3, "se,sw,se,sw,sw")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "ne,ne,ne")]
        [InlineData(2, "ne,ne,sw,sw")]
        [InlineData(2, "ne,ne,s,s")]
        [InlineData(3, "se,sw,se,sw,sw")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}