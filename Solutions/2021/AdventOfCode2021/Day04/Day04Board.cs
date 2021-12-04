namespace AdventOfCode2021.Day04;

public class Day04Board
{
    /*
    Example input:
    92  3 88 13 50
    90 70 24 28 52
    15 98 10 26  5
    84 34 37 73 87
    25 36 74 33 63
    */
    public Day04Board(IEnumerable<string> input)
    {
        var y = 0;
        foreach (var line in input)
        {
            var numbers = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var x = 0;

            foreach (var number in numbers)
            {
                _lookup[number] = (x, y);
                Unmarked.Add(number);
                x++;
            }

            y++;
        }
    }

    private readonly Dictionary<int, (int X, int Y)> _lookup = new();

    public HashSet<int> Marked { get; } = new();
    public HashSet<int> Unmarked { get; } = new();

    private readonly int[] _rows = new int[5];
    private readonly int[] _columns = new int[5];

    public bool Mark(int number)
    {
        if (!_lookup.TryGetValue(number, out var found))
        {
            return false;
        }

        _rows[found.X]++;
        _columns[found.Y]++;

        Unmarked.Remove(number);
        Marked.Add(number);

        return (_rows[found.X] == 5 || _columns[found.Y] == 5);
    }
}