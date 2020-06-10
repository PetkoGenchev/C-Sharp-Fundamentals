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

            string code = @"%([A-Z][a-z]+)%[^|%$.]*<(\w+)>[^|%$.]*\|(\d+)\|[^|%$.]*?(\d+\.?\d*)\$";
            Regex regex = new Regex(code);

            double income = 0;

            while (true)
            {
                string entry = Console.ReadLine();

                if (entry == "end of shift")
                {
                    Console.WriteLine($"Total income: {income:F2}");
                    break;
                }

                Match match = regex.Match(entry);

                if (match.Success)
                {
                    double add = int.Parse(match.Groups[3].Value) * double.Parse(match.Groups[4].Value);
                    income += add;
                    Console.WriteLine($"{match.Groups[1].Value}: {match.Groups[2].Value} - {add:F2}");

                }

            }
        }
    }
}
