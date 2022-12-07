namespace AdventOfCode2022.Day07;

public class Day07Directory
{
    public Day07Directory(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public Day07Directory? Parent { get; set; }

    public ICollection<Day07Directory> Children { get; } = new List<Day07Directory>();

    public ICollection<Day07File> Files { get; } = new List<Day07File>();

    public int Size => Files.Sum(x => x.Size) + Children.Sum(x => x.Size);
}