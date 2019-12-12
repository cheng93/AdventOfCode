using AdventOfCode2019.Day12;
using Xunit;

namespace AdventOfCode2019.Tests.Day12
{
    public class Day12SolverTests
    {
        private readonly Day12Solver subject = new Day12Solver();

        [Theory]
        [InlineData(179, 10, "<x=-1, y=0, z=2>", "<x=2, y=-10, z=-7>", "<x=4, y=-8, z=8>", "<x=3, y=5, z=-1>")]
        [InlineData(1940, 100, "<x=-8, y=-10, z=0>", "<x=5, y=5, z=10>", "<x=2, y=-7, z=3>", "<x=9, y=-8, z=-3>")]
        public void PuzzleOne(int expected, int steps, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input, steps);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2772, "<x=-1, y=0, z=2>", "<x=2, y=-10, z=-7>", "<x=4, y=-8, z=8>", "<x=3, y=5, z=-1>")]
        [InlineData(4686774924, "<x=-8, y=-10, z=0>", "<x=5, y=5, z=10>", "<x=2, y=-7, z=3>", "<x=9, y=-8, z=-3>")]
        public void PuzzleTwo(long expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}