using System.Numerics;

namespace AdventOfCode2024.Day21;

public class Day21Keypad
{
    public IEnumerable<string> Goto(char button)
    {
        var directions = new[] { 1, Complex.ImaginaryOne, -1, -Complex.ImaginaryOne };
        var symbols = new[] { '>', 'v', '<', '^' };
        var queue = new Queue<QueueItem>();
        queue.Enqueue(new(string.Empty, _current));
        var yielded = false;
        while (!yielded)
        {
            var newQueue = new Queue<QueueItem>();
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (_buttons[current.Position] == button)
                {
                    yielded = true;
                    yield return current.Sequence + 'A';
                    continue;
                }

                for (var i = 0; i < 4; i++)
                {
                    var neighbour = current.Position + directions[i];
                    if (!_buttons.ContainsKey(neighbour))
                    {
                        continue;
                    }
                    newQueue.Enqueue(new(current.Sequence + symbols[i], neighbour));
                }
            }
            queue = newQueue;
        }
        _current = GetComplex(button);
    }

    public static Day21Keypad Numeric()
    {
        var dict = new Dictionary<Complex, char>()
        {
            { 0, '7' },
            { 1, '8' },
            { 2, '9' },
            { 0 + Complex.ImaginaryOne, '4' },
            { 1 + Complex.ImaginaryOne, '5' },
            { 2 + Complex.ImaginaryOne, '6' },
            { 0 + 2 * Complex.ImaginaryOne, '1' },
            { 1 + 2 * Complex.ImaginaryOne, '2' },
            { 2 + 2 * Complex.ImaginaryOne, '3' },
            { 1 + 3 * Complex.ImaginaryOne, '0' },
            { 2 + 3 * Complex.ImaginaryOne, 'A' },
        };

        return new(dict);
    }
    public static Day21Keypad Directional()
    {
        var dict = new Dictionary<Complex, char>()
        {
            { 1, '^' },
            { 2, 'A' },
            { 0 + Complex.ImaginaryOne, '<' },
            { 1 + Complex.ImaginaryOne, 'v' },
            { 2 + Complex.ImaginaryOne, '>' },
        };

        return new(dict);
    }

    private Day21Keypad(Dictionary<Complex, char> buttons)
    {
        _buttons = buttons;
        _current = buttons.First(x => x.Value == 'A').Key;
    }

    private Complex GetComplex(char button) => _buttons.First(x => x.Value == button).Key;

    private readonly Dictionary<Complex, char> _buttons;

    private Complex _current;

    private record QueueItem(string Sequence, Complex Position);
}