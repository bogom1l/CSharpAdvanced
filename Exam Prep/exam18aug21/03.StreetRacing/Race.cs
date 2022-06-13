using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public Race(string name, string type,int laps,int capacity,int maxHorsePower)
        {
            this.Participants = new List<Car>();

            this.Name = name;
            this.Laps= laps;
            this.Type = type;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;     
        }

        public int Count()
        {
            return Participants.Count;
        }

        public void Add(Car car)
        {   
            bool ans = Participants.Any(x => x.LicensePlate == car.LicensePlate);

            if (!ans)
            {
                if (Participants.Count < this.Capacity)
                {
                    if (car.HorsePower <= this.MaxHorsePower)
                    {
                        this.Participants.Add(car);
                    }
                }
            }   
        }

        public bool Remove(string licensePlate)
        {
            Car carToFind = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (carToFind == null)
            {
                return false;
            }   
            else
            {
                Participants.Remove(carToFind);
                return true;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            Car carToFind = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return carToFind;
        }

        public Car GetMostPowerfulCar()
        {
	/*
            int mostHP = 0;

            foreach (Car currCar in Participants)
            {
                if (currCar.HorsePower > mostHP)
                {
                    mostHP = currCar.HorsePower;
                }
            }

            Car carToFind = Participants.FirstOrDefault(x => x.HorsePower == mostHP);
            return carToFind;
	*/

	 Car carToFind = Participants.OrderbyDescending(x => x.HorsePower).FirstOrDefault();
	 return carToFind ;
        }
        

        public string Report()
        {
            var sb = new StringBuilder();
            string ans = "";

            ans += $"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})";
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (Car currCar in Participants)
            {
                ans += $"{currCar}";
                sb.AppendLine($"{currCar}");
            }

            //return ans;
            return sb.ToString().Trim();
        }



    }
}
