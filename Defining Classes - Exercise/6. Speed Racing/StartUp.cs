using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                string currModel = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionPerKilometer = double.Parse(tokens[2]);

                Car currCar = new Car(currModel, fuelAmount, fuelConsumptionPerKilometer);

                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                //"Drive {carModel} {amountOfKm}"
                string[] tokens = command.Split();

                string action = tokens[0];
                string currCarModel = tokens[1];
                double currAmountOfKm = double.Parse(tokens[2]);

                Car currCarToDrive = cars.First(car => car.Model == currCarModel);
                currCarToDrive.Drive(currAmountOfKm);

                command = Console.ReadLine();
            }

            //"{model} {fuelAmount} {distanceTraveled}"
            foreach (Car currCar in cars)
            {
                Console.WriteLine($"{currCar.Model} {currCar.FuelAmount:f2} {currCar.TravelledDistance}");
            }

        }
    }
}
