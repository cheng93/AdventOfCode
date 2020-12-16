using AdventOfCode2020.Day16;
using Xunit;

namespace AdventOfCode2020.Tests.Day16
{
    public class Day16SolverTests
    {
        private readonly Day16Solver subject = new Day16Solver();

        public static TheoryData<int, string> PuzzleOneTestData
            = new TheoryData<int, string>()
            {
                {
                    71,
@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12"
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(long expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}