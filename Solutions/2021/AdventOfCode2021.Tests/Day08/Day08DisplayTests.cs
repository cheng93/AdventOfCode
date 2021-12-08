namespace AdventOfCode2021.Day08.Tests;

public class Day08DisplayTests
{
    [Theory]
    [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab", 'd', 'e', 'a', 'f', 'g', 'b', 'c')]
    public void Create(string input, params char[] character)
    {
        var actual = Day08Display.Create(input);

        Assert.Equal(character[0], actual.Top);
        Assert.Equal(character[1], actual.TopLeft);
        Assert.Equal(character[2], actual.TopRight);
        Assert.Equal(character[3], actual.Middle);
        Assert.Equal(character[4], actual.BottomLeft);
        Assert.Equal(character[5], actual.BottomRight);
        Assert.Equal(character[6], actual.Bottom);
    }


    [Theory]
    [InlineData(0, "degcba")]
    [InlineData(1, "ab")]
    [InlineData(2, "dafgc")]
    [InlineData(3, "dafbc")]
    [InlineData(4, "efab")]
    [InlineData(5, "defbc")]
    [InlineData(6, "degcbf")]
    [InlineData(7, "dab")]
    [InlineData(8, "deafgbc")]
    [InlineData(9, "defabc")]
    public void GetValue(int expected, string input)
    {
        var display = new Day08Display('d', 'e', 'a', 'f', 'g', 'b', 'c');
        var actual = display.GetValue(input);

        Assert.Equal(expected, actual);
    }
}