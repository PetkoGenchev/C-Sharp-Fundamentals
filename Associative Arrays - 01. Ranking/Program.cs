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
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> agents = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                List<string> enterContest = Console.ReadLine()
                    .Split(':')
                    .ToList();

                if (enterContest[0] == "end of contests")
                {
                    break;
                }

                contests.Add(enterContest[0], enterContest[1]);
            }

            while (true)
            {
                List<string> submissions = Console.ReadLine()
                    .Split("=>")
                    .ToList();
                if (submissions[0] == "end of submissions")
                {
                    break;
                }

                string type = submissions[0];
                string password = submissions[1];
                string name = submissions[2];
                int points = int.Parse(submissions[3]);

                if (contests.ContainsKey(type) && contests[type] == password)
                {
                    if (agents.ContainsKey(name))
                    {
                        if (agents[name].ContainsKey(type))
                        {
                            if (agents[name][type] < points)
                            {
                                agents[name][type] = points;
                            }
                        }
                        else
                        {
                            agents[name].Add(type, points);
                        }
                    }
                    else
                    {
                        agents.Add(name, new Dictionary<string, int>());
                        agents[name].Add(type, points);
                    }
                }
            }

            string maxName = "";
            int maxPoints = 0;


            foreach (var name in agents)
            {
                int temporary = 0;

                foreach (var number in name.Value)
                {
                    temporary += number.Value;
                }

                if (temporary > maxPoints)
                {
                    maxName = name.Key;
                    maxPoints = temporary;
                }
            }

            Console.WriteLine($"Best candidate is {maxName} with total {maxPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var naming in agents.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{naming.Key}");

                foreach (var ending in naming.Value.OrderByDescending(y => y.Value))
                {
                    Console.WriteLine($"#  {ending.Key} -> {ending.Value}");
                }
            }
        }
    }
}