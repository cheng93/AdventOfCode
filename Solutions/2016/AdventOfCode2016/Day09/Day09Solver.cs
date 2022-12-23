namespace AdventOfCode2016.Day09;

public class Day09Solver
{
    public static int PuzzleOne(string input)
    {
        var next = 0;
        var repeat = 0;
        var inMarker = false;
        var pastX = false;
        var decompressed = string.Empty;

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (c == '(')
            {
                inMarker = true;
            }
            else if (c == ')')
            {
                var from = i + 1;
                var to = from + next;
                var slice = input[from..to];
                for (var j = 0; j < repeat; j++)
                {
                    decompressed += slice;
                }
                inMarker = false;
                pastX = false;
                i += next;
                next = 0;
                repeat = 0;
            }
            else if (inMarker)
            {
                if (int.TryParse(c.ToString(), out var parsed))
                {
                    if (pastX)
                    {
                        repeat = repeat * 10 + parsed;
                    }
                    else
                    {
                        next = next * 10 + parsed;
                    }
                }
                else
                {
                    pastX = true;
                }
            }
            else
            {
                decompressed += c;
            }
        }

        return decompressed.Length;
    }

    public static long PuzzleTwo(string input)
    {
        var next = 0;
        var repeat = 0;
        var markerStart = 0;
        var inMarker = false;
        var pastX = false;
        var count = 0L;

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (c == '(')
            {
                inMarker = true;
                markerStart = i;
            }
            else if (c == ')')
            {
                var from = i + 1;
                var to = from + next;
                var slice = input[from..to];
                count += repeat * PuzzleTwo(slice);
                inMarker = false;
                pastX = false;
                i += next;
                next = 0;
                repeat = 0;
            }
            else if (inMarker)
            {
                if (int.TryParse(c.ToString(), out var parsed))
                {
                    if (pastX)
                    {
                        repeat = repeat * 10 + parsed;
                    }
                    else
                    {
                        next = next * 10 + parsed;
                    }
                }
                else
                {
                    pastX = true;
                }
            }
            else
            {
                count++;
            }
        }

        return count;
    }
}