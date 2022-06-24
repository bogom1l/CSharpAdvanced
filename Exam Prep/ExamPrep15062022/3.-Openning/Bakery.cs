using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Bakery(string name, int capacity)
        {
            this.data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Employee employee)
        {
            if (Capacity > this.data.Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(GetEmployee(name));
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public int Count => this.data.Count;

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (Employee emp in this.data)
            {
                sb.AppendLine($"{emp}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
