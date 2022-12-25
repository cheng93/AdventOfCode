namespace AdventOfCode2016.Day18;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day18Puzzle : Puzzle
{
    private const string Input = ".^^^^^.^^.^^^.^...^..^^.^.^..^^^^^^^^^^..^...^^.^..^^^^..^^^^...^.^.^^^^^^^^....^..^^^^^^.^^^.^^^.^^";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day18Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day18Solver.PuzzleTwo(input).ToString();
    }

    private Task<string> GetInput() => Task.FromResult(Input);
}
