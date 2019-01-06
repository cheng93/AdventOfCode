namespace AdventOfCode2017.Day25
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day25Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var states = new Dictionary<char, Day25State>();

            var stateId = ' ';
            var steps = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (i == 0)
                {
                    // Example: Begin in state A.
                    stateId = line.Split(' ')[3][0];
                }
                else if (i == 1)
                {
                    // Example: Perform a diagnostic checksum after 12586542 steps.
                    steps = int.Parse(line.Split(' ')[5]);
                }
                else
                {
                    var stateLines = lines.Skip(i).Take(9).ToList();
                    var state = new Day25State(stateLines);
                    states.Add(state.Id, state);
                    i += 8;
                }
            }

            var tape = new LinkedList<int>();
            tape.AddFirst(0);
            var current = tape.First;
            var checksum = 0;

            for (var i = 0; i < steps; i++)
            {
                var state = states[stateId];
                var action = state.Actions[current.Value];
                if (current.Value != action.Value)
                {
                    checksum += action.Value == 1 ? 1 : -1;
                }
                current.Value = action.Value;
                if (action.IsRight)
                {
                    if (current.Next == null)
                    {
                        tape.AddLast(0);
                    }
                    current = current.Next;
                }
                else
                {
                    if (current.Previous == null)
                    {
                        tape.AddFirst(0);
                    }
                    current = current.Previous;
                }
                stateId = action.NextState;
            }

            return checksum;
        }
    }
}