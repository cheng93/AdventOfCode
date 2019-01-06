namespace AdventOfCode2017.Day25
{
    using System.Collections.Generic;

    public class Day25State
    {
        public char Id { get; }

        public List<Day25Action> Actions { get; }

        public Day25State(IList<string> lines)
        {
            /* 
            Example input:
In state E:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the left.
    - Continue with state A.
  If the current value is 1:
    - Write the value 0.
    - Move one slot to the left.
    - Continue with state D.
            */

            this.Actions = new List<Day25Action>();

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i].Trim();
                if (i == 0)
                {
                    this.Id = line.Split(' ')[2][0];
                }
                else
                {
                    var value = 0;
                    var isRight = true;
                    var nextState = ' ';
                    for (var j = 1; j < 4; j++)
                    {
                        var instruction = lines[i + j].Trim();
                        var splits = instruction.Split(' ');
                        switch (j)
                        {
                            case 1:
                                value = int.Parse(splits[4][0].ToString());
                                break;
                            case 2:
                                var direction = splits[6].Substring(0, splits[6].Length - 1);
                                isRight = direction == "right";
                                break;
                            case 3:
                                nextState = splits[4][0];
                                break;
                        }

                    }
                    var action = new Day25Action(value, isRight, nextState);
                    this.Actions.Add(action);
                    i += 3;
                }
            }
        }
    }
}