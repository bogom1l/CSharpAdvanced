using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine CarEngine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public Car()
        {
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine carEngine)
        {
            Model = model;
            CarEngine = carEngine;
            Weight = 0;
            Color = "n/a";
        }

        public Car(string model, Engine carEngine, int weight)
        {
            Model = model;
            CarEngine = carEngine;
            Weight = weight;
            Color = "n/a";
        }

        public Car(string model, Engine carEngine, int weight, string color)
        {
            Model = model;
            CarEngine = carEngine;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            string answer =
                $"{Model}:\n" +
                $" {CarEngine.Model}\n" +
                $"  Power: {CarEngine.Power}\n" +
                $"  Displacement: {CarEngine.Displacement}\n" +
                $"  Efficiency: {CarEngine.Efficiency}\n" +
                $" Weight: {Weight}\n" +
                $" Color: {Color}";

            return answer;
        }
    }
}
