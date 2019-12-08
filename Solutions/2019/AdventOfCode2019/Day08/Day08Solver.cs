using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day08
{
    public class Day08Solver
    {
        public int PuzzleOne(IEnumerable<int> input, int width = 25, int height = 6)
        {
            var layers = GetLayers(input, width, height);

            return layers
                .Select(x => new
                {
                    Layer = x,
                    Zeros = x.Count(l => l == 0),
                    Answer = x.Count(l => l == 1) * x.Count(l => l == 2)
                })
                .OrderBy(x => x.Zeros)
                .First()
                .Answer;
        }

        public string PuzzleTwo(IEnumerable<int> input, int width = 25, int height = 6)
        {
            var lines = GetLayers(input, width, height)
                .SelectMany((layer, i) => layer
                    .Select((pixel, j) => new
                    {
                        Pixel = pixel,
                        Position = j,
                        Layer = i
                    }))
                .GroupBy(x => x.Position)
                .Select(x => x
                    .OrderBy(y => y.Layer)
                    .First(y => y.Pixel != 2))
                .GroupBy(
                    x => x.Position / width,
                    x => x.Pixel == 0 ? '.' : '#')
                .Select(x => string.Join("", x));

            return string.Join(Environment.NewLine, lines);
        }

        private List<ICollection<int>> GetLayers(IEnumerable<int> input, int width, int height)
        {
            var layers = new List<ICollection<int>>();
            var i = 0;
            var product = width * height;
            while (true)
            {
                var layer = input.Skip(i * product).Take(product).ToList();
                i++;
                if (layer.Any())
                {
                    layers.Add(layer);
                }
                else
                {
                    return layers;
                }
            }
        }
    }
}