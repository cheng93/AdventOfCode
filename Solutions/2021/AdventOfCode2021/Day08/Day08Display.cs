namespace AdventOfCode2021.Day08;

public record Day08Display(char Top, char TopLeft, char TopRight, char Middle, char BottomLeft, char BottomRight, char Bottom)
{
    public int GetValue(string input)
    {
        switch (input.Length)
        {
            case 2:
                return 1;
            case 3:
                return 7;
            case 4:
                return 4;
            case 7:
                return 8;
            case 5:
                if (input.Contains(TopRight))
                {
                    if (input.Contains(BottomLeft))
                    {
                        return 2;
                    }
                    return 3;
                }
                return 5;
            case 6:
                if (!input.Contains(Middle))
                {
                    return 0;
                }
                else if (!input.Contains(TopRight))
                {
                    return 6;
                }
                else
                {
                    return 9;
                }
        }

        throw new Exception();
    }

    //example: acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab
    public static Day08Display Create(string input)
    {
        var splits = input.Split(" ").ToArray();

        var characters = new HashSet<char>("abcdefgh");
        var top = new HashSet<char>(characters);
        var topLeft = new HashSet<char>(characters);
        var topRight = new HashSet<char>(characters);
        var middle = new HashSet<char>(characters);
        var bottomLeft = new HashSet<char>(characters);
        var bottomRight = new HashSet<char>(characters);
        var bottom = new HashSet<char>(characters);

        foreach (var split in splits.OrderBy(x => x.Length))
        {
            var set = new HashSet<char>(split.ToArray());
            if (split.Length == 2)
            {
                topRight.IntersectWith(set);
                bottomRight.IntersectWith(topRight);
            }
            else if (split.Length == 3)
            {
                top.IntersectWith(set);
                top.ExceptWith(topRight);
            }
            else if (split.Length == 4)
            {
                topLeft.IntersectWith(set);
                topLeft.ExceptWith(topRight);
                middle.IntersectWith(topLeft);
            }
            else if (split.Length == 7)
            {
                bottomLeft.ExceptWith(topRight);
                bottomLeft.ExceptWith(top);
                bottomLeft.ExceptWith(topLeft);
                bottom.IntersectWith(bottomLeft);
            }
        }

        foreach (var split in splits.Where(x => x.Length == 6))
        {
            var set = new HashSet<char>(split.ToArray());
            var missingSet = characters.Except(set);
            var missing = missingSet.First();

            if (middle.Contains(missing))
            {
                middle.IntersectWith(missingSet);
                topRight.ExceptWith(middle);
            }
            else if (topRight.Contains(missing))
            {
                topRight.IntersectWith(missingSet);
                bottomRight.ExceptWith(topRight);
            }
            else
            {
                bottomLeft.IntersectWith(missingSet);
                bottom.ExceptWith(bottomLeft);
            }
        }

        return new Day08Display(
            top.First(),
            topLeft.First(),
            topRight.First(),
            middle.First(),
            bottomLeft.First(),
            bottomRight.First(),
            bottom.First());
    }
}