namespace AdventOfCode2023.Day15;

using Lens = (string Label, int FocalLength);

public class Day15Box
{
    private readonly LinkedList<Lens> list = new();
    private readonly Dictionary<string, LinkedListNode<Lens>> lookup = new();

    public void Dash(string label)
    {
        if (lookup.TryGetValue(label, out var node))
        {
            list.Remove(node);
            lookup.Remove(label);
        }
    }

    public void Equals(Lens lens)
    {
        if (lookup.TryGetValue(lens.Label, out var node))
        {
            var added = list.AddBefore(node, lens);
            list.Remove(node);
            lookup[lens.Label] = added;
        }
        else
        {
            var added = list.AddLast(lens);
            lookup.Add(lens.Label, added);
        }
    }

    public IEnumerable<int> FocusingPower()
    {
        var i = 1;
        foreach (var item in list)
        {
            yield return i * item.FocalLength;
            i++;
        }
    }
}