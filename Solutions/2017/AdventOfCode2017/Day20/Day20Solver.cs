namespace AdventOfCode2017.Day20
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day20Solver
    {
        public int PuzzleOne(string input)
        {
            var particles = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => new Day20Particle(i, x));

            var minAcceleration = long.MaxValue;
            var minAccelerationParticles = new List<Day20Particle>();

            foreach (var particle in particles)
            {
                var acceleration = particle.Acceleration;
                var magnitude = Math.Abs(acceleration.X) + Math.Abs(acceleration.Y) + Math.Abs(acceleration.Z);
                if (magnitude < minAcceleration)
                {
                    minAccelerationParticles = new List<Day20Particle>();
                    minAcceleration = magnitude;
                }
                if (magnitude == minAcceleration)
                {
                    minAccelerationParticles.Add(particle);
                }
            }

            var minVelocity = long.MaxValue;
            var minVelocityParticles = new List<Day20Particle>();

            foreach (var particle in minAccelerationParticles)
            {
                var velocity = particle.Velocity;
                var acceleration = particle.Acceleration;

                var magnitude = (Math.Abs(velocity.X) * (SameDirection(velocity, acceleration, x => x.X) ? 1 : -1))
                    + (Math.Abs(velocity.Y) * (SameDirection(velocity, acceleration, x => x.Y) ? 1 : -1))
                    + (Math.Abs(velocity.Z) * (SameDirection(velocity, acceleration, x => x.Z) ? 1 : -1));
                if (magnitude < minVelocity)
                {
                    minVelocityParticles = new List<Day20Particle>();
                    minVelocity = magnitude;
                }
                if (magnitude == minVelocity)
                {
                    minVelocityParticles.Add(particle);
                }
            }

            var minPosition = long.MaxValue;
            var minPositionParticles = new List<Day20Particle>();

            foreach (var particle in minVelocityParticles)
            {
                var position = particle.Position;
                var acceleration = particle.Acceleration;

                var magnitude = (Math.Abs(position.X) * (SameDirection(position, acceleration, x => x.X) ? 1 : -1))
                    + (Math.Abs(position.Y) * (SameDirection(position, acceleration, x => x.Y) ? 1 : -1))
                    + (Math.Abs(position.Z) * (SameDirection(position, acceleration, x => x.Z) ? 1 : -1));
                if (magnitude < minPosition)
                {
                    minPositionParticles = new List<Day20Particle>();
                    minPosition = magnitude;
                }
                if (magnitude == minPosition)
                {
                    minPositionParticles.Add(particle);
                }
            }

            return minPositionParticles.First().Id;
        }
        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var particles = new List<Day20Particle>();
            var collisions = new SortedDictionary<long, List<(int A, int B)>>();
            var particleIds = new HashSet<int>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var particle = new Day20Particle(i, line);
                particles.Add(particle);
                particleIds.Add(particle.Id);
            }

            for (var i = 0; i < particles.Count - 1; i++)
            {
                for (var j = i + 1; j < particles.Count; j++)
                {
                    var particleA = particles[i];
                    var particleB = particles[j];

                    Func<Day20Point, long> GetAxis(int k)
                    {
                        switch (k)
                        {
                            case 0:
                                return (Day20Point x) => x.X;
                            case 1:
                                return (Day20Point x) => x.Y;
                            case 2:
                                return (Day20Point x) => x.Z;
                        }
                        throw new Exception();
                    }

                    var times = new Dictionary<long, int>();
                    var isValid = true;
                    var stationary = 0;

                    // T^2(a-b)+T(a+2v-b-2w)+2(p-q) = 0
                    for (var k = 0; k < 3; k++)
                    {
                        if (!isValid)
                        {
                            break;
                        }
                        var a = GetAxis(k)(particleA.Acceleration) - GetAxis(k)(particleB.Acceleration);
                        var b = GetAxis(k)(particleA.Acceleration) + (2 * GetAxis(k)(particleA.Velocity)) - GetAxis(k)(particleB.Acceleration) - (2 * GetAxis(k)(particleB.Velocity));
                        var c = 2 * (GetAxis(k)(particleA.Position) - GetAxis(k)(particleB.Position));

                        var discriminant = (b * b) - (4 * a * c);
                        if (a == 0 && b == 0 && c == 0)
                        {
                            stationary++;
                            continue;
                        }
                        if (a == 0)
                        {
                            if (b != 0 && -c % b == 0)
                            {
                                var time = -c / b;
                                if (time >= 0)
                                {
                                    if (!times.ContainsKey(time))
                                    {
                                        times.Add(time, 0);
                                    }
                                    times[time]++;
                                    continue;
                                }
                            }
                        }
                        else if (discriminant >= 0)
                        {
                            var sqrt = Math.Sqrt(discriminant);
                            var minTime = (-b - sqrt) / (2 * a);
                            var maxTime = (-b + sqrt) / (2 * a);
                            if ((minTime >= 0 && minTime % 1 == 0) || (maxTime >= 0 && maxTime % 1 == 0))
                            {
                                if (minTime >= 0 && minTime % 1 == 0)
                                {
                                    if (!times.ContainsKey((long)minTime))
                                    {
                                        times.Add((long)minTime, 0);
                                    }
                                    times[(long)minTime]++;
                                }
                                if (maxTime >= 0 && maxTime % 1 == 0 && minTime != maxTime)
                                {
                                    if (!times.ContainsKey((long)maxTime))
                                    {
                                        times.Add((long)maxTime, 0);
                                    }
                                    times[(long)maxTime]++;
                                }
                                continue;
                            }
                        }

                        isValid = false;
                    }

                    if (times.Any(x => x.Value == 3 - stationary) && isValid)
                    {
                        var time = times
                            .OrderByDescending(x => x.Value)
                            .ThenBy(x => x.Key)
                            .First()
                            .Key;

                        if (!collisions.ContainsKey(time))
                        {
                            collisions.Add(time, new List<(int A, int B)>());
                        }
                        collisions[time].Add((particleA.Id, particleB.Id));
                    }
                }
            }

            while (collisions.Any())
            {
                var latestCollisionsTime = collisions.First();
                var latestCollisions = latestCollisionsTime.Value;

                var collidedIds = new HashSet<int>();

                foreach (var collision in latestCollisions)
                {
                    if (particleIds.Contains(collision.A) && particleIds.Contains(collision.B))
                    {
                        collidedIds.Add(collision.A);
                        collidedIds.Add(collision.B);
                    }
                }

                foreach (var id in collidedIds)
                {
                    particleIds.Remove(id);
                }

                collisions.Remove(latestCollisionsTime.Key);
            }

            return particleIds.Count;
        }

        private static bool SameDirection(Day20Point a, Day20Point b, Func<Day20Point, long> op)
        {
            return Math.Sign(op(a)) * Math.Sign(op(b)) != -1;
        }
    }
}