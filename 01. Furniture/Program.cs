using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PetkoCSharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            string totalRegex = @">>([A-Za-z]+)<<(\d+\.?\d*)!(\d+)";
            Regex regex = new Regex(totalRegex);

            Console.WriteLine("Bought furniture:");

            while (true)
            {
                string entry = Console.ReadLine();

                if (entry == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(entry);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    Console.WriteLine(name);
                    sum += double.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
                }
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
