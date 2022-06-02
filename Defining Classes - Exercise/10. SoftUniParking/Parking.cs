using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get { return cars; } set { cars = value; } }

        public int Capacity { get { return capacity; } set { capacity = value; } }

        public int Count { get { return Cars.Count; } }

        public Parking(int capacity)
        {
            cars = new List<Car>();
            Capacity = capacity;
        }

        public string AddCar(Car addedCar)
        {
            bool canAddCar = true;

            foreach (Car currCar in cars)
            {
                if (currCar.RegistrationNumber == addedCar.RegistrationNumber)
                {
                    return "Car with that registration number, already exists!";
                    canAddCar = false;
                }
            }

            if (cars.Count + 1 > Capacity)
            {
                return "Parking is full!";
                canAddCar = false;
            }

            if (canAddCar)
            {
                cars.Add(addedCar);
                return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
            }

            return string.Empty;
        }


        public string RemoveCar(string regNumber)
        {
            bool isAvailable = false;

            foreach (Car car in cars)
            {
                if (car.RegistrationNumber == regNumber)
                {
                    isAvailable = true;
                }
            }

            if (!isAvailable)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = cars.First(x => x.RegistrationNumber == regNumber);
                cars.Remove(carToRemove);
                return $"Successfully removed {regNumber}";
            }

            return string.Empty;
        }

        public Car GetCar(string regNumber)
        {
            Car foundCar = cars.First(x => x.RegistrationNumber == regNumber);
            return foundCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> regNumbers)
        {
            foreach (string regNum in regNumbers)
            {
                RemoveCar(regNum);
            }
        }
    }
}
