using System.Text.RegularExpressions;

namespace AdventOfCode2016.Day11;

public class Day11State
{
    // The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium-compatible microchip.
    public Day11State(IEnumerable<string> input)
    {
        var lines = input.ToArray();

        var elements = new List<string>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (line.Contains("nothing relevant"))
            {
                continue;
            }

            var matches = Regex.Matches(line, "a (.+?)(?:-compatible microchip| generator)");
            foreach (Match match in matches)
            {
                var capture = match.Groups[1].Value;
                if (!elements.Contains(capture))
                {
                    elements.Add(capture);
                    Elements.Add((0, 0));
                }

                var elementIndex = elements.IndexOf(capture);

                if (match.Value.EndsWith("generator"))
                {
                    var generatorIndex = elementIndex * 2;
                    Floors[i].Add(generatorIndex);
                    Elements[elementIndex] = (i, Elements[elementIndex].Microchip);
                }
                else
                {
                    var microchipIndex = elementIndex * 2 + 1;
                    Floors[i].Add(microchipIndex);
                    Elements[elementIndex] = (Elements[elementIndex].Generator, i);
                }
            }
        }
    }

    public Day11State(string stateKey)
    {
        var parsed = stateKey.Select(x => int.Parse(x.ToString())).ToArray();
        Elevator = parsed[0];
        for (var i = 1; i < parsed.Length; i++)
        {
            for (var j = 0; j < parsed[i]; j++)
            {
                var element = Map[i - 1];
                AddElement(element);
            }
        }
    }

    public int Elevator { get; }

    public List<int>[] Floors { get; } = Enumerable.Range(0, 4)
            .Select(_ => new List<int>())
            .ToArray();

    public List<(int Generator, int Microchip)> Elements { get; } = new();

    public void AddElement((int Generator, int Microchip) element)
    {
        Floors[element.Generator].Add(Elements.Count * 2);
        Floors[element.Microchip].Add(Elements.Count * 2 + 1);
        Elements.Add(element);
    }

    public IEnumerable<string> Next()
    {
        var floor = Floors[Elevator];
        var movements = new[] { -1, 1 }
            .Where(x => Elevator + x >= 0 && Elevator + x <= 3)
            .ToArray();

        foreach (var movement in movements)
        {
            var elevator = Elevator + movement;

            for (var i = 0; i < floor.Count; i++)
            {
                var iElements = Elements.ToList();
                var iIndex = floor[i];
                var elementIndex = iIndex / 2;
                var element = Elements[elementIndex];
                var isGenerator = iIndex % 2 == 0;
                var newElement = isGenerator
                    ? (element.Generator + movement, element.Microchip)
                    : (element.Generator, element.Microchip + movement);
                iElements[elementIndex] = newElement;

                var stateKey = ToString(elevator, iElements);
                var state = new Day11State(stateKey);
                if (state.IsValid())
                {
                    yield return stateKey;
                }

                for (var j = i + 1; j < floor.Count; j++)
                {
                    var jElements = iElements.ToList();
                    var jIndex = floor[j];
                    elementIndex = jIndex / 2;
                    element = jElements[elementIndex];
                    isGenerator = jIndex % 2 == 0;
                    newElement = isGenerator
                        ? (element.Generator + movement, element.Microchip)
                        : (element.Generator, element.Microchip + movement);
                    jElements[elementIndex] = newElement;

                    stateKey = ToString(elevator, jElements);
                    state = new Day11State(stateKey);
                    if (state.IsValid())
                    {
                        yield return stateKey;
                    }
                }
            }
        }
    }

    public bool IsValid()
    {
        for (var i = 0; i < Elements.Count; i++)
        {
            var (generator, microchip) = Elements[i];
            if (generator == microchip)
            {
                continue;
            }
            var floor = Floors[microchip];
            if (floor.Any(x => x % 2 == 0))
            {
                return false;
            }
        }
        return true;
    }

    public override string ToString() => ToString(Elevator, Elements);

    private string ToString(int elevator, IEnumerable<(int Generator, int Microchip)> elements)
    {
        var keys = new int[Map.Count];
        foreach (var element in elements)
        {
            keys[Map.IndexOf(element)]++;
        }

        return keys.Aggregate($"{elevator}", (agg, cur) => agg += cur);
    }

    public static readonly List<(int Generator, int Microchip)> Map = new List<(int Generator, int Microchip)>
    {
        (0, 0),
        (0, 1),
        (0, 2),
        (0, 3),
        (1, 0),
        (1, 1),
        (1, 2),
        (1, 3),
        (2, 0),
        (2, 1),
        (2, 2),
        (2, 3),
        (3, 0),
        (3, 1),
        (3, 2),
        (3, 3),
    };
}