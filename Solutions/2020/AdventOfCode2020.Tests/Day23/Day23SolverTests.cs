using AdventOfCode2020.Day23;
using Xunit;

namespace AdventOfCode2020.Tests.Day23
{
    public class Day23SolverTest
    {
        private readonly Day23Solver subject = new Day23Solver();

        [Theory]
        [InlineData("67384529", "389125467")]
        public void PuzzleOne(string expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(149245887792, "389125467")]
        public void PuzzleTwo(long expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}