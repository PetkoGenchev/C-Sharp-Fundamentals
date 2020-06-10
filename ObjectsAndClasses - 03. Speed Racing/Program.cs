using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SoftUni
{

    class Car
    {
        public Car(string model, decimal fuel, decimal consumption)
        {
            this.Model = model;
            this.Fuel = fuel;
            this.Consumption = consumption;
        }

        public string Model { get; set; }
        public decimal Fuel { get; set; }
        public decimal Consumption { get; set; }
        public int Traveled { get; set; }
    }


    class Program
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] entries = Console.ReadLine().Split(' ');

                cars.Add(new Car(entries[0], decimal.Parse(entries[1], CultureInfo.InvariantCulture), decimal.Parse(entries[2], CultureInfo.InvariantCulture)));
            }

            while (true)
            {
                var travel = Console.ReadLine();

                if (travel == "End")
                {
                    break;
                }
                else
                {
                    var truetravel = travel.Split(' ').ToList();

                    var currentCar = cars.Find(c => c.Model == truetravel[1]);

                    if (currentCar.Fuel < int.Parse(truetravel[2]) * currentCar.Consumption)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                    else
                    {
                        currentCar.Fuel -= int.Parse(truetravel[2]) * currentCar.Consumption;
                        currentCar.Traveled += int.Parse(truetravel[2]);

                    }

                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:F2} {car.Traveled}");
            }

        }
    }
}