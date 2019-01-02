namespace AdventOfCode2018.Tests.Day12
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day12;
    using Xunit;

    public class Day12SolverTests
    {
        private readonly Day12Solver subject = new Day12Solver();

        private static string TestData =
@"initial state: #..#.#..##......###...###

...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 325, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(long expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}