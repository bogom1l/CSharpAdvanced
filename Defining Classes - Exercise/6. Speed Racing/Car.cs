using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        string name;
        double fuelAmount;
        double fuelConsumptionPerKilometer;
        double travelledDistance; // ???? izlishno
        public string Model { get; set; }

        public double FuelAmount{ get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public void Drive(double amountOfKm)
        {
            double neededLiters = amountOfKm * FuelConsumptionPerKilometer; //this ?

            if (FuelAmount >= neededLiters)
            {
                FuelAmount -= neededLiters;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }  
        }
    }
}