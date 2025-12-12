using System.Numerics;

namespace AdventOfCode2025.Day12;

public class Day12Shape
{
    /*
       ###
       ##.
       ##.
     */
    public Day12Shape(string input)
    {
        var splits = input.Split(Environment.NewLine);
        for (var j = 0; j < splits.Length; j++)
        {
            var line = splits[j];
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    Points.Add(new Complex(i, j));
                }
            }
        }
    }
    
    private Day12Shape(IEnumerable<Complex> points)
    {
        Points = points.ToList();
    }

    private List<Complex> Points { get; } = [];

    public HashSet<Complex> Fill(Complex source)
        => Points
            .Select(p => source + p)
            .ToHashSet();

    public Day12Shape Flip()
    {
        Complex Map(Complex point)
            => point switch
            {
                { Real: 0, Imaginary: 0 } => new(2, 0),
                { Real: 1, Imaginary: 0 } => new(1, 0),
                { Real: 2, Imaginary: 0 } => new(0, 0),
                { Real: 0, Imaginary: 1 } => new(2, 1),
                { Real: 1, Imaginary: 1 } => new(1, 1),
                { Real: 2, Imaginary: 1 } => new(0, 1),
                { Real: 0, Imaginary: 2 } => new(2, 2),
                { Real: 1, Imaginary: 2 } => new(1, 2),
                { Real: 2, Imaginary: 2 } => new(0, 2),
            };

        return new(Points.Select(Map));
    }

    public Day12Shape Rotate()
    {
        Complex Map(Complex point)
            => point switch
            {
                { Real: 0, Imaginary: 0 } => new(2, 0),
                { Real: 1, Imaginary: 0 } => new(2, 1),
                { Real: 2, Imaginary: 0 } => new(2, 2),
                { Real: 0, Imaginary: 1 } => new(1, 0),
                { Real: 1, Imaginary: 1 } => new(1, 1),
                { Real: 2, Imaginary: 1 } => new(1, 2),
                { Real: 0, Imaginary: 2 } => new(0, 0),
                { Real: 1, Imaginary: 2 } => new(0, 1),
                { Real: 2, Imaginary: 2 } => new(0, 2),
            };

        return new(Points.Select(Map));
    }
}