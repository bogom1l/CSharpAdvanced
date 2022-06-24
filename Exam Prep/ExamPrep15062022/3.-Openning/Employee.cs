using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employee: {Name}, {Age} ({Country})");
            return sb.ToString().TrimEnd();
        }
    }
}
