namespace AdventOfCode2023.Day13;

using Reflection = (string Initial, string Reflected);

public class Day13Pattern
{
    /*
    #.##..##.
    ..#.##.#.
    ##......#
    ##......#
    ..#.##.#.
    ..##..##.
    #.#.##.#.
    */
    public Day13Pattern(string input)
    {
        Lines = input.Split(Environment.NewLine);
    }

    public string[] Lines { get; }

    public IEnumerable<Reflection> ScanLeft()
    {
        for (var z = 0; z < Lines[0].Length / 2; z++)
        {
            var initial = new List<string>();
            var reflected = new List<string>();

            var x = z + 1;

            for (var y = 0; y < Lines.Length; y++)
            {
                initial.Add(Lines[y][..x]);
                reflected.Add(string.Join(string.Empty, Lines[y][x..(x + x)].Reverse()));
            }

            yield return (string.Join(Environment.NewLine, initial), string.Join(Environment.NewLine, reflected));
        }
    }

    public IEnumerable<Reflection> ScanRight()
    {
        for (var z = 0; z < Lines[0].Length / 2; z++)
        {
            var initial = new List<string>();
            var reflected = new List<string>();

            var x = z + 1;
            var x1 = Lines[0].Length - x;

            for (var y = 0; y < Lines.Length; y++)
            {
                initial.Add(string.Join(string.Empty, Lines[y][(x1 - x)..x1].Reverse()));
                reflected.Add(Lines[y][x1..]);
            }

            yield return (string.Join(Environment.NewLine, initial), string.Join(Environment.NewLine, reflected));
        }
    }

    public IEnumerable<Reflection> ScanDown()
    {
        for (var z = 0; z < Lines.Length / 2; z++)
        {
            var initial = new List<string>();
            var reflected = new List<string>();

            for (var y = 0; y <= z; y++)
            {
                initial.Add(Lines[y]);
                reflected.Add(Lines[z + y + 1]);
            }

            reflected.Reverse();

            yield return (string.Join(Environment.NewLine, initial), string.Join(Environment.NewLine, reflected));
        }
    }

    public IEnumerable<Reflection> ScanUp()
    {
        for (var z = 0; z < Lines.Length / 2; z++)
        {
            var initial = new List<string>();
            var reflected = new List<string>();

            for (var y = 0; y <= z; y++)
            {
                initial.Add(Lines[Lines.Length - 2 - z - y]);
                reflected.Add(Lines[Lines.Length - 1 - y]);
            }

            initial.Reverse();

            yield return (string.Join(Environment.NewLine, initial), string.Join(Environment.NewLine, reflected));
        }
    }
}