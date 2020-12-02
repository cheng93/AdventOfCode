using AdventOfCode2020.Day02;
using Xunit;

namespace AdventOfCode2020.Tests.Day02
{
    public class Day02SolverTests
    {
        private readonly Day02Solver subject = new Day02Solver();

        [Theory]
        [InlineData(2, "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc")]
        public void PuzzleOne(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc")]
        public void PuzzleTwo(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}