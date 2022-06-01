using System;
using CarManufacturer;

public class StartUp
{
    static void Main(string[] args)
    {
        Car currCar = new Car();

        currCar.Year = 1992;
        currCar.Make = "VW";
        currCar.Model = "MK3";

        Console.WriteLine($"Make: {currCar.Make}\nModel: {currCar.Model}\nYear: {currCar.Year}");
    }
}

