using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators { get; set; } //private????

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators > this.renovators.Count)
            {
                if (renovator.Name == null)
                {
                    return $"Invalid renovator's information.";
                }
                if (renovator.Type == null)
                {
                    return $"Invalid renovator's information.";
                }
                if (renovator.Rate > 350)
                {
                    return $"Invalid renovator's rate.";
                }

                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
            else
            {
                return $"Renovators are no more needed.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            return renovators.Remove(renovator);
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(x => x.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            if (renovator != null)
            {
                renovator.Hired = true;
            }
            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.FindAll(x => x.Days >= days);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var currReno in renovators)
            {
                if (currReno.Hired == false)
                {
                    sb.AppendLine($"{currReno}");
                }
            }

            return sb.ToString().Trim();
        }

    }

}
