using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public void Add(Car car)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(GetCar(manufacturer, model));
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int Count => data.Count;

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
