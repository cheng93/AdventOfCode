namespace AdventOfCode2021.Day01;

public static class Day01Solver
{
    public static int PuzzleOne(IEnumerable<int> input)
    {
        var array = input.ToArray();

        return array
            .Skip(1)
            .Where((x, i) => x > array[i])
            .Count();
    }

    public static int PuzzleTwo(IEnumerable<int> input)
    {
        var array = input.ToArray();

        return array
            .Skip(3)
            .Where((x, i) => x + array[i + 1] + array[i + 2] > array[i] + array[i + 1] + array[i + 2])
            .Count();
    }
}