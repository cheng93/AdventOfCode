namespace AdventOfCode2016.Day10;

public class Day10Solver
{
    public static int PuzzleOne(IEnumerable<string> input, int inputHigh = 61, int inputLow = 17)
    {
        var bots = new Dictionary<int, Day10Bot>();
        var processed = new HashSet<int>();
        var queue = new Queue<int>();

        foreach (var line in input)
        {
            var splits = line.Split(" ");
            if (line.StartsWith("value"))
            {
                var value = int.Parse(splits[1]);
                var id = int.Parse(splits[5]);
                var bot = TryGetBot(id);

                bot.Numbers.Add(value);

                TryQueueBot(bot);
            }
            else
            {
                var id = int.Parse(splits[1]);
                var low = int.Parse(splits[6]);
                var high = int.Parse(splits[11]);
                var bot = TryGetBot(id);

                bot.High = high;
                bot.Low = low;

                TryQueueBot(bot);
            }
        }

        while (queue.Any())
        {
            var id = queue.Dequeue();
            var bot = bots[id];

            if (bot.Numbers.Contains(inputHigh) && bot.Numbers.Contains(inputLow))
            {
                return bot.Id;
            }

            var highBot = bots[bot.High!.Value];
            var lowBot = bots[bot.Low!.Value];

            highBot.Numbers.Add(bot.Numbers.Max());
            lowBot.Numbers.Add(bot.Numbers.Min());

            TryQueueBot(highBot);
            TryQueueBot(lowBot);

            processed.Add(id);
        }

        throw new Exception();

        Day10Bot TryGetBot(int id)
        {
            if (!bots.ContainsKey(id))
            {
                bots[id] = new(id);
            }

            return bots[id];
        }

        void TryQueueBot(Day10Bot bot)
        {
            if (IsReady(bot) && !processed.Contains(bot.Id))
            {
                queue.Enqueue(bot.Id);
            }
        }

        bool IsReady(Day10Bot bot)
            => bot.Numbers.Count == 2
                && bot.High.HasValue
                && bot.Low.HasValue;
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var bots = new Dictionary<int, Day10Bot>();
        var outputs = new Dictionary<int, int>();
        var processed = new HashSet<int>();
        var queue = new Queue<int>();

        foreach (var line in input)
        {
            var splits = line.Split(" ");
            if (line.StartsWith("value"))
            {
                var value = int.Parse(splits[1]);
                var id = int.Parse(splits[5]);
                var bot = TryGetBot(id);

                bot.Numbers.Add(value);

                TryQueueBot(bot);
            }
            else
            {
                var id = int.Parse(splits[1]);
                var lowOutput = splits[5] == "output";
                var low = int.Parse(splits[6]);
                var highOutput = splits[10] == "output";
                var high = int.Parse(splits[11]);
                var bot = TryGetBot(id);

                bot.High = high;
                bot.Low = low;
                bot.HighOutput = highOutput;
                bot.LowOutput = lowOutput;

                TryQueueBot(bot);
            }
        }

        while (queue.Any())
        {
            var id = queue.Dequeue();
            var bot = bots[id];

            var max = bot.Numbers.Max();
            var min = bot.Numbers.Min();

            if (!bot.HighOutput)
            {
                var highBot = bots[bot.High!.Value];
                highBot.Numbers.Add(max);
                TryQueueBot(highBot);
            }
            else
            {
                outputs[bot.High!.Value] = max;
            }

            if (!bot.LowOutput)
            {
                var lowBot = bots[bot.Low!.Value];
                lowBot.Numbers.Add(min);
                TryQueueBot(lowBot);
            }
            else
            {
                outputs[bot.Low!.Value] = min;
            }

            processed.Add(id);
        }

        return outputs[0] * outputs[1] * outputs[2];

        Day10Bot TryGetBot(int id)
        {
            if (!bots.ContainsKey(id))
            {
                bots[id] = new(id);
            }

            return bots[id];
        }

        void TryQueueBot(Day10Bot bot)
        {
            if (IsReady(bot) && !processed.Contains(bot.Id))
            {
                queue.Enqueue(bot.Id);
            }
        }

        bool IsReady(Day10Bot bot)
            => bot.Numbers.Count == 2
                && bot.High.HasValue
                && bot.Low.HasValue;
    }
}