namespace AdventOfCode2024.Day24;

public class Day24Gate
{
    // ntg XOR fgs -> mjb
    public Day24Gate(string input)
    {
        var splits = input.Split(" ");
        Input = new(splits[0], splits[1], splits[2]);
        Output = splits[4];
    }

    public Day24Input Input { get; }

    public string Left => Input.Left;

    public string Logic => Input.Logic;

    public string Output { get; private set; }

    public string Right => Input.Right;

    public bool GetValue(Dictionary<string, bool> values)
        => Logic switch
        {
            "AND" => values[Left] && values[Right],
            "OR" => values[Left] || values[Right],
            "XOR" => values[Left] ^ values[Right],
            _ => throw new Exception()
        };

    public void Swap(Day24Gate other)
    {
        (Output, other.Output) = (other.Output, Output);
    }
}

public record Day24Input(string Left, string Logic, string Right)
{
    public virtual bool Equals(Day24Input? other)
    {
        if (other == null)
        {
            return false;
        }
        return Logic.Equals(other.Logic)
            && (Left.Equals(other.Left) && Right.Equals(other.Right)
                || Left.Equals(other.Right) && Right.Equals(other.Left));
    }

    public override int GetHashCode()
    {
        var ordered = new[] { Left, Right }.OrderBy(x => x);
        return HashCode.Combine(
            EqualityComparer<Type>.Default.GetHashCode(EqualityContract),
            EqualityComparer<string>.Default.GetHashCode(Logic),
            EqualityComparer<string>.Default.GetHashCode(ordered.First()),
            EqualityComparer<string>.Default.GetHashCode(ordered.Last())
        );
    }
}