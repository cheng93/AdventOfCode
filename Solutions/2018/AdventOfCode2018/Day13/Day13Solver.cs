namespace AdventOfCode2018.Day13
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day13Solver
    {
        public Point PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var track = new Dictionary<Point, char>();
            var carts = new SortedList<Point, Day13Cart>(new Day13PointComparer());
            var pointsWithCart = new HashSet<Point>();

            var cartIcons = new[] { '^', 'v', '<', '>' };

            for (var y = 0; y < lines.Length; y++)
            {
                var currentLine = lines[y];
                for (var x = 0; x < currentLine.Length; x++)
                {
                    var currentPoint = new Point(x, y);
                    if (cartIcons.Contains(currentLine[x]))
                    {
                        var cart = new Day13Cart
                        {
                            Position = currentPoint,
                            Direction = currentLine[x]
                        };
                        carts.Add(cart.Position, cart);
                        pointsWithCart.Add(cart.Position);
                        if (currentLine[x] == '^' || currentLine[x] == 'v')
                        {
                            track[currentPoint] = '|';
                        }
                        else
                        {
                            track[currentPoint] = '-';
                        }
                    }
                    else if (currentLine[x] != ' ')
                    {
                        track[currentPoint] = currentLine[x];
                    }
                }
            }

            while (true)
            {
                foreach (var cart in carts.Values.ToList())
                {
                    Size changeSize;
                    switch (cart.Direction)
                    {
                        case '^':
                            changeSize = new Size(0, -1);
                            break;
                        case 'v':
                            changeSize = new Size(0, 1);
                            break;
                        case '<':
                            changeSize = new Size(-1, 0);
                            break;
                        case '>':
                            changeSize = new Size(1, 0);
                            break;
                    }

                    var newPoint = Point.Add(cart.Position, changeSize);
                    if (pointsWithCart.Contains(newPoint))
                    {
                        return newPoint;
                    }
                    pointsWithCart.Remove(cart.Position);
                    cart.Position = newPoint;
                    pointsWithCart.Add(newPoint);

                    var trackItem = track[newPoint];

                    if ((cart.Direction == '>' && trackItem == '/')
                        || cart.Direction == '<' && trackItem == '\\')
                    {
                        cart.Direction = '^';
                    }
                    else if ((cart.Direction == '<' && trackItem == '/')
                        || cart.Direction == '>' && trackItem == '\\')
                    {
                        cart.Direction = 'v';
                    }
                    else if ((cart.Direction == '^' && trackItem == '/')
                        || cart.Direction == 'v' && trackItem == '\\')
                    {
                        cart.Direction = '>';
                    }
                    else if ((cart.Direction == 'v' && trackItem == '/')
                        || cart.Direction == '^' && trackItem == '\\')
                    {
                        cart.Direction = '<';
                    }
                    else if (trackItem == '+')
                    {
                        switch (cart.Direction)
                        {
                            case '^':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = '<';
                                        break;
                                    case 2:
                                        cart.Direction = '>';
                                        break;
                                }
                                break;
                            case 'v':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = '>';
                                        break;
                                    case 2:
                                        cart.Direction = '<';
                                        break;
                                }
                                break;
                            case '>':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = '^';
                                        break;
                                    case 2:
                                        cart.Direction = 'v';
                                        break;
                                }
                                break;
                            case '<':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = 'v';
                                        break;
                                    case 2:
                                        cart.Direction = '^';
                                        break;
                                }
                                break;
                        }
                        cart.Intersections++;
                    }
                }
            }
        }

        public Point PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var track = new Dictionary<Point, char>();
            var carts = new SortedList<Point, Day13Cart>(new Day13PointComparer());
            var pointsWithCart = new HashSet<Point>();

            var cartIcons = new[] { '^', 'v', '<', '>' };

            for (var y = 0; y < lines.Length; y++)
            {
                var currentLine = lines[y];
                for (var x = 0; x < currentLine.Length; x++)
                {
                    var currentPoint = new Point(x, y);
                    if (cartIcons.Contains(currentLine[x]))
                    {
                        var cart = new Day13Cart
                        {
                            Position = currentPoint,
                            Direction = currentLine[x]
                        };
                        carts.Add(cart.Position, cart);
                        pointsWithCart.Add(cart.Position);
                        if (currentLine[x] == '^' || currentLine[x] == 'v')
                        {
                            track[currentPoint] = '|';
                        }
                        else
                        {
                            track[currentPoint] = '-';
                        }
                    }
                    else if (currentLine[x] != ' ')
                    {
                        track[currentPoint] = currentLine[x];
                    }
                }
            }

            while (carts.Count > 1)
            {
                var collisionPoints = new HashSet<Point>();
                foreach (var cart in carts.Values.ToList())
                {
                    if (collisionPoints.Contains(cart.Position))
                    {
                        continue;
                    }

                    Size changeSize;
                    switch (cart.Direction)
                    {
                        case '^':
                            changeSize = new Size(0, -1);
                            break;
                        case 'v':
                            changeSize = new Size(0, 1);
                            break;
                        case '<':
                            changeSize = new Size(-1, 0);
                            break;
                        case '>':
                            changeSize = new Size(1, 0);
                            break;
                    }

                    var newPoint = Point.Add(cart.Position, changeSize);
                    if (pointsWithCart.Contains(newPoint))
                    {
                        collisionPoints.Add(newPoint);
                        carts.Remove(cart.Position);
                        carts.Remove(newPoint);
                        pointsWithCart.Remove(cart.Position);
                        pointsWithCart.Remove(newPoint);
                        continue;
                    }
                    pointsWithCart.Remove(cart.Position);
                    carts.Remove(cart.Position);
                    cart.Position = newPoint;
                    carts.Add(newPoint, cart);
                    pointsWithCart.Add(newPoint);

                    var trackItem = track[newPoint];

                    if ((cart.Direction == '>' && trackItem == '/')
                        || cart.Direction == '<' && trackItem == '\\')
                    {
                        cart.Direction = '^';
                    }
                    else if ((cart.Direction == '<' && trackItem == '/')
                        || cart.Direction == '>' && trackItem == '\\')
                    {
                        cart.Direction = 'v';
                    }
                    else if ((cart.Direction == '^' && trackItem == '/')
                        || cart.Direction == 'v' && trackItem == '\\')
                    {
                        cart.Direction = '>';
                    }
                    else if ((cart.Direction == 'v' && trackItem == '/')
                        || cart.Direction == '^' && trackItem == '\\')
                    {
                        cart.Direction = '<';
                    }
                    else if (trackItem == '+')
                    {
                        switch (cart.Direction)
                        {
                            case '^':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = '<';
                                        break;
                                    case 2:
                                        cart.Direction = '>';
                                        break;
                                }
                                break;
                            case 'v':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = '>';
                                        break;
                                    case 2:
                                        cart.Direction = '<';
                                        break;
                                }
                                break;
                            case '>':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = '^';
                                        break;
                                    case 2:
                                        cart.Direction = 'v';
                                        break;
                                }
                                break;
                            case '<':
                                switch (cart.Intersections % 3)
                                {
                                    case 0:
                                        cart.Direction = 'v';
                                        break;
                                    case 2:
                                        cart.Direction = '^';
                                        break;
                                }
                                break;
                        }
                        cart.Intersections++;
                    }
                }
            }

            return carts.First().Value.Position;
        }
    }
}