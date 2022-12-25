namespace AdventOfCode2016.Day19;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day19Puzzle : Puzzle
{
    private const int Input = 3001330;

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day19Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day19Solver.PuzzleTwo(input).ToString();
    }

    private Task<int> GetInput() => Task.FromResult(Input);
}
