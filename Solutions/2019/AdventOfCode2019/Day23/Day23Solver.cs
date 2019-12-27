using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2019.Day23
{
    public class Day23Solver
    {
        public int PuzzleOne(IEnumerable<long> input)
        {
            var queues = Enumerable.Range(0, 50).Select((x, i) => new Queue<long>(new List<long>() { i })).ToArray();
            var qlocks = queues.Select(x => new object()).ToArray();
            var computers = queues.Select((x, i) => IntCode(input, qlocks[i], x)).ToArray();
            var targets = new Dictionary<long, (long Address, long? X, long? Y)>();
            var tlocks = new object();

            var result = (long?)null;

            for (var i = 0; i < computers.Length; i++)
            {
                var index = i;
                computers[index].ToObservable(ThreadPoolScheduler.Instance).Subscribe(x =>
                {
                    lock (tlocks)
                    {
                        if (!targets.ContainsKey(index))
                        {
                            targets[index] = (x, null, null);
                        }
                        else
                        {
                            var target = targets[index];
                            if (!target.X.HasValue)
                            {
                                targets[index] = (target.Address, x, null);
                            }
                            else
                            {
                                target.Y = x;
                                if (target.Address == 255)
                                {
                                    result = x;
                                }
                                else
                                {
                                    lock (qlocks[target.Address])
                                    {
                                        queues[target.Address].Enqueue(target.X.Value);
                                        queues[target.Address].Enqueue(target.Y.Value);
                                    }

                                    targets.Remove(index);
                                }
                            }
                        }
                    }
                });
            }

            while (!result.HasValue) { }

            return (int)result.Value;
        }


        public long PuzzleTwo(IEnumerable<long> input)
        {
            var queues = Enumerable.Range(0, 50).Select((x, i) => new Queue<long>(new List<long>() { i })).ToArray();
            var idle = new ConcurrentDictionary<int, bool>(Enumerable.Range(0, 50).ToDictionary(x => x, x => false));
            var qlocks = queues.Select(x => new object()).ToArray();
            var computers = queues.Select((x, i) => IntCode(input, qlocks[i], x, (b) => idle[i] = b)).ToArray();
            var targets = new Dictionary<long, (long Address, long? X, long? Y)>();
            var tlocks = new object();

            var nat = (X: 0L, Y: 0L);
            var natSent = false;

            for (var i = 0; i < computers.Length; i++)
            {
                var index = i;
                computers[index].ToObservable(ThreadPoolScheduler.Instance).Subscribe(x =>
                {
                    lock (tlocks)
                    {
                        if (!targets.ContainsKey(index))
                        {
                            targets[index] = (x, null, null);
                        }
                        else
                        {
                            var target = targets[index];
                            if (!target.X.HasValue)
                            {
                                targets[index] = (target.Address, x, null);
                            }
                            else
                            {
                                target.Y = x;
                                if (target.Address == 255)
                                {
                                    nat = (target.X.Value, target.Y.Value);
                                    natSent = false;
                                }
                                else
                                {
                                    lock (qlocks[target.Address])
                                    {
                                        queues[target.Address].Enqueue(target.X.Value);
                                        queues[target.Address].Enqueue(target.Y.Value);
                                        idle[(int)target.Address] = false;
                                    }
                                }
                                targets.Remove(index, out var _);
                            }
                        }
                    }
                });
            }

            var sent = new HashSet<long>();
            while (true)
            {
                lock (tlocks)
                {
                    if (idle.Values.All(x => x) && !natSent && targets.Count == 0)
                    {
                        natSent = true;
                        if (sent.Contains(nat.Y))
                        {
                            Console.WriteLine(string.Join(',', sent));
                            return nat.Y;
                        }

                        sent.Add(nat.Y);
                        lock (qlocks[0])
                        {
                            queues[0].Enqueue(nat.X);
                            queues[0].Enqueue(nat.Y);
                        }
                    }
                }
            }
        }

        private static IEnumerable<long> IntCode(IEnumerable<long> input, object locker, Queue<long> queue, Action<bool> idle = null)
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
                // Console.WriteLine($"{i} --- " + string.Join(',', queue.ToArray()));
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
                    lock (locker)
                    {
                        var value = queue.TryDequeue(out var x) ? x : -1;
                        program[p[0].Original] = value;
                        if (idle != null)
                        {
                            idle(value == -1);
                        }
                    }
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