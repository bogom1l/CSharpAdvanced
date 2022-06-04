using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine()
        {
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = 0;
            Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
    }
}
