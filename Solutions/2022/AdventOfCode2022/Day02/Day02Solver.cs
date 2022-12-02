namespace AdventOfCode2022.Day02;

public static class Day02Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var splits = line.Split(' ');
            var opponent = splits[0] switch
            {
                "A" => 1,
                "B" => 2,
                "C" => 3,
                _ => throw new Exception()
            };

            var self = splits[1] switch
            {
                "X" => 1,
                "Y" => 2,
                "Z" => 3,
                _ => throw new Exception()
            };

            var outcome = ((3 + self - opponent) % 3) switch
            {
                0 => 3,
                1 => 6,
                2 => 0,
                _ => throw new Exception()
            };

            var score = self + outcome;
            sum += score;
        }

        return sum;
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var splits = line.Split(' ');
            var opponent = splits[0] switch
            {
                "A" => 1,
                "B" => 2,
                "C" => 3,
                _ => throw new Exception()
            };

            var outcome = splits[1] switch
            {
                "X" => 0,
                "Y" => 3,
                "Z" => 6,
                _ => throw new Exception()
            };

            var self = (((outcome / 3) + opponent + 1) % 3) + 1;

            var score = self + outcome;
            sum += score;
        }

        return sum;
    }
}