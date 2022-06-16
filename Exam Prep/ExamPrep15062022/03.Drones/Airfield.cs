using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public int Count => Drones.Count; 

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || (drone.Range < 5 || drone.Range > 10))
            {
                return "Invalid drone.";
            }

            if (this.Capacity <= this.Drones.Count)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";     
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(x => x.Name == name))
            {
                Drone droneToRemove = Drones.FirstOrDefault(x => x.Name == name);
                if (droneToRemove != null)
                {
                    Drones.Remove(droneToRemove);
                    return true;
                }
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.RemoveAll(x => x.Brand == brand);
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone == null)
            {
                return null;
            }

            drone.Available = false;
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> droneList = Drones.Where(x => x.Range >= range).ToList();

            foreach (Drone currDrone in droneList)
            {
                currDrone.Available = false;
            }
            
            return droneList;
        }
        
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            sb.AppendLine($"{string.Join(Environment.NewLine, Drones)}");

            return sb.ToString().Trim();
        }
    }
}
