namespace AdventOfCode2022.Day07;

public static class Day07Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var system = GetFileSystem(input);

        return system
            .Values
            .Where(x => x.Size <= 100000)
            .Sum(x => x.Size);
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var system = GetFileSystem(input);

        var total = 70000000;
        var required = 30000000;
        var free = total - system["/"].Size;

        return system.Values
            .Where(x => x.Size + free >= required)
            .Select(x => x.Size)
            .Min();
    }

    private static Dictionary<string, Day07Directory> GetFileSystem(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var root = "/";
        var system = new Dictionary<string, Day07Directory>()
        {
            { root, new Day07Directory(root) }
        };

        Day07Directory currentDirectory = system[root];
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var args = line.Split(" ");
            if (args[0] == "$")
            {
                if (args[1] == "cd")
                {
                    if (args[2] == "..")
                    {
                        currentDirectory = currentDirectory.Parent ?? throw new Exception();
                    }
                    else
                    {
                        var path = args[2];
                        if (path != "/")
                        {
                            path = $"{currentDirectory.Path}{path}/";
                        }
                        currentDirectory = system[path];
                    }
                }
                else if (args[1] == "ls")
                {
                    var j = i + 1;
                    while (j < lines.Length && !lines[j].StartsWith('$'))
                    {
                        line = lines[j];
                        args = line.Split(" ");
                        if (args[0] == "dir")
                        {
                            var path = $"{currentDirectory.Path}{args[1]}/";
                            var child = new Day07Directory(path);
                            child.Parent = currentDirectory;
                            currentDirectory.Children.Add(child);
                            system.Add(child.Path, child);
                        }
                        else
                        {
                            var file = new Day07File(args[1], int.Parse(args[0]));
                            currentDirectory.Files.Add(file);
                        }
                        j++;
                    }
                    i = j - 1;
                }
            }
        }

        return system;
    }
}