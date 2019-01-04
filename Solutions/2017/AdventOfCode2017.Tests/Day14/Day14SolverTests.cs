namespace AdventOfCode2017.Tests.Day14
{
    using AdventOfCode2017.Day14;
    using Xunit;

    public class Day14SolverTests
    {
        private Day14Solver subject = new Day14Solver();

        [Theory]
        [InlineData(8108, "flqrgnkx")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1242, "flqrgnkx")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}