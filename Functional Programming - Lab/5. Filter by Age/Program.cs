using System;
using System.Linq;
using System.Collections.Generic;


// this task is OBURKANA QKO, so we do something cool and elegant here and ignore the task


namespace _5._Filter_by_Age
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> ppl = new List<Person>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                ppl.Add(new Person(name, age));
            }

            foreach (var currPerson in ppl)
            {
                string currName = currPerson.Name;
                int currAge = currPerson.Age;
                Console.WriteLine($"{currName} - {currAge}");
            }
        }        
    }
}

/*
 input:::

5
Lucas, 20
Tomas, 18
Mia, 29
Noah, 31
Simo, 16

*/