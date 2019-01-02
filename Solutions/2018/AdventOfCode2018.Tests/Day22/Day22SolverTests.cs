namespace AdventOfCode2018.Tests.Day22
{
    using System.Drawing;
    using AdventOfCode2018.Day22;
    using Xunit;

    public class Day22SolverTests
    {
        private readonly Day22Solver subject = new Day22Solver();

        [Theory]
        [InlineData(114, 510, "10,10")]
        public void PuzzleOne(int expected, int depth, string target)
        {
            var actual = this.subject.PuzzleOne(depth, target);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(45, 510, "10,10")]
        public void PuzzleTwo(int expected, int depth, string target)
        {
            var actual = this.subject.PuzzleTwo(depth, target);

            Assert.Equal(expected, actual);
        }
    }
}