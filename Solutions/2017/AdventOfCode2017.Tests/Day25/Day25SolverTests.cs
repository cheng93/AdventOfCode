namespace AdventOfCode2017.Tests.Day25
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day25;
    using Xunit;

    public class Day25SolverTests
    {
        private readonly Day25Solver subject = new Day25Solver();

        private static string TestData =
@"Begin in state A.
Perform a diagnostic checksum after 6 steps.

In state A:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state B.
  If the current value is 1:
    - Write the value 0.
    - Move one slot to the left.
    - Continue with state B.

In state B:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the left.
    - Continue with state A.
  If the current value is 1:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state A.";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 3, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}