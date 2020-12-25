using AdventOfCode2020.Day25;
using Xunit;

namespace AdventOfCode2020.Tests.Day25
{
    public class Day25SolverTest
    {
        private readonly Day25Solver subject = new Day25Solver();

        [Theory]
        [InlineData(14897079, 5764801, 17807724)]
        public void PuzzleOne(long expected, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}