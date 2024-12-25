namespace AdventOfCode2024.Day25;

public class Day25Schematic
{
    /*
    #####
    .####
    .####
    .####
    .#.#.
    .#...
    .....
    */
    public Day25Schematic(string input)
    {
        var lines = input.Split(Environment.NewLine);

        IsLock = lines[0] == "#####";
        Heights = Enumerable
            .Repeat(IsLock ? 0 : 5, 5)
            .ToArray();

        for (var i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                if (IsLock && c == '#')
                {
                    Heights[j]++;
                }
                else if (!IsLock && c == '.')
                {
                    Heights[j]--;
                }
            }
        }
    }

    public int[] Heights { get; }

    public bool IsLock { get; }
}