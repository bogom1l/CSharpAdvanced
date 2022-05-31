using System;
using System.Linq;
using System.Collections.Generic;

namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                Predicate<string> predicate = GetPredicate(command);

                if (action == "Double")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        string person = people[i];
                        if (predicate(person))
                        {
                            people.Insert(people.IndexOf(person) + 1, person);
                        }
                        i++;
                    }
                }
                else if (action == "Remove")
                {
                    people.RemoveAll(predicate);
                }

                command = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        static Predicate<string> GetPredicate(string input)
        {
            string command = input.Split()[1];
            string arg = input.Split()[2];

            Predicate<string> predicate = null;

            if (command == "StartsWith")
            {
                predicate = name => name.StartsWith(arg);
            }
            else if (command == "EndsWith")
            {
                predicate = name => name.EndsWith(arg);
            }
            else if (command == "Length")
            {
                predicate = name => name.Length == int.Parse(arg);
            }

            return predicate;
        }

    }
}
