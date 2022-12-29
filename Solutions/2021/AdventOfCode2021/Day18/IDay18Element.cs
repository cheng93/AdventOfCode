namespace AdventOfCode2021.Day18;

public interface IDay18Element
{
    int Depth { get; set; }

    int Magnitude { get; }

    Day18ExplodeResult Explode();

    bool Split();

    public static IEnumerable<IDay18Element> Create(IEnumerator<char> enumerator)
    {
        int? elementNumber = null;
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            if (int.TryParse(current.ToString(), out var number))
            {
                elementNumber = (elementNumber ?? 0) * 10 + number;
            }
            else if (current == '[')
            {
                var elements = Create(enumerator).ToArray();
                yield return new Day18Pair(elements[0], elements[1]);
            }
            else if (elementNumber.HasValue)
            {
                yield return new Day18Number(elementNumber.Value);
            }

            if (current == ']')
            {
                yield break;
            }
            else if (current == ',')
            {
                elementNumber = null;
            }
        }
    }
}

public static class Day18ElementExtensions
{
    public static IDay18Element AddRight(this IDay18Element left, int right)
    {
        if (left is Day18Number number)
        {
            return new Day18Number(number.Magnitude + right) { Depth = number.Depth };
        }
        else if (left is Day18Pair pair)
        {
            return new Day18Pair(pair.Left, pair.Right.AddRight(right));
        }
        throw new ArgumentException(nameof(left));
    }

    public static IDay18Element AddLeft(this IDay18Element element, int left)
    {
        if (element is Day18Number number)
        {
            return new Day18Number(number.Magnitude + left) { Depth = number.Depth };
        }
        else if (element is Day18Pair pair)
        {
            return new Day18Pair(pair.Left.AddLeft(left), pair.Right);
        }
        throw new ArgumentException(nameof(element));
    }

    public static IDay18Element Add(this IDay18Element left, IDay18Element right)
    {
        var pair = new Day18Pair(left, right);
        while (true)
        {
            var explodeResult = pair.Explode();
            if (explodeResult.Exploded)
            {
                continue;
            }
            var splitResult = pair.Split();
            if (splitResult)
            {
                continue;
            }

            return pair;
        }
    }
}

public record Day18Number : IDay18Element
{
    public Day18Number(int magnitude)
    {
        Magnitude = magnitude;
    }

    public int Depth { get; set; }

    public int Magnitude { get; }

    public Day18ExplodeResult Explode() => Day18ExplodeResult.NoExplosion();

    public bool Split() => Magnitude >= 10;

    public override string ToString() => this.Magnitude.ToString();
}

public record Day18Pair : IDay18Element
{
    public Day18Pair(IDay18Element left, IDay18Element right)
    {
        Left = left;
        Right = right;
    }

    private int _depth;
    public int Depth
    {
        get => _depth;
        set
        {
            _depth = value;
            Left.Depth = value + 1;
            Right.Depth = value + 1;
        }
    }

    public int Magnitude => Left.Magnitude * 3 + Right.Magnitude * 2;

    private IDay18Element _left = default!;
    public IDay18Element Left
    {
        get => _left;
        private set
        {
            _left = value;
            _left.Depth = this.Depth + 1;
        }
    }

    private IDay18Element _right = default!;
    public IDay18Element Right
    {
        get => _right;
        private set
        {
            _right = value;
            _right.Depth = this.Depth + 1;
        }
    }

    public Day18ExplodeResult Explode()
    {
        if (Depth >= 3
            && Left is Day18Pair leftPair
            && leftPair.Left is Day18Number leftPairLeftNumber
            && leftPair.Right is Day18Number leftPairRightNumber)
        {
            Left = new Day18Number(0);
            Right = Right.AddLeft(leftPairRightNumber.Magnitude);
            var leftResult = Day18ExplodeResult.Explosion(leftPairLeftNumber.Magnitude, leftPairRightNumber.Magnitude);
            leftResult.Right = null;
            return leftResult;
        }

        var result = Left.Explode();
        if (result.Exploded)
        {
            if (result.Right.HasValue)
            {
                Right = Right.AddLeft(result.Right.Value);
                result.Right = null;
            }
            return result;
        }


        if (Depth >= 3
            && Right is Day18Pair rightPair
            && rightPair.Left is Day18Number rightPairLeftNumber
            && rightPair.Right is Day18Number rightPairRightNumber)
        {
            Right = new Day18Number(0);
            Left = Left.AddRight(rightPairLeftNumber.Magnitude);
            var rightResult = Day18ExplodeResult.Explosion(rightPairLeftNumber.Magnitude, rightPairRightNumber.Magnitude);
            rightResult.Left = null;
            return rightResult;
        }

        result = Right.Explode();
        if (result.Exploded)
        {
            if (result.Left.HasValue)
            {
                Left = Left.AddRight(result.Left.Value);
                result.Left = null;
            }
        }

        return result;
    }

    public bool Split()
    {
        var result = Left.Split();
        if (result)
        {
            if (Left is Day18Number leftNumber)
            {
                Left = new Day18Pair(
                    new Day18Number(leftNumber.Magnitude / 2),
                    new Day18Number((leftNumber.Magnitude + 1) / 2));
            }
            return true;
        }

        result = Right.Split();
        if (result)
        {
            if (Right is Day18Number rightNumber)
            {
                Right = new Day18Pair(
                    new Day18Number(rightNumber.Magnitude / 2),
                    new Day18Number((rightNumber.Magnitude + 1) / 2));
            }
        }

        return result;
    }

    public override string ToString()
        => $"[{Left},{Right}]";
}