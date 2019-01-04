namespace AdventOfCode2017.Tests.Day17
{
    using AdventOfCode2017.Day17;
    using Xunit;

    public class Day17SolverTests
    {
        private Day17Solver subject = new Day17Solver();

        [Theory]
        [InlineData(638, 3)]
        public void PuzzleOne(int expected, int input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}