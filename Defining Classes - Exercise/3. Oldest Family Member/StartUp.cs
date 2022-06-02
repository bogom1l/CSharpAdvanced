using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string currName = tokens[0];
                int currAge = int.Parse(tokens[1]);

                Person currPerson = new Person(currName, currAge);

                family.AddMember(currPerson);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        }
    }
}
