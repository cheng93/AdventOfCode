using AdventOfCode2020.Day05;
using Xunit;

namespace AdventOfCode2020.Tests.Day05
{
    public class Day05ScannerTests
    {
        private readonly Day05Scanner subject = new Day05Scanner();

        [Theory]
        [InlineData(357, "FBFBBFFRLR")]
        [InlineData(567, "BFFFBBFRRR")]
        [InlineData(119, "FFFBBBFRRR")]
        [InlineData(820, "BBFFBBFRLL")]
        public void Scan(int expected, string input)
        {
            var actual = this.subject.Scan(input);

            Assert.Equal(expected, actual);
        }
    }
}