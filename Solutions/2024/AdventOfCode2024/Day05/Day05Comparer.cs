namespace AdventOfCode2024.Day05;

public class Day05Comparer(IDictionary<int, HashSet<int>> before) : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (before.TryGetValue(x, out var afterX) && afterX.Contains(y))
        {
            return -1;
        }
        if (before.TryGetValue(y, out var afterY) && afterY.Contains(x))
        {
            return 1;
        }
        return 0;
    }
}