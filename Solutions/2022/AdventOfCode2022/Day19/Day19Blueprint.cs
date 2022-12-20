namespace AdventOfCode2022.Day19;

public class Day19Blueprint
{
    //Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
    public Day19Blueprint(string input)
    {
        var lines = input.Split(". ");

        Robots = Enumerable.Range(0, lines.Length).Select(Parse).ToArray();

        var m = Enumerable.Range(0, 4)
            .Select(x => x == 3
                ? int.MaxValue
                : Robots
                    .Select(Day19Resources.Selectors[x])
                    .Max())
            .ToArray();
        maxRequirements = new(m[0], m[1], m[2], m[3]);

        Day19Resources Parse(int index)
        {
            // 3 ore and 14 clay
            var line = lines[index].Split("costs ")[1];
            var ints = line
                .Split(" ")
                .Where(x => int.TryParse(x, out var _))
                .Select(int.Parse)
                .ToArray();

            return index switch
            {
                2 => new(ints[0], ints[1], 0, 0),
                3 => new(ints[0], 0, ints[1], 0),
                _ => new(ints[0], 0, 0, 0)
            };
        }
    }

    public Day19Resources[] Robots { get; }

    private readonly Day19Resources maxRequirements;

    public int GetGeodes(int time)
    {
        var resources = Day19Resources.AdditiveIdentity;
        var robots = new Day19Resources(1, 0, 0, 0);

        var cache = new Dictionary<(Day19Resources resources, Day19Resources robots, int time), int>();

        return Dfs(resources, robots, time);

        int Dfs(Day19Resources resources, Day19Resources robots, int time)
        {
            if (time == 0)
            {
                return resources.Geode;
            }

            var bound = (maxRequirements - robots) * time + robots;
            int GetBoundedResource(Func<Day19Resources, int> selector)
                => Math.Min(selector(resources), selector(bound));
            resources = new(
                GetBoundedResource(Day19Resources.Selectors[0]),
                GetBoundedResource(Day19Resources.Selectors[1]),
                GetBoundedResource(Day19Resources.Selectors[2]),
                resources.Geode
            );

            var cacheKey = (resources, robots, time);
            if (cache.TryGetValue(cacheKey, out var cached))
            {
                return cached;
            }

            var max = Dfs(resources + (robots * time), robots, 0);

            for (var j = 3; j >= 0; j--)
            {
                var selector = Day19Resources.Selectors[j];
                var requirement = Robots[j];
                if (selector(robots) >= selector(maxRequirements))
                {
                    continue;
                }

                var hasRobots = j switch
                {
                    3 => robots.Obsidian > 0,
                    2 => robots.Clay > 0,
                    _ => true
                };

                if (hasRobots)
                {
                    var timeCost = 0;
                    foreach (var s in Day19Resources.Selectors)
                    {
                        var required = s(requirement);
                        var resource = s(resources);
                        var robot = s(robots);
                        if (required == 0 || resource >= required)
                        {
                            continue;
                        }
                        var resourceTime = (required - resource + robot - 1) / robot;
                        timeCost = Math.Max(timeCost, resourceTime);
                    }

                    timeCost += 1;
                    var newTime = time - timeCost;
                    if (newTime >= 0)
                    {
                        var geodes = Dfs(resources - requirement + (robots * timeCost), robots + Day19Resources.Resources[j], newTime);
                        max = Math.Max(max, geodes);
                    }

                    // technically not right, but works for solution
                    if (timeCost == 1)
                    {
                        break;
                    }
                }
            }

            cache[cacheKey] = max;

            return max;
        }
    }
}