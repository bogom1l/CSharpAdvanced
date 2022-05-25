using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.__SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            var subDict = new Dictionary<string, int>();   

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] tokens = input.Split("-");
                string currUsername = tokens[0];
                string currLanguage = tokens[1];
                int currPoints = 0;
                if (currLanguage != "banned")
                {
                    currPoints = int.Parse(tokens[2]);
                }

                if (!dict.ContainsKey(currUsername))
                {
                    dict.Add(currUsername, new Dictionary<string, int>());

                    if (!subDict.ContainsKey(currLanguage))
                    {
                        subDict[currLanguage] = 0;
                    }
                }

                if (currLanguage != "banned")
                {
                    dict[currUsername][currLanguage] = currPoints;
                    subDict[currLanguage]++;
                }

                if (currLanguage == "banned")
                {
                    dict.Remove(currUsername);
                }

                input = Console.ReadLine();
            }

            dict = dict.OrderByDescending(x => x.Value.OrderBy(y => y.Value)).ToDictionary(x => x.Key, y => y.Value); // THE ONLY MISTAKE IN THIS ZADACHA

            Console.WriteLine("Results: ");
            foreach (var item in dict)
            {
                string currName = item.Key;
                Console.Write($"{currName}");

                foreach (var v in item.Value)
                {
                    int currPoints = v.Value;
                    Console.Write($" | {currPoints}");
                }
                Console.WriteLine();
            }

            subDict = subDict.OrderByDescending(x => x.Value).ThenBy(v => v.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Submissions:");
            foreach (var item in subDict)
            {
                string currLanguage = item.Key;
                int subCount = item.Value;

                Console.WriteLine($"{currLanguage} - {subCount}");
                
            }
        }
    }
}
