using System.Linq;

namespace AdventOfCode2019.Day06
{
    public class Day06Orbit
    {
        public Day06Orbit(string orbit)
        {
            var split = orbit.Split(')').ToArray();
            this.Orbitted = split[0];
            this.OrbitBy = split[1];
        }

        public string Orbitted { get; }
        public string OrbitBy { get; }
    }
}