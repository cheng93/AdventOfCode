using AdventOfCode2019.Day03;
using Xunit;

namespace AdventOfCode2019.Tests.Day03
{
    public class Day03SolverTests
    {
        private readonly Day03Solver subject = new Day03Solver();

        [Theory]
        [InlineData(6, "R8,U5,L5,D3", "U7,R6,D4,L4")]
        [InlineData(159, "R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83")]
        [InlineData(135, "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")]
        public void PuzzleOne(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(30, "R8,U5,L5,D3", "U7,R6,D4,L4")]
        [InlineData(610, "R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83")]
        [InlineData(410, "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")]
        public void PuzzleTwo(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}