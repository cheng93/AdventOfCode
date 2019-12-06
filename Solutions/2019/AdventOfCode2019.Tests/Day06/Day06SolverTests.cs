using AdventOfCode2019.Day06;
using Xunit;

namespace AdventOfCode2019.Tests.Day06
{
    public class Day06SolverTests
    {
        private readonly Day06Solver subject = new Day06Solver();

        [Theory]
        [InlineData(42, "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L")]
        [InlineData(42, "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "COM)B")]
        public void PuzzleOne(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN")]
        [InlineData(4, "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN", "COM)B")]
        public void PuzzleTwo(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}