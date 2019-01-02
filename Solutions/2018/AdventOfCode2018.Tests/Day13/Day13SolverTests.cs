namespace AdventOfCode2018.Tests.Day13
{
    using System.Collections.Generic;
    using System.Drawing;
    using AdventOfCode2018.Day13;
    using Xunit;

    public class Day13SolverTests
    {
        private readonly Day13Solver subject = new Day13Solver();

        private static readonly string TestData1 =
@"/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/   ";

        public static readonly IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { new Point(7, 3), TestData1}
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(Point expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static readonly string TestData2 =
@"/>-<\  
|   |  
| /<+-\
| | | v
\>+</ |
  |   ^
  \<->/";

        public static readonly IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { new Point(6, 4), TestData2}
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(Point expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}