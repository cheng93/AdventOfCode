namespace AdventOfCode2017.Tests.Day10
{
    using System.Linq;
    using AdventOfCode2017.Day10;
    using Xunit;

    public class Day10SolverTests
    {
        private Day10Solver subject = new Day10Solver();

        [Theory]
        [InlineData(12, "3,4,1,5")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input, Enumerable.Range(0, 5));

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("a2582a3a0e66e6e86e3812dcb672a272", "")]
        [InlineData("33efeb34ea91902bb2f59c9920caa6cd", "AoC 2017")]
        [InlineData("3efbe78a8d82f29979031a4aa0b16a9d", "1,2,3")]
        [InlineData("63960835bcdc130f0b66d7ff4f6a5a8e", "1,2,4")]
        public void PuzzleTwo(string expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}