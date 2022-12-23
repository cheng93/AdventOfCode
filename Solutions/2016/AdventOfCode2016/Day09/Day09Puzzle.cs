namespace AdventOfCode2016.Day09;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day09Puzzle : Puzzle
{
    private const string resource = "AdventOfCode2016.Day09.Input.txt";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.ReadResource(resource);

        return Day09Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.ReadResource(resource);

        return Day09Solver.PuzzleTwo(input).ToString();
    }
}
