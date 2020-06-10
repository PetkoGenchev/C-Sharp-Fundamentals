using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.ExceptionServices;
using System.Diagnostics.Tracing;

namespace PetkoCSharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> racing = new Dictionary<string, int>();

            foreach (var item in racers)
            {
                racing.Add(item, 0);
            }

            string code1 = @"[A-Za-z]+";
            string code2 = @"\d";

            Regex regex1 = new Regex(code1);
            Regex regex2 = new Regex(code2);



            while (true)
            {
                string entry = Console.ReadLine();

                if (entry == "end of race")
                {
                    break;
                }

                MatchCollection charName = regex1.Matches(entry);

                string name = string.Join("", charName);

                if (racing.ContainsKey(name))
                {
                    MatchCollection digitDistance = regex2.Matches(entry);

                    int distance = 0;

                    foreach (Match item in digitDistance)
                    {
                        distance += int.Parse(item.Value);
                    }

                    racing[name] += distance;
                }
            }
            int count = 1;

            foreach (var item in racing.OrderByDescending(x => x.Value))
            {
                if (count == 4)
                {
                    break;
                }

                string whaaat = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count}{whaaat} place: {item.Key}");
                count++;

            }
        }
    }
}
