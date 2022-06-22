using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count < this.Capacity)
            {
                if (!Ingredients.Any(x => x.Name == ingredient.Name))
                {
                    Ingredients.Add(ingredient);
                }
            }
        }

        public bool Remove(string name)
        {
            return Ingredients.Remove(FindIngredient(name));
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
