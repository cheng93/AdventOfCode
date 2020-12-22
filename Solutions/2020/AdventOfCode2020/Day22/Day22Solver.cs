using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day22
{
    public class Day22Solver
    {
        public int PuzzleOne(string input)
        {
            var players = input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(x => x
                    .Split(Environment.NewLine)
                    .Skip(1)
                    .Select(int.Parse))
                .Select(x => new Queue<int>(x))
                .ToArray();

            while (players.All(x => x.Count != 0))
            {
                var card1 = players[0].Dequeue();
                var card2 = players[1].Dequeue();
                if (card1 > card2)
                {
                    players[0].Enqueue(card1);
                    players[0].Enqueue(card2);
                }
                else
                {
                    players[1].Enqueue(card2);
                    players[1].Enqueue(card1);
                }
            }

            var winner = players[0].Count == 0
                ? players[1]
                : players[0];

            var multiplier = winner.Count;

            return winner.Aggregate(
                0,
                (agg, cur) => agg + cur * multiplier--);
        }

        public long PuzzleTwo(string input)
        {
            var players = input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(x => x
                    .Split(Environment.NewLine)
                    .Skip(1)
                    .Select(int.Parse))
                .Select(x => new Queue<int>(x))
                .ToArray();

            int RunGame(Queue<int> player1, Queue<int> player2)
            {
                var player1History = new HashSet<string>();
                var player2History = new HashSet<string>();
                while (new[] { player1, player2 }.All(x => x.Count != 0))
                {
                    var str1 = string.Join(",", player1);
                    var str2 = string.Join(",", player2);
                    if (player1History.Contains(str1)
                        || player2History.Contains(str2))
                    {
                        return 0;
                    }

                    player1History.Add(str1);
                    player2History.Add(str2);

                    var card1 = player1.Dequeue();
                    var card2 = player2.Dequeue();

                    var winner = 0;
                    if (player1.Count >= card1
                        && player2.Count >= card2)
                    {
                        winner = RunGame(new Queue<int>(player1.Take(card1)), new Queue<int>(player2.Take(card2)));
                    }
                    else
                    {
                        winner = card1 > card2 ? 0 : 1;
                    }

                    if (winner == 0)
                    {
                        player1.Enqueue(card1);
                        player1.Enqueue(card2);
                    }
                    else
                    {
                        player2.Enqueue(card2);
                        player2.Enqueue(card1);
                    }
                }

                return player1.Count == 0 ? 1 : 0;
            }

            var gameResult = RunGame(players[0], players[1]);

            var winner = players[gameResult];

            var multiplier = winner.Count;
            return winner.Aggregate(
                0,
                (agg, cur) => agg + cur * multiplier--);
        }
    }
}