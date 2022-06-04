using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Engine currEngine = new Engine();

                string input = Console.ReadLine();
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currModel = tokens[0];
                int currPower = int.Parse(tokens[1]);

                currEngine = new Engine(currModel, currPower);

                if (tokens.Length == 3)
                {
                    int currDisplacement = int.Parse(tokens[2]);
                    currEngine = new Engine(currModel, currPower, currDisplacement);
                    if (tokens.Length == 4)
                    {
                        string currEfficiency = tokens[3];
                        currEngine = new Engine(currModel, currPower, currDisplacement, currEfficiency);
                    }
                }

                engines.Add(currEngine);
            }

            List<Car> cars = new List<Car>();

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                Car currCar = new Car();

                string input = Console.ReadLine();
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currModel = tokens[0];
                string currCarEngineModel = tokens[1];

                Engine currCarEngine = engines.First(x => x.Model == currCarEngineModel);

                currCar = new Car(currModel, currCarEngine);

                if (tokens.Length == 3)
                {
                    int currWeight = int.Parse(tokens[2]);

                    currCar = new Car(currModel, currCarEngine, currWeight);

                    if (tokens.Length == 4)
                    {
                        string currColor = tokens[3];
                        currCar = new Car(currModel, currCarEngine, currWeight, currColor);
                    }
                }

                cars.Add(currCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }


        }
    }
}
