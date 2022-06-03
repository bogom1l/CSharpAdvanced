using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine CarEngine { get; set; }

        public Cargo CarCargo { get; set; }

        public List<Tire> CarTires { get; set; }

        public Car(string model, Engine carEngine, Cargo carCargo, List<Tire> carTires)
        {
            Model = model;
            CarEngine = carEngine;
            CarCargo = carCargo;
            CarTires = carTires;
        }
    }
}
