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
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

    }

    class Family
    {
        public List<Person> People { get; set; } = new List<Person>();

        public void AddNewPeople(string whatname, int whatage)
        {
            this.People.Add(new Person(whatname, whatage));
        }

        public Person GetOldestPerson()
        {
            return People.OrderByDescending(d => d.Age).First();
        }

    }



    class Program
    {
        static void Main()
        {

            int amount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < amount; i++)
            {
                string[] entries = Console.ReadLine().Split(' ');


                family.AddNewPeople(entries[0], int.Parse(entries[1]));

            }

            Person what = family.GetOldestPerson();

            Console.WriteLine($"{what.Name} {what.Age}");

        }


    }
}