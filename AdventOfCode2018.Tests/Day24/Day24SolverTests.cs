namespace AdventOfCode2018.Tests.Day24
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day24;
    using Xunit;

    public class Day24SolverTests
    {
        private readonly Day24Solver subject = new Day24Solver();

        private static string TestData =
@"Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3

Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 5216, TestData }
        };


        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 51, TestData }
        };


        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}