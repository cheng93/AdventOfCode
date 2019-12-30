using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2019.Day25
{
    public class Day25Solver
    {
        public int PuzzleOne(IEnumerable<long> input)
        {
            var instructions = new Queue<long>();
            var rooms = new Dictionary<string, Day25Room>();
            var parents = new Dictionary<string, (string Room, string Direction)>();

            var oppositeDirections = new Dictionary<string, string>()
            {
                {"north", "south"},
                {"east", "west"},
                {"south", "north"},
                {"west", "east"},
            };

            var badItems = new[]
            {
                "molten lava",
                "escape pod",
                "infinite loop",
                "giant electromagnet",
                "photons"
            };

            var inventory = new List<string>();

            string text = null;
            Day25Room currentRoom = null;
            Day25Room previousRoom = null;
            string previousDirection = null;
            var discovered = new HashSet<(string Parent, string Direction)>();
            var exploring = true;
            var queue = new Queue<IEnumerable<string>>();
            foreach (var output in IntCode(input, instructions))
            {
                text += (char)output;

                if (text.EndsWith("Command?"))
                {
                    if (text.Contains("=="))
                    {
                        var room = new Day25Room(text);
                        rooms[room.Name] = room;
                        currentRoom = room;
                        if (!parents.ContainsKey(currentRoom.Name))
                        {
                            parents[currentRoom.Name] = previousRoom != null
                                ? (previousRoom.Name, oppositeDirections[previousDirection])
                                : (null, null);
                        }
                    }
                    if (currentRoom.Items.Any(x => !badItems.Contains(x)) && exploring)
                    {
                        var firstItem = currentRoom.Items.First(x => !badItems.Contains(x));
                        Input($"take {firstItem}");
                        inventory.Add(firstItem);
                        currentRoom.Items.Remove(firstItem);
                    }
                    else
                    {
                        var doors = currentRoom.Doors
                            .Where(x => !discovered.Contains((currentRoom.Name, x))
                                && parents[currentRoom.Name].Direction != x);

                        var door = doors.FirstOrDefault();
                        var direction = exploring
                            ? parents[currentRoom.Name].Direction
                            : null;
                        if (door != null)
                        {
                            direction = door;
                            discovered.Add((currentRoom.Name, door));
                        }
                        if (direction == null)
                        {
                            exploring = false;
                            var target = parents["Pressure-Sensitive Floor"].Room;
                            while (target != currentRoom.Name)
                            {
                                if (currentRoom.Name == "Pressure-Sensitive Floor")
                                {
                                    break;
                                }
                                var parent = parents[target];
                                target = parent.Room;
                                direction = oppositeDirections[parent.Direction];
                            }
                        }
                        if (direction == null)
                        {
                            if (!queue.Any())
                            {
                                queue.Enqueue(Enumerable.Empty<string>());
                            }
                            var current = queue.Dequeue();
                            ManageItems(current);
                            foreach (var item in currentRoom.Items)
                            {
                                var list = current.ToList();
                                list.Add(item);
                                queue.Enqueue(list);
                            }
                            direction = oppositeDirections[parents["Pressure-Sensitive Floor"].Direction];
                        }
                        Input(direction);
                        previousRoom = currentRoom;
                        previousDirection = direction;

                    }

                    text = null;
                }
                else
                {
                    var match = Regex.Match(text, "Oh, hello! You should be able to get in by typing (\\d+) on the keypad at the main airlock.");
                    if (match.Success)
                    {
                        return int.Parse(match.Groups[1].Value);
                    }
                }
            }

            void Input(string command)
            {
                foreach (var character in command)
                {
                    instructions.Enqueue(character);
                }
                instructions.Enqueue(10);
            }

            void ManageItems(IEnumerable<string> items)
            {
                foreach (var item in inventory.ToList())
                {
                    Input($"drop {item}");
                    inventory.Remove(item);
                    currentRoom.Items.Add(item);
                }

                foreach (var item in items)
                {
                    Input($"take {item}");
                    inventory.Add(item);
                    currentRoom.Items.Remove(item);
                }
            }

            return 0;
        }

        private static IEnumerable<long> IntCode(IEnumerable<long> input, Queue<long> signals)
        {
            var program = input.ToList();

            void ExpandProgram(int size)
            {
                while (program.Count <= size)
                {
                    program.Add(0);
                }
            }

            var position = 0;
            var instruction = program[position];
            var opcode = long.MinValue;
            var relativeBase = 0;

            while (opcode != 99)
            {
                opcode = instruction % 100;
                var parameters = program
                    .Skip(position + 1)
                    .Take(3)
                    .Select((x, i)
                        =>
                        {
                            var parameter = ((instruction / (long)Math.Pow(10, 2 + i)) % 10);
                            var value = x;
                            var original = value;
                            switch (parameter)
                            {
                                case 0:
                                    ExpandProgram((int)x);
                                    value = program[(int)x];
                                    break;
                                case 2:
                                    ExpandProgram((int)x + relativeBase);
                                    value = program[(int)x + relativeBase];
                                    original = x + relativeBase;
                                    break;
                            }
                            return new
                            {
                                Original = (int)original,
                                Value = value
                            };
                        });

                if (opcode == 1)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value + p[1].Value;
                    position += 4;
                }
                else if (opcode == 2)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value * p[1].Value;
                    position += 4;
                }
                else if (opcode == 3)
                {
                    var p = parameters.Take(1).ToArray();
                    ExpandProgram(p[0].Original);
                    program[p[0].Original] = signals.Dequeue();
                    position += 2;
                }
                else if (opcode == 4)
                {
                    var p = parameters.Take(1).ToArray();
                    yield return p[0].Value;
                    position += 2;
                }
                else if (opcode == 5)
                {
                    var p = parameters.Take(2).ToArray();
                    if (p[0].Value != 0)
                    {
                        position = (int)p[1].Value;
                    }
                    else
                    {
                        position += 3;
                    }
                }
                else if (opcode == 6)
                {
                    var p = parameters.Take(2).ToArray();
                    if (p[0].Value == 0)
                    {
                        position = (int)p[1].Value;
                    }
                    else
                    {
                        position += 3;
                    }
                }
                else if (opcode == 7)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value < p[1].Value ? 1 : 0;
                    position += 4;
                }
                else if (opcode == 8)
                {
                    var p = parameters.ToArray();
                    ExpandProgram(p[2].Original);
                    program[p[2].Original] = p[0].Value == p[1].Value ? 1 : 0;
                    position += 4;
                }
                else if (opcode == 9)
                {
                    var p = parameters.Take(1).ToArray();
                    relativeBase += (int)p[0].Value;
                    position += 2;
                }

                instruction = program[position];
            }
        }
    }
}