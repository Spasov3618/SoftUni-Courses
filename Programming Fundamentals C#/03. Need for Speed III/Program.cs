using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Need_for_Speed_III
{
    class Car
    {
        public Car(string model,int km, int fuel)
        {
            Model = model;
            Km = km;
            Fuel = fuel;
        }
        public string Model { get; set; }
        public int Km { get; set; }
        public int Fuel { get; set; }  
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int numCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numCars; i++)
            {
                string[] newcars = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = newcars[0];
                int km = int.Parse(newcars[1]);
                int fuel = int.Parse(newcars[2]);
                Car newmodel = new Car(model, km, fuel);
                cars.Add(newmodel);
            }
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arg = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (arg[0] == "Drive")
                {
                    string model = arg[1];
                    int km = int.Parse(arg[2]);
                    int fuel = int.Parse(arg[3]);
                    Car search = cars.FirstOrDefault(x => x.Model == model);
                    if (search.Fuel >= fuel)
                    {
                        search.Km += km;
                        search.Fuel -= fuel;
                        Console.WriteLine($"{model} driven for {km} kilometers. {fuel} liters of fuel consumed.");
                        if (search.Km >= 100000)
                        {
                            cars.Remove(search);
                            Console.WriteLine($"Time to sell the {model}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (arg[0] == "Refuel")
                {
                    string model = arg[1];
                    int fuel = int.Parse(arg[2]);
                    Car search = cars.FirstOrDefault(x => x.Model == model);
                    if (search.Fuel + fuel > 75)
                    {
                        int refuel = 75 - search.Fuel;
                        search.Fuel += refuel;
                        Console.WriteLine($"{model} refueled with {refuel} liters");
                    }
                    else
                    {
                        search.Fuel += fuel;
                        Console.WriteLine($"{model} refueled with {fuel} liters");
                    }
                }
                else if (arg[0] == "Revert")
                {
                    string model = arg[1];
                    int km = int.Parse(arg[2]);
                    Car search = cars.FirstOrDefault(x => x.Model == model);
                    if (search.Km - km < 10000)
                    {
                        search.Km = 10000;
                    }
                    else
                    {
                        search.Km -= km;
                        Console.WriteLine($"{model} mileage decreased by {km} kilometers");
                    }

                }

            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} -> Mileage: {car.Km} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }      
    }
}
