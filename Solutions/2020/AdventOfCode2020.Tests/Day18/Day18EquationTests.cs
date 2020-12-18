using AdventOfCode2020.Day18;
using Xunit;

namespace AdventOfCode2020.Tests.Day18
{
    public class Day18EquationTests
    {

        [Theory]
        [InlineData(71, "1 + 2 * 3 + 4 * 5 + 6")]
        [InlineData(51, "1 + (2 * 3) + (4 * (5 + 6))")]
        [InlineData(26, "2 * 3 + (4 * 5)")]
        [InlineData(437, "5 + (8 * 3 + 9 + 3 * 4 * 3)")]
        [InlineData(12240, "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))")]
        [InlineData(13632, "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")]
        public void Solve(long expected, string input)
        {
            var actual = new Day18Equation(input).Solve();

            Assert.Equal(expected, actual);
        }
    }
}