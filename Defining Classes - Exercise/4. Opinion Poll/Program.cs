using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string currName = tokens[0];
                int currAge = int.Parse(tokens[1]);

                Person currPerson = new Person(currName, currAge);

                listOfPeople.Add(currPerson);
            }

            List<Person> finalList1 = listOfPeople.OrderBy(p => p.Name).ToList();

            List<Person> finalList2 = finalList1.Where(x => x.Age > 30).ToList();

            foreach (var currPerson in finalList2)
            {
                Console.WriteLine($"{currPerson.Name} {currPerson.Age}");
            }
            
        }
    }
}
