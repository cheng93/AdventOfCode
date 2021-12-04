namespace AdventOfCode2021.Day04;

public static class Day04Solver
{
    public static int PuzzleOne(string input)
    {
        var (draw, boards) = Init(input);

        foreach (var number in draw)
        {
            foreach (var board in boards)
            {
                var bingo = board.Mark(number);

                if (bingo)
                {
                    return board.Unmarked.Sum() * number;
                }
            }
        }

        throw new Exception();
    }

    public static int PuzzleTwo(string input)
    {
        var (draw, boards) = Init(input);

        foreach (var number in draw)
        {
            foreach (var board in boards.ToList())
            {
                var bingo = board.Mark(number);

                if (bingo)
                {
                    if (boards.Count == 1)
                    {
                        return board.Unmarked.Sum() * number;
                    }
                    else
                    {
                        boards.Remove(board);
                    }
                }
            }
        }

        throw new Exception();
    }

    private static (IEnumerable<int> Draw, List<Day04Board> Boards) Init(string input)
    {
        var array = input
            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        var draw = array[0].Split(",").Select(int.Parse);
        var boards = new List<Day04Board>();

        for (var i = 1; i < array.Length; i = i + 5)
        {
            var rows = array
                .Skip(i)
                .Take(5);

            boards.Add(new(rows));
        }

        return (draw, boards);
    }
}