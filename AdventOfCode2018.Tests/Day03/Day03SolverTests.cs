
namespace AdventOfCode2018.Tests.Day03
{
    using AdventOfCode2018.Day03;
    using Xunit;

    public class Day03SolverTests
    {
        private readonly Day03Solver subject = new Day03Solver();

        [Theory]
        [InlineData(4, "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2")]
        public void PuzzleOne(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2")]
        public void PuzzleTwo(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}