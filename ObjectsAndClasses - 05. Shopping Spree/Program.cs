using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SoftUni
{
    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> BagOfProducts { get; set; } = new List<string>();

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
        }

        public void AddBags(string bags)
        {
            this.BagOfProducts.Add(bags);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }



    class Program
    {
        static void Main()
        {

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            var peopleAdd = Console.ReadLine().Split(';').ToList();
            for (int i = 0; i < peopleAdd.Count; i++)
            {
                var addPeople = peopleAdd[i].Split('=').ToList();
                people.Add(new Person(addPeople[0], int.Parse(addPeople[1])));
            }


            var productAdd = Console.ReadLine().Split(';').ToList();
            for (int j = 0; j < productAdd.Count; j++)
            {
                var addProduct = productAdd[j].Split('=').ToList();
                products.Add(new Product(addProduct[0], int.Parse(addProduct[1])));
            }


            while (true)
            {
                var purchases = Console.ReadLine();

                if (purchases == "END")
                {
                    break;
                }
                else
                {
                    var listingpurchases = purchases.Split(' ').ToList();

                    if (people.Find(n => n.Name == listingpurchases[0]).Money < products.Find(w => w.Name == listingpurchases[1]).Cost)
                    {
                        Console.WriteLine($"{listingpurchases[0]} can't afford {listingpurchases[1]}");
                    }
                    else
                    {
                        people.Find(n => n.Name == listingpurchases[0]).AddBags(listingpurchases[1]);
                        people.Find(k => k.Name == listingpurchases[0]).Money -= products.Find(l => l.Name == listingpurchases[1]).Cost;
                        Console.WriteLine($"{listingpurchases[0]} bought {listingpurchases[1]}");
                    }

                }
            }

            foreach (Person person in people)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    var everything = string.Join(", ", person.BagOfProducts);
                    Console.WriteLine($"{person.Name} - {everything}");
                }
            }

        }
    }
}