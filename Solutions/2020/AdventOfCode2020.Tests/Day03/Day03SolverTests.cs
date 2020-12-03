using AdventOfCode2020.Day03;
using Xunit;

namespace AdventOfCode2020.Tests.Day03
{
    public class Day03SolverTests
    {
        private readonly Day03Solver subject = new Day03Solver();

        public static TheoryData<int, string> PuzzleOneTestData
            = new TheoryData<int, string>()
            {
                {
                    7,
@"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#"
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<long, string> PuzzleTwoTestData
            = new TheoryData<long, string>()
            {
                {
                    336,
@"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#"
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(long expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}