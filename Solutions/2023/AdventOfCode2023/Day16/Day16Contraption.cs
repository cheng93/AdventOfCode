namespace AdventOfCode2023.Day16;

using Coord = (int X, int Y);

public class Day16Contraption
{
    /*
    .|...\....
    |.-.\.....
    .....|-...
    ........|.
    ..........
    .........\
    ..../.\\..
    .-.-/..|..
    .|....-|.\
    ..//.|....
    */
    public Day16Contraption(string input)
    {
        var lines = input.Split(Environment.NewLine);
        LengthX = lines[0].Length;
        LengthY = lines.Length;
        for (var y = 0; y < LengthY; y++)
        {
            for (var x = 0; x < LengthX; x++)
            {
                map.Add((x, y), lines[y][x]);
            }
        }
    }

    private readonly Dictionary<Coord, char> map = new();

    public int LengthX { get; }

    public int LengthY { get; }

    public int Energize((Coord Position, int Direction) origin)
    {
        var energized = new HashSet<Coord>();
        var seen = new HashSet<(Coord Position, int Direction)>();
        var queue = new Queue<(Coord Position, int Direction)>();
        queue.Enqueue(origin);

        var modifiers = new Coord[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };

        while (queue.Any())
        {
            var current = queue.Dequeue();
            var (position, direction) = current;
            if (seen.Contains(current))
            {
                continue;
            }

            seen.Add(current);
            energized.Add(position);
            var character = map[position];

            var movingHorizontal = direction % 2 == 0;

            if (character == '.'
                || (movingHorizontal && character == '-')
                || (!movingHorizontal && character == '|'))
            {
                Move(position, direction);
            }
            else if (movingHorizontal)
            {
                if (character == '|'
                    || (direction == 0 && character == '\\')
                    || (direction == 2 && character == '/'))
                {
                    Move(position, 1);
                }
                if (character == '|'
                    || (direction == 0 && character == '/')
                    || (direction == 2 && character == '\\'))
                {
                    Move(position, 3);
                }
            }
            else
            {
                if (character == '-'
                    || (direction == 1 && character == '\\')
                    || (direction == 3 && character == '/'))
                {
                    Move(position, 0);
                }
                if (character == '-'
                    || (direction == 1 && character == '/')
                    || (direction == 3 && character == '\\'))
                {
                    Move(position, 2);
                }
            }

            void Move(Coord position, int direction)
            {
                var modifier = modifiers[direction];
                var newPosition = (position.X + modifier.X, position.Y + modifier.Y);
                if (map.ContainsKey(newPosition))
                {
                    queue.Enqueue((newPosition, direction));
                }
            }
        }

        return energized.Count;
    }
}