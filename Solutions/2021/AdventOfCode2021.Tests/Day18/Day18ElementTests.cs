namespace AdventOfCode2021.Day18.Tests;

public class Day18ElementTests
{
    [Theory]
    [InlineData("[1,2]")]
    [InlineData("[[1,2],3]")]
    [InlineData("[9,[8,7]]")]
    [InlineData("[[1,9],[8,5]]")]
    [InlineData("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]")]
    [InlineData("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]")]
    [InlineData("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]")]
    public void Create(string input)
    {
        var elements = IDay18Element.Create(input.GetEnumerator());

        var actual = elements.First();

        Assert.Equal(input, actual.ToString());
    }

    [Theory]
    [InlineData("[[[[0,9],2],3],4]", "[[[[[9,8],1],2],3],4]")]
    [InlineData("[7,[6,[5,[7,0]]]]", "[7,[6,[5,[4,[3,2]]]]]")]
    [InlineData("[[6,[5,[7,0]]],3]", "[[6,[5,[4,[3,2]]]],1]")]
    [InlineData("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]")]
    [InlineData("[[3,[2,[8,0]]],[9,[5,[7,0]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
    [InlineData("[[[[0,7],4],[7,[[8,4],9]]],[1,1]]", "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]")]
    [InlineData("[[[[0,7],4],[15,[0,13]]],[1,1]]", "[[[[0,7],4],[7,[[8,4],9]]],[1,1]]")]
    public void Explode(string expected, string input)
    {
        var elements = IDay18Element.Create(input.GetEnumerator());

        var first = elements.First();
        var result = first.Explode();

        Assert.Equal(expected, first.ToString());
    }

    [Theory]
    [InlineData("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", "[[[[0,7],4],[15,[0,13]]],[1,1]]")]
    [InlineData("[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]", "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]")]
    public void Split(string expected, string input)
    {
        var elements = IDay18Element.Create(input.GetEnumerator());

        var first = elements.First();
        var result = first.Split();

        Assert.Equal(expected, first.ToString());
    }

    [Theory]
    [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", "[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]")]
    public void Add(string expected, string left, string right)
    {
        var leftElement = IDay18Element.Create(left.GetEnumerator()).First();
        var rightElement = IDay18Element.Create(right.GetEnumerator()).First();

        var result = leftElement.Add(rightElement);

        Assert.Equal(expected, result.ToString());
    }
}