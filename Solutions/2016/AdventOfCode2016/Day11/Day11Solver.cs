namespace AdventOfCode2016.Day11;

public class Day11Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var state = new Day11State(input);
        var stateKey = state.ToString();
        var goal = "3" + new string('0', stateKey[1..^1].Length) + state.Elements.Count;

        var gScore = new Dictionary<string, int>();
        gScore[stateKey] = 0;

        var queue = new PriorityQueue<string, int>();
        queue.Enqueue(stateKey, 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == goal)
            {
                return gScore[current];
            }

            state = new Day11State(current);

            foreach (var next in state.Next())
            {
                var newGScore = gScore[current] + 1;
                if (!gScore.TryGetValue(next, out var score) || newGScore < score)
                {
                    gScore[next] = newGScore;
                    queue.Enqueue(next, newGScore + h(next));
                }
            }
        }

        throw new Exception();

        int h(string s)
        {
            var goalWeight = state.Elements.Count * 6;
            var currentWeight = 0;

            for (var i = 1; i < s.Length; i++)
            {
                var count = int.Parse(s[i].ToString());
                var mapped = Day11State.Map[i - 1];
                for (var j = 0; j < count; j++)
                {
                    currentWeight += mapped.Generator;
                    currentWeight += mapped.Microchip;
                }
            }

            return goalWeight - currentWeight;
        }
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var state = new Day11State(input);
        state.AddElement((0, 0));
        state.AddElement((0, 0));
        var stateKey = state.ToString();
        var goal = "3" + new string('0', stateKey[1..^1].Length) + state.Elements.Count;

        var gScore = new Dictionary<string, int>();
        gScore[stateKey] = 0;

        var queue = new PriorityQueue<string, int>();
        queue.Enqueue(stateKey, 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == goal)
            {
                return gScore[current];
            }

            state = new Day11State(current);

            foreach (var next in state.Next())
            {
                var newGScore = gScore[current] + 1;
                if (!gScore.TryGetValue(next, out var score) || newGScore < score)
                {
                    gScore[next] = newGScore;
                    queue.Enqueue(next, newGScore + h(next));
                }
            }
        }

        throw new Exception();

        int h(string s)
        {
            var goalWeight = state.Elements.Count * 6;
            var currentWeight = 0;

            for (var i = 1; i < s.Length; i++)
            {
                var count = int.Parse(s[i].ToString());
                var mapped = Day11State.Map[i - 1];
                for (var j = 0; j < count; j++)
                {
                    currentWeight += mapped.Generator;
                    currentWeight += mapped.Microchip;
                }
            }

            return goalWeight - currentWeight;
        }
    }
}