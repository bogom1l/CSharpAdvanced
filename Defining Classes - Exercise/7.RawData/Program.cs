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
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                string currModel = tokens[0];

                int currEngineSpeed = int.Parse(tokens[1]);
                int currEnginePower = int.Parse(tokens[2]);

                int currCargoWeight = int.Parse(tokens[3]);
                string currCargoType = tokens[4];

                double currTire1Pressure = double.Parse(tokens[5]);
                int currTire1Age = int.Parse(tokens[6]);
                double currTire2Pressure = double.Parse(tokens[7]);
                int currTire2Age = int.Parse(tokens[8]);
                double currTire3Pressure = double.Parse(tokens[9]);
                int currTire3Age = int.Parse(tokens[10]);
                double currTire4Pressure = double.Parse(tokens[11]);
                int currTire4Age = int.Parse(tokens[12]);

                Engine currEngine = new Engine(currEngineSpeed, currEnginePower);

                Cargo currCargo = new Cargo(currCargoType, currCargoWeight);
    
                Tire currTire1 = new Tire(currTire1Age, currTire1Pressure);
                Tire currTire2 = new Tire(currTire2Age, currTire2Pressure);
                Tire currTire3 = new Tire(currTire3Age, currTire3Pressure);
                Tire currTire4 = new Tire(currTire4Age, currTire4Pressure);

                List<Tire> currTireList = new List<Tire>();
                currTireList.Add(currTire1);
                currTireList.Add(currTire2);
                currTireList.Add(currTire3);
                currTireList.Add(currTire4);

                Car currCar = new Car(currModel, currEngine, currCargo, currTireList);

                cars.Add(currCar);
            }

            string wantedCargo = Console.ReadLine();

            if (wantedCargo == "fragile")
            {
                List<Car> newCarList = cars.Where(car => car.CarCargo.Type == wantedCargo)
                    .Where(x => x.CarTires.Any(t => t.Pressure < 1))
                    .ToList();

                foreach (Car car in newCarList)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (wantedCargo == "flammable")
            {
                List<Car> newCarList = cars.Where(car => car.CarCargo.Type == wantedCargo)
                    .Where(x => x.CarEngine.Power > 250)
                    .ToList();

                foreach (Car car in newCarList)
                {
                    Console.WriteLine(car.Model);
                }
            }

            


        }
    }
}
