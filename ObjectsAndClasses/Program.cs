using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SoftUni
{

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

    }

    class Car
    {
        public string Model { get; set; }

        public List<Engine> engines { get; set; } = new List<Engine>();
        public List<Cargo> cargos { get; set; } = new List<Cargo>();

        public Car(string model)
        {
            this.Model = model;
        }

        public void AddNewEngines(int wSpeed, int wPower)
        {
            this.engines.Add(new Engine(wSpeed, wPower));
        }

        public void AddNewCargo(int wWeight, string wType)
        {
            this.cargos.Add(new Cargo(wWeight, wType));
        }

    }


    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var entry = Console.ReadLine().Split(' ').ToList();

                cars.Add(new Car(entry[0]));
                cars.Find(d => d.Model == entry[0]).AddNewEngines(int.Parse(entry[1]), int.Parse(entry[2]));
                cars.Find(d => d.Model == entry[0]).AddNewCargo(int.Parse(entry[3]), (entry[4]));
            }

            var need = Console.ReadLine();


            foreach (Car car in cars)
            {
                if (need == "fragile")
                {
                    if (car.cargos.Any(x => x.Type == need) && car.cargos.Any(y => y.Weight < 1000))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
                else if (need == "flamable")
                {
                    if (car.cargos.Any(x => x.Type == need) && car.engines.Any(y => y.Power > 250))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }

        }
    }
}