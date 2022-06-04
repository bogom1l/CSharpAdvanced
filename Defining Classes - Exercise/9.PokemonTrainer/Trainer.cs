using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> CollectionOfPokemons { get; set; }

        public Trainer(string n)
        {
            Name = n;
            NumberOfBadges = 0;
            CollectionOfPokemons = new List<Pokemon>();
        }
        public void AddPokemon(Pokemon p)
        {
            CollectionOfPokemons.Add(p);
        }

        public void PrintCollection()
        {
            foreach (var p in CollectionOfPokemons)
            {
                Console.WriteLine(p);
            }
        }

        public override string ToString()
        {
            string ans = $"T: n: {Name}, numbBadges: {NumberOfBadges}, collection: = ";
            Console.WriteLine(ans);
            PrintCollection();

            return "";
            //return ans;
        }
    }
}
