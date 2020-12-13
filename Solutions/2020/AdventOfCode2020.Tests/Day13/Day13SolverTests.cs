using AdventOfCode2020.Day13;
using Xunit;

namespace AdventOfCode2020.Tests.Day13
{
    public class Day13SolverTest
    {
        private readonly Day13Solver subject = new Day13Solver();

        [Theory]
        [InlineData(295, "7,13,x,x,59,x,31,19", 939)]
        public void PuzzleOne(int expected, string input, int earliest)
        {
            var actual = this.subject.PuzzleOne(input, earliest);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1068781, "7,13,x,x,59,x,31,19")]
        [InlineData(3417, "17,x,13,19")]
        [InlineData(754018, "67,7,59,61")]
        [InlineData(779210, "67,x,7,59,61")]
        [InlineData(1261476, "67,7,x,59,61")]
        [InlineData(1202161486, "1789,37,47,1889")]
        public void PuzzleTwo(long expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}