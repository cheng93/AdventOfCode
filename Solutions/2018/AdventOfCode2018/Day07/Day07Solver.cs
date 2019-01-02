namespace AdventOfCode2018.Day07
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day07Solver
    {
        public string PuzzleOne(IEnumerable<string> input)
        {
            var available = new HashSet<string>();
            var prerequisites = new Dictionary<string, HashSet<string>>();
            var instructions = new Dictionary<string, HashSet<string>>();

            foreach (var instruction in input.Select(GetInstruction))
            {
                if (!prerequisites.ContainsKey(instruction.prerequisite) && !available.Contains(instruction.prerequisite))
                {
                    available.Add(instruction.prerequisite);
                }
                if (instructions.ContainsKey(instruction.prerequisite))
                {
                    instructions[instruction.prerequisite].Add(instruction.id);
                }
                else
                {
                    instructions.Add(instruction.prerequisite, new HashSet<string>() { instruction.id });
                }

                if (prerequisites.ContainsKey(instruction.id))
                {
                    prerequisites[instruction.id].Add(instruction.prerequisite);
                }
                else
                {
                    prerequisites.Add(instruction.id, new HashSet<string>() { instruction.prerequisite });
                }
                if (prerequisites.ContainsKey(instruction.id) && available.Contains(instruction.id))
                {
                    available.Remove(instruction.id);
                }
            }

            var steps = new List<string>();

            while (available.Count != 0)
            {
                var step = available.OrderBy(x => x).First();
                steps.Add(step);
                available.Remove(step);

                if (instructions.ContainsKey(step))
                {
                    var possibleAvailble = instructions[step];
                    foreach (var possible in possibleAvailble)
                    {
                        if (prerequisites.ContainsKey(possible))
                        {
                            prerequisites[possible].Remove(step);
                            if (prerequisites[possible].Count == 0)
                            {
                                available.Add(possible);
                                prerequisites.Remove(possible);
                            }
                        }
                    }
                }
            }

            return string.Join("", steps);
        }

        public int PuzzleTwo(IEnumerable<string> input, int workers, int buffer)
        {
            var available = new HashSet<string>();
            var prerequisites = new Dictionary<string, HashSet<string>>();
            var instructions = new Dictionary<string, HashSet<string>>();

            foreach (var instruction in input.Select(GetInstruction))
            {
                if (!prerequisites.ContainsKey(instruction.prerequisite) && !available.Contains(instruction.prerequisite))
                {
                    available.Add(instruction.prerequisite);
                }
                if (instructions.ContainsKey(instruction.prerequisite))
                {
                    instructions[instruction.prerequisite].Add(instruction.id);
                }
                else
                {
                    instructions.Add(instruction.prerequisite, new HashSet<string>() { instruction.id });
                }

                if (prerequisites.ContainsKey(instruction.id))
                {
                    prerequisites[instruction.id].Add(instruction.prerequisite);
                }
                else
                {
                    prerequisites.Add(instruction.id, new HashSet<string>() { instruction.prerequisite });
                }
                if (prerequisites.ContainsKey(instruction.id) && available.Contains(instruction.id))
                {
                    available.Remove(instruction.id);
                }
            }

            var time = 0;

            var workerLogs = Enumerable.Range(0, workers).ToDictionary(x => x, x => 0);
            var workerStep = Enumerable.Range(0, workers).ToDictionary(x => x, x => (string)null);

            do
            {
                var workersWithTime = workerLogs.Where(x => x.Value != 0).ToDictionary(x => x.Key, x => x.Value);
                if (workersWithTime.Any())
                {
                    var minTime = workersWithTime.Values.Min();
                    var finishedWorkers = workersWithTime.Where(x => x.Value == minTime).Select(x => x.Key);
                    time += minTime;
                    foreach (var worker in workersWithTime.Keys)
                    {
                        workerLogs[worker] = workerLogs[worker] - minTime;
                    }

                    foreach (var finishedWorker in finishedWorkers)
                    {
                        var step = workerStep[finishedWorker];
                        if (instructions.ContainsKey(step))
                        {
                            var possibleAvailble = instructions[step];
                            foreach (var possible in possibleAvailble)
                            {
                                if (prerequisites.ContainsKey(possible))
                                {
                                    prerequisites[possible].Remove(step);
                                    if (prerequisites[possible].Count == 0)
                                    {
                                        available.Add(possible);
                                        prerequisites.Remove(possible);
                                    }
                                }
                            }
                        }

                        workerStep[finishedWorker] = null;
                    }
                }

                var availableWorkers = workerLogs.Where(x => x.Value == 0).Select(x => x.Key).ToArray();
                var queue = new Queue<string>();
                foreach (var step in available.OrderBy(x => x))
                {
                    queue.Enqueue(step);
                }
                foreach (var availableWorker in availableWorkers)
                {
                    if (queue.Any())
                    {
                        var step = queue.Dequeue();
                        workerLogs[availableWorker] = step[0] - 64 + buffer; // A is 65 but we 1 + buffer
                        workerStep[availableWorker] = step;
                        available.Remove(step);
                    }
                }
            } while (workerLogs.Values.Max() > 0);

            return time;
        }

        private static (string prerequisite, string id) GetInstruction(string input)
        {
            // Example input: Step C must be finished before step A can begin.
            var splits = input.Split(' ');
            return (splits[1], splits[7]);
        }
    }
}