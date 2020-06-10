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

            string code = @"\S*@([A-Z][a-z]+)[^@\-!:>]*:([\d]+)!([AD])![^@\-!:>]*->([\d]+)";
            Regex regex = new Regex(code);

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> planets = new Dictionary<string, List<string>>
            {
                { "Attacked", new List<string>() },
                { "Destroyed", new List<string>() }
            };

            for (int i = 0; i < n; i++)
            {
                string entry = Console.ReadLine();
                int count = Regex.Matches(entry, @"S|T|A|R|s|t|a|r").Count;

                StringBuilder finalText = new StringBuilder();

                char[] entryChar = entry
                    .ToCharArray();

                for (int j = 0; j < entryChar.Length; j++)
                {
                    char lettertoUse = Convert.ToChar(entryChar[j] - count);

                    finalText.Append(lettertoUse);
                }

                string notBuilder = finalText.ToString();

                Match match = regex.Match(notBuilder);

                if (match.Success)
                {
                    if (match.Groups[3].Value == "A")
                    {
                        planets["Attacked"].Add(match.Groups[1].Value);
                    }
                    else
                    {
                        planets["Destroyed"].Add(match.Groups[1].Value);
                    }
                }

            }

            foreach (var item in planets)
            {
                Console.WriteLine($"{item.Key} planets: {item.Value.Count}");
                foreach (var what in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {what}");
                }
            }


        }
    }
}
