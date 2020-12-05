using AdventOfCode2020.Day05;
using Xunit;

namespace AdventOfCode2020.Tests.Day05
{
    public class Day05SolverTests
    {
        private readonly Day05Solver subject = new Day05Solver();

        [Theory]
        [InlineData(820, "FBFBBFFRLR", "BFFFBBFRRR", "FFFBBBFRRR", "BBFFBBFRLL")]
        public void Scan(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}