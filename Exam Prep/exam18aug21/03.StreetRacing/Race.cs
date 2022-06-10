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
            Car carToFind = Participants.Find(x => x.LicensePlate == car.LicensePlate);

            if (!Participants.Contains(carToFind))
            {
                //if (this.Participants.Capacity <= this.Capacity)
                // PAK DVUSMISLICA ??? ??   ?? ? ? ?? ?? ? ? ?? ?? ? 

                if (car.HorsePower <= this.MaxHorsePower)
                {
                    this.Participants.Add(car);
                }

            }
        }

        public bool Remove(string licensePlate)
        {
            Car carToFind = Participants.Find(x => x.LicensePlate == licensePlate);

            if (Participants.Contains(carToFind))
            {
                Participants.Remove(carToFind);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            Car carToFind = Participants.Find(x => x.LicensePlate == licensePlate);
            return carToFind;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count <= 0)
            {
                return null;
            }
            else
            {
                int mostHP = 0;

                foreach (Car currCar in Participants)
                {
                    if (currCar.HorsePower > mostHP)
                    {
                        mostHP = currCar.HorsePower;
                    }
                }

                Car carToFind = Participants.First(x => x.HorsePower == mostHP);
                return carToFind;
            }
        }

        public string Report()
        {
            string ans = "";

            ans += $"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})";

            foreach (Car currCar in Participants)
            {
                ans += $"{currCar}";
            }

            return ans;
        }



    }
}
