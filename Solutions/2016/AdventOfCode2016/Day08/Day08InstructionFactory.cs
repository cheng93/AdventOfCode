namespace AdventOfCode2016.Day08
{
    using System;
    using System.Linq;

    public class Day08InstructionFactory
    {
        public IDay08Instruction Create(string input)
        {
            /*
            * Example inputs: 
            * rect AxB
            * rotate row y=A by B
            * rotate column x=A by B
            */

            if (input.StartsWith("rect"))
            {
                var splits = input.Split(' ', 'x');

                return new Day08RectInstruction(int.Parse(splits[1]), int.Parse(splits[2]));
            }
            else if (input.StartsWith("rotate"))
            {
                var splits = input.Split('=', ' ');

                var index = int.Parse(splits[3]);
                var pixels = int.Parse(splits[5]);
                if (splits[1] == "row")
                {
                    return new Day08RowRotateInstruction(index, pixels);
                }
                else if (splits[1] == "column")
                {
                    return new Day08ColumnRotateInstruction(index, pixels);
                }
            }

            throw new InvalidOperationException();
        }
    }
}