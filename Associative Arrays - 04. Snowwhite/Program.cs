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

            Dictionary<string, int> dwarves = new Dictionary<string, int>();

            while (true)
            {
                string entry = Console.ReadLine();

                if (entry == "Once upon a time")
                {
                    break;
                }

                string[] entryArray = entry
                        .Split(" <:> ")
                        .ToArray();


                string data = entryArray[0] + ":" + entryArray[1];
                int physics = int.Parse(entryArray[2]);

                if (dwarves.ContainsKey(data))
                {
                    if (physics > dwarves[data])
                    {
                        dwarves[data] = physics;
                    }
                }
                else
                {
                    dwarves.Add(data, physics);
                }
            }

            foreach (var item in dwarves.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarves.Where(y => y.Key.Split(":")[1] == x.Key.Split(":")[1]).Count()))
            {
                Console.WriteLine($"({item.Key.Split(":")[1]}) {item.Key.Split(":")[0]} <-> {item.Value}");
            }

        }
    }
}