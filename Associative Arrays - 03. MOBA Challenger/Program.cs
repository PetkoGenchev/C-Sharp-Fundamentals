using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace siSharp
{

    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                List<string> entry = Console.ReadLine()
                    .Split(" -> ")
                    .ToList();

                if (entry.Count == 1)
                {
                    if (entry[0] == "Season end")
                    {
                        break;
                    }
                    else
                    {
                        List<string> duelNames = entry[0]
                            .Split(" vs ")
                            .ToList();

                        string duelist1 = duelNames[0];
                        string duelist2 = duelNames[1];
                        string what = null;

                        if (players.ContainsKey(duelist1) && players.ContainsKey(duelist2))
                        {
                            var commonItems = players[duelist1].Keys.Intersect(players[duelist2].Keys);
                            if (commonItems != null)
                            {
                                foreach (var split in players[duelist1])
                                {
                                    foreach (var split2 in players[duelist2])
                                    {
                                        if (split2.Key == split.Key)
                                        {

                                            if (players[duelist1].Sum(x => x.Value) > players[duelist2].Sum(y => y.Value))
                                            {
                                                what = "remove2";

                                                break;
                                            }
                                            else if (players[duelist1].Sum(x => x.Value) < players[duelist2].Sum(y => y.Value))
                                            {
                                                what = "remove1";

                                                break;
                                            }
                                        }
                                    }
                                }

                                if (what == "remove2")
                                {
                                    players.Remove(duelist2);
                                }
                                else if (what == "remove1")
                                {
                                    players.Remove(duelist1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    string name = entry[0];
                    string position = entry[1];
                    int points = int.Parse(entry[2]);

                    if (players.ContainsKey(name))
                    {
                        if (players[name].ContainsKey(position))
                        {
                            if (points > players[name][position])
                            {
                                players[name][position] = points;
                            }
                        }
                        else
                        {
                            players[name].Add(position, points);
                        }
                    }
                    else
                    {
                        players.Add(name, new Dictionary<string, int>());
                        players[name].Add(position, points);
                    }
                }
            }

            foreach (var play in players.OrderByDescending(x => x.Value.Sum(z => z.Value)).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{play.Key}: {play.Value.Sum(f => f.Value)} skill");
                foreach (var what in play.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"- {what.Key} <::> {what.Value}");
                }
            }


        }
    }
}