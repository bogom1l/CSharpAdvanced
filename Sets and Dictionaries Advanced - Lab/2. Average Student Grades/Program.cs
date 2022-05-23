using System;
using System.Collections.Generic;
using System.Linq;


namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currName = tokens[0];
                decimal currGrade = decimal.Parse(tokens[1]);

                if (!dict.ContainsKey(currName))
                {
                    dict[currName] = new List<decimal>();
                }

                dict[currName].Add(currGrade);
            }

            foreach (var kvp in dict)
            {
                string currName = kvp.Key;
                List<decimal> currGrades = kvp.Value;

                Console.Write($"{currName} -> ");
                foreach (var grade in currGrades)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {currGrades.Average():f2})");

                Console.WriteLine();
            }



        }
    }
}
