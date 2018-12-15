namespace AdventOfCode2018.Day15
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day15ShortestPaths
    {
        public IEnumerable<ICollection<Point>> Get(IDictionary<Point, char> map, Point source, Point destination)
        {
            var visited = new HashSet<Point>();

            var queue = new Queue<Node>(new[] { Node.Default(source) });
            visited.Add(source);

            var minLength = int.MaxValue;

            var sizes = new[]
            {
                new Size(0, -1),
                new Size(-1, 0),
                new Size(1, 0),
                new Size(0, 1)
            };

            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node.Point == destination && node.Distance <= minLength)
                {
                    minLength = node.Distance;
                    yield return node.Points;
                }
                else
                {
                    foreach (var size in sizes)
                    {
                        var adjacentPoint = Point.Add(node.Point, size);
                        if (map.ContainsKey(adjacentPoint)
                            && map[adjacentPoint] == '.'
                            && !visited.Contains(adjacentPoint)
                            && node.Distance < minLength)
                        {
                            queue.Enqueue(new Node(node, adjacentPoint));
                            visited.Add(adjacentPoint);
                        }
                    }
                }
            }
        }

        private class Node
        {
            public List<Point> Points { get; set; } = new List<Point>();
            public Point Point { get; set; }
            public int Distance { get; set; }

            public Node(Node node, Point point)
            {
                this.Point = point;
                this.Points = new List<Point>(node.Points) { point };
                this.Distance = node.Distance + 1;
            }

            private Node(Point point)
            {
                this.Point = point;
            }

            public static Node Default(Point point) => new Node(point);
        }
    }
}