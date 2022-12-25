namespace AdventOfCode2016.Day21;

public class Day21Solver
{
    public static string PuzzleOne(IEnumerable<string> input, string password = "abcdefgh")
    {
        var lines = input.ToArray();

        foreach (var line in lines)
        {
            var splits = line.Split(" ").ToArray();
            var ints = splits
                .Where(x => int.TryParse(x, out var _))
                .Select(int.Parse)
                .ToArray();

            if (line.StartsWith("swap position"))
            {
                password = SwapPosition(ints[0], ints[1]);
            }
            else if (line.StartsWith("swap letter"))
            {
                password = SwapLetter(splits[2], splits[5]);
            }
            else if (line.StartsWith("rotate left"))
            {
                password = RotateLeft(ints[0]);
            }
            else if (line.StartsWith("rotate right"))
            {
                password = RotateRight(ints[0]);
            }
            else if (line.StartsWith("rotate based"))
            {
                password = RotateBased(splits[6]);
            }
            else if (line.StartsWith("reverse"))
            {
                password = Reverse(ints[0], ints[1]);
            }
            else if (line.StartsWith("move"))
            {
                password = Move(ints[0], ints[1]);
            }
        }

        return password;

        string SwapPosition(int x, int y)
        {
            var min = Math.Min(x, y);
            var max = Math.Max(x, y);
            var minChar = password[min];
            var maxChar = password[max];
            return password[0..min] + maxChar + password[(min + 1)..max] + minChar + password[(max + 1)..];
        }

        string SwapLetter(string x, string y)
        {
            var xIndex = password.IndexOf(x);
            var yIndex = password.IndexOf(y);

            return SwapPosition(xIndex, yIndex);
        }

        string RotateLeft(int x)
        {
            var mod = x % password.Length;
            var start = password[..mod];
            return password[mod..] + start;
        }

        string RotateRight(int x)
        {
            var mod = x % password.Length;
            var end = password[^mod..];
            return end + password[..^mod];
        }

        string RotateBased(string x)
        {
            var xIndex = password.IndexOf(x);
            var rotations = xIndex + 1;
            if (xIndex >= 4)
            {
                rotations++;
            }
            return RotateRight(rotations);
        }

        string Reverse(int x, int y)
        {
            var slice = password[x..(y + 1)];
            var reverse = string.Join("", slice.Reverse());
            return password[..x] + reverse + password[(y + 1)..];
        }

        string Move(int x, int y)
        {
            var xChar = password[x];
            var removed = password.Remove(x, 1);
            return removed[..y] + xChar + removed[y..];
        }
    }

    public static string PuzzleTwo(IEnumerable<string> input, string scrambled = "fbgdceah")
    {
        var lines = input.Reverse().ToArray();

        foreach (var line in lines)
        {
            var splits = line.Split(" ").ToArray();
            var ints = splits
                .Where(x => int.TryParse(x, out var _))
                .Select(int.Parse)
                .ToArray();

            if (line.StartsWith("swap position"))
            {
                scrambled = SwapPosition(ints[0], ints[1]);
            }
            else if (line.StartsWith("swap letter"))
            {
                scrambled = SwapLetter(splits[2], splits[5]);
            }
            else if (line.StartsWith("rotate left"))
            {
                scrambled = RotateRight(ints[0]);
            }
            else if (line.StartsWith("rotate right"))
            {
                scrambled = RotateLeft(ints[0]);
            }
            else if (line.StartsWith("rotate based"))
            {
                scrambled = RotateBased(splits[6]);
            }
            else if (line.StartsWith("reverse"))
            {
                scrambled = Reverse(ints[0], ints[1]);
            }
            else if (line.StartsWith("move"))
            {
                scrambled = Move(ints[1], ints[0]);
            }
        }

        return scrambled;

        string SwapPosition(int x, int y)
        {
            var min = Math.Min(x, y);
            var max = Math.Max(x, y);
            var minChar = scrambled[min];
            var maxChar = scrambled[max];
            return scrambled[0..min] + maxChar + scrambled[(min + 1)..max] + minChar + scrambled[(max + 1)..];
        }

        string SwapLetter(string x, string y)
        {
            var xIndex = scrambled.IndexOf(x);
            var yIndex = scrambled.IndexOf(y);

            return SwapPosition(xIndex, yIndex);
        }

        string RotateLeft(int x)
        {
            var mod = x % scrambled.Length;
            var start = scrambled[..mod];
            return scrambled[mod..] + start;
        }

        string RotateRight(int x)
        {
            var mod = x % scrambled.Length;
            var end = scrambled[^mod..];
            return end + scrambled[..^mod];
        }

        string RotateBased(string x)
        {
            var xIndex = scrambled.IndexOf(x);
            var rotations = xIndex switch
            {
                0 => 1,
                1 => 1,
                2 => 6,
                3 => 2,
                4 => 7,
                5 => 3,
                6 => 0,
                7 => 4,
                _ => throw new Exception()
            };
            return RotateLeft(rotations);
        }

        string Reverse(int x, int y)
        {
            var slice = scrambled[x..(y + 1)];
            var reverse = string.Join("", slice.Reverse());
            return scrambled[..x] + reverse + scrambled[(y + 1)..];
        }

        string Move(int x, int y)
        {
            var xChar = scrambled[x];
            var removed = scrambled.Remove(x, 1);
            return removed[..y] + xChar + removed[y..];
        }
    }
}