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

            Dictionary<string, Dictionary<string, int>> judge = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individual = new Dictionary<string, int>();

            while (true)
            {
                List<string> entry = Console.ReadLine()
                    .Split(" -> ")
                    .ToList();

                if (entry[0] == "no more time")
                {
                    break;
                }
                else
                {
                    string name = entry[0];
                    string contest = entry[1];
                    int points = int.Parse(entry[2]);

                    if (judge.ContainsKey(contest))
                    {
                        if (judge[contest].ContainsKey(name))
                        {
                            if (judge[contest][name] < points)
                            {
                                judge[contest][name] = points;

                            }
                        }
                        else
                        {
                            judge[contest].Add(name, points);
                        }
                    }
                    else
                    {
                        judge.Add(contest, new Dictionary<string, int>());
                        judge[contest].Add(name, points);
                    }
                }
            }


            foreach (var ju in judge)
            {
                foreach (var person in ju.Value)
                {
                    if (individual.ContainsKey(person.Key))
                    {
                        individual[person.Key] += person.Value;
                    }
                    else
                    {
                        individual.Add(person.Key, person.Value);
                    }
                }
            }


            foreach (var final in judge)
            {
                int i = 1;

                Console.WriteLine($"{final.Key}: {final.Value.Count()} participants");

                foreach (var again in final.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{i}. {again.Key} <::> {again.Value}");
                    i++;
                }
            }
            Console.WriteLine("Individual standings:");

            int d = 1;
            foreach (var part in individual.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{d}. {part.Key} -> {part.Value}");
                d++;
            }



        }
    }
}