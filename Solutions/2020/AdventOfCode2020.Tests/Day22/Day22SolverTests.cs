using AdventOfCode2020.Day22;
using Xunit;

namespace AdventOfCode2020.Tests.Day22
{
    public class Day22SolverTests
    {
        private readonly Day22Solver subject = new Day22Solver();

        public static TheoryData<int, string> PuzzleOneTestData
            = new TheoryData<int, string>()
            {
                {
                    306,
@"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10"
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<int, string> PuzzleTwoTestData
            = new TheoryData<int, string>()
            {
                {
                    291,
@"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10"
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}