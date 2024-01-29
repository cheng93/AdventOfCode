namespace AdventOfCode2015.Day12;

public static class Day12Solver
{
    public static int PuzzleOne(string input)
    {
        var sum = 0;
        var inQuotes = false;
        var str = string.Empty;

        for (var i = 0; i < input.Length - 1; i++)
        {
            var character = input[i];
            if (character == '"')
            {
                inQuotes = !inQuotes;
                continue;
            }

            if (!inQuotes)
            {
                if (character == '-'
                    || (character >= '0' && character <= '9'))
                {
                    str += character;
                }

                var next = input[i + 1];
                if (str.Length > 0 && str != "-"
                    && (next < '0' || next > '9'))
                {
                    sum += int.Parse(str);
                    str = string.Empty;
                }
            }
        }

        return sum;
    }

    public static int PuzzleTwo(string input)
    {
        var stack = new Stack<int>();
        stack.Push(0);
        var valid = new Stack<bool>();
        valid.Push(true);
        var capture = new Stack<char>();
        var inQuotes = false;
        var str = string.Empty;

        for (var i = 0; i < input.Length; i++)
        {
            var character = input[i];

            if (character == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (character == '{')
            {
                stack.Push(0);
                valid.Push(true);
                capture.Push(character);
            }
            else if (character == '}')
            {
                var innerSum = stack.Pop();
                var isValid = valid.Pop();
                capture.Pop();
                if (isValid)
                {
                    var sum = stack.Pop();
                    stack.Push(sum + innerSum);
                }
            }
            else if (character == '[')
            {
                capture.Push(character);
            }
            else if (character == ']')
            {
                capture.Pop();
            }
            else
            {
                if (i == input.Length - 1)
                {
                    break;
                }
                var next = input[i + 1];

                if (!inQuotes)
                {
                    if (character == '-'
                        || (character >= '0' && character <= '9'))
                    {
                        str += character;
                    }

                    if (str.Length > 0 && str != "-"
                        && (next < '0' || next > '9'))
                    {
                        var sum = stack.Pop();
                        stack.Push(sum + int.Parse(str));
                        str = string.Empty;
                    }
                }
                else
                {
                    if (capture.Peek() == '{')
                    {
                        str += character;
                        if (next == '"')
                        {
                            if (str == "red")
                            {
                                valid.Pop();
                                valid.Push(false);
                            }
                            str = string.Empty;
                        }
                    }
                }
            }
        }

        return stack.Pop();
    }
}