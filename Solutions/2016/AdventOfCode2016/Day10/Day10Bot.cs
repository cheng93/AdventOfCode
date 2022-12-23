namespace AdventOfCode2016.Day10;

public class Day10Bot
{
    public Day10Bot(int id)
    {
        Id = id;
    }

    public int Id { get; }

    public ICollection<int> Numbers { get; } = new List<int>();

    public bool HighOutput { get; set; }

    public bool LowOutput { get; set; }

    public int? High { get; set; }

    public int? Low { get; set; }
}