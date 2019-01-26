namespace AdventOfCode2016.Tests.Day05
{
    using AdventOfCode2016.Day05;
    using Xunit;

    public class Day05SolverTests
    {
        private readonly Day05Solver subject = new Day05Solver();

        [Theory]
        [InlineData("18f47a30", "abc")]
        public void PuzzleOne(string expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("05ace8e3", "abc")]
        public void PuzzleTwo(string expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}