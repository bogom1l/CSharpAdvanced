using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }

        public Car(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Year = year;
            Model = model;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} ({Year})".TrimEnd();
        }

    }
}
