namespace AdventOfCode2016.Tests.Day01
{
    using AdventOfCode2016.Day01;
    using Xunit;

    public class Day01SolverTests
    {
        private readonly Day01Solver subject = new Day01Solver();

        [Theory]
        [InlineData(5, "R2, L3")]
        [InlineData(2, "R2, R2, R2")]
        [InlineData(12, "R5, L5, R5, R3")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, "R8, R4, R4, R8")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}