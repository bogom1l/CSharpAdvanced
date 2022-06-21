using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null)
            {
                return false;
            }
            else
            {
                data.Remove(ski);
                return true;
            }
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int Count => data.Count;

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
