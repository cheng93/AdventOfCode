namespace AdventOfCode2023.Day07;

public class Day07Hand(string input) : IComparable<Day07Hand>
{
    public virtual string Labels => "23456789TJQKA";

    public string Value => input;

    public int CompareTo(Day07Hand? other)
    {
        if (other == null)
        {
            return -1;
        }
        if (Value == other.Value)
        {
            return 0;
        }

        var thisHandType = GetHandType();
        var otherHandType = other.GetHandType();
        if (thisHandType != otherHandType)
        {
            return thisHandType.CompareTo(otherHandType);
        }

        for (var i = 0; i < 5; i++)
        {
            var thisLabel = Value[i];
            var otherLabel = other.Value[i];
            if (thisLabel != otherLabel)
            {
                return Labels.IndexOf(thisLabel).CompareTo(Labels.IndexOf(otherLabel));
            }
        }

        throw new Exception();
    }

    public virtual int GetHandType()
    {
        var ordered = Value
            .OrderByDescending(x => Value.Count(letter => letter == x))
            .ThenBy(x => x);
        var mask = string.Empty;
        var current = ordered.First();
        var i = 0;

        foreach (var letter in ordered)
        {
            if (current != letter)
            {
                current = letter;
                i++;
            }
            mask += i;
        }

        return mask switch
        {
            "00000" => 7,
            "00001" => 6,
            "00011" => 5,
            "00012" => 4,
            "00112" => 3,
            "00123" => 2,
            "01234" => 1,
            _ => throw new Exception()
        };
    }
}