using System.Collections.Generic;
using AdventOfCode2020.Day24;
using Xunit;

namespace AdventOfCode2020.Tests.Day24
{
    public class Day24SolverTests
    {
        private readonly Day24Solver subject = new Day24Solver();

        public static TheoryData<int, IEnumerable<string>> PuzzleOneTestData
            = new TheoryData<int, IEnumerable<string>>()
            {
                {
                    10,
                    new []
                    {
"sesenwnenenewseeswwswswwnenewsewsw",
"neeenesenwnwwswnenewnwwsewnenwseswesw",
"seswneswswsenwwnwse",
"nwnwneseeswswnenewneswwnewseswneseene",
"swweswneswnenwsewnwneneseenw",
"eesenwseswswnenwswnwnwsewwnwsene",
"sewnenenenesenwsewnenwwwse",
"wenwwweseeeweswwwnwwe",
"wsweesenenewnwwnwsenewsenwwsesesenwne",
"neeswseenwwswnwswswnw",
"nenwswwsewswnenenewsenwsenwnesesenew",
"enewnwewneswsewnwswenweswnenwsenwsw",
"sweneswneswneneenwnewenewwneswswnese",
"swwesenesewenwneswnwwneseswwne",
"enesenwswwswneneswsenwnewswseenwsese",
"wnwnesenesenenwwnenwsewesewsesesew",
"nenewswnwewswnenesenwnesewesw",
"eneswnwswnwsenenwnwnwwseeswneewsenese",
"neswnwewnwnwseenwseesewsenwsweewe",
"wseweeenwnesenwwwswnew",
                    }
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<int, IEnumerable<string>> PuzzleTwoTestData
            = new TheoryData<int, IEnumerable<string>>()
            {
                {
                    2208,
                    new []
                    {
"sesenwnenenewseeswwswswwnenewsewsw",
"neeenesenwnwwswnenewnwwsewnenwseswesw",
"seswneswswsenwwnwse",
"nwnwneseeswswnenewneswwnewseswneseene",
"swweswneswnenwsewnwneneseenw",
"eesenwseswswnenwswnwnwsewwnwsene",
"sewnenenenesenwsewnenwwwse",
"wenwwweseeeweswwwnwwe",
"wsweesenenewnwwnwsenewsenwwsesesenwne",
"neeswseenwwswnwswswnw",
"nenwswwsewswnenenewsenwsenwnesesenew",
"enewnwewneswsewnwswenweswnenwsenwsw",
"sweneswneswneneenwnewenewwneswswnese",
"swwesenesewenwneswnwwneseswwne",
"enesenwswwswneneswsenwnewswseenwsese",
"wnwnesenesenenwwnenwsewesewsesesew",
"nenewswnwewswnenesenwnesewesw",
"eneswnwswnwsenenwnwnwwseeswneewsenese",
"neswnwewnwnwseenwseesewsenwsweewe",
"wseweeenwnesenwwwswnew",
                    }
                },
            };


        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}