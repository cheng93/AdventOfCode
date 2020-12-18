using AdventOfCode2020.Day18;
using Xunit;

namespace AdventOfCode2020.Tests.Day18
{
    public class Day18AdvancedEquationTests
    {

        [Theory]
        [InlineData(231, "1 + 2 * 3 + 4 * 5 + 6")]
        [InlineData(51, "1 + (2 * 3) + (4 * (5 + 6))")]
        [InlineData(46, "2 * 3 + (4 * 5)")]
        [InlineData(1445, "5 + (8 * 3 + 9 + 3 * 4 * 3)")]
        [InlineData(669060, "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))")]
        [InlineData(23340, "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")]
        public void Solve(long expected, string input)
        {
            var actual = new Day18AdvancedEquation(input).Solve();

            Assert.Equal(expected, actual);
        }
    }
}