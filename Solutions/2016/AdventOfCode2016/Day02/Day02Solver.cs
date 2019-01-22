namespace AdventOfCode2016.Day02
{
    using System;
    using System.Collections.Generic;

    public class Day02Solver
    {
        public string PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var movement = new Dictionary<char, int>()
            {
                { 'U', -3 },
                { 'R', 1 },
                { 'D', 3 },
                { 'L', -1 }
            };

            var number = 5;
            var code = string.Empty;

            foreach (var line in lines)
            {
                foreach (var letter in line)
                {
                    switch (letter)
                    {
                        case 'U':
                        case 'D':
                            var vertical = number + movement[letter];
                            if (vertical < 1 || vertical > 9)
                            {
                                continue;
                            }
                            break;
                        case 'R':
                            if (number % 3 == 0)
                            {
                                continue;
                            }
                            break;
                        case 'L':
                            if (number % 3 == 1)
                            {
                                continue;
                            }
                            break;
                    }

                    number += movement[letter];
                }

                code += number.ToString();
            }

            return code;
        }

        public string PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var cannotMove = new Dictionary<char, HashSet<int>>()
            {
                { 'U', new HashSet<int>() { 1, 2, 4, 5, 9 } },
                { 'R', new HashSet<int>() { 1, 4, 9, 12, 13 } },
                { 'D', new HashSet<int>() { 5, 9, 10, 12, 13 } },
                { 'L', new HashSet<int>() { 1, 2, 5, 10, 13 } }
            };

            var movement = new Dictionary<char, int>()
            {
                { 'U', -4 },
                { 'R', 1 },
                { 'D', 4 },
                { 'L', -1 }
            };

            var number = 5;
            var code = string.Empty;

            foreach (var line in lines)
            {
                foreach (var letter in line)
                {
                    if (cannotMove[letter].Contains(number))
                    {
                        continue;
                    }

                    var oldNumber = number;
                    number += movement[letter];

                    if ((letter == 'U' && oldNumber % 10 == 3)
                        || (letter == 'D' && oldNumber % 10 == 1))
                    {
                        number -= movement[letter] / 2;
                    }
                }

                char NumberToKeypad(int n)
                {
                    if (n > 9)
                    {
                        return (char)((int)'A' + (n % 10));
                    }
                    else
                    {
                        return n.ToString()[0];
                    }
                }

                code += NumberToKeypad(number).ToString();
            }

            return code;
        }
    }
}