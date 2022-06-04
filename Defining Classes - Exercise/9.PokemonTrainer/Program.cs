using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] tokens = input.Split();

                string currTrainerName = tokens[0];

                string currPokemonName = tokens[1];
                string currPokemonElement = tokens[2];
                int currPokemonHealth = int.Parse(tokens[3]);

                Pokemon currPokemon = new Pokemon(currPokemonName, currPokemonElement, currPokemonHealth);

                Trainer currTrainer = trainers.Find(t => t.Name == currTrainerName);

                if (currTrainer == null)
                {
                    currTrainer = new Trainer(currTrainerName);
                    trainers.Add(currTrainer);
                }

                currTrainer.AddPokemon(currPokemon);

                input = Console.ReadLine();
            }

            /*
            foreach (var t in trainers)
            {
                Console.WriteLine(t);
            }
            */

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Fire")
                {
                    CheckTrainersPokemon(trainers, command);
                }
                else if (command == "Water")
                {
                    CheckTrainersPokemon(trainers, command);
                }
                else if (command == "Electricity")
                {
                    CheckTrainersPokemon(trainers, command);
                }
                else
                {
                    int a = 1;
                }

                command = Console.ReadLine();
            }

            //print
            foreach (Trainer currTrainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                //"{trainerName} {badges} {numberOfPokemon}"
                Console.WriteLine($"{currTrainer.Name} {currTrainer.NumberOfBadges} {currTrainer.CollectionOfPokemons.Count}");
            }

        }

        static void CheckTrainersPokemon(List<Trainer> trainers, string el)
        {
            foreach (Trainer currTrainer in trainers)
            {
                if (currTrainer.CollectionOfPokemons.Any(p => p.Element == el))
                {
                    currTrainer.NumberOfBadges++;
                }
                else
                {
                    for (int i = 0; i < currTrainer.CollectionOfPokemons.Count; i++) //foreach (Pokemon currPoki in currTrainer.CollectionOfPokemons) ----- gives error when removing from list
                    {
                        Pokemon currPoki = currTrainer.CollectionOfPokemons[i];

                        currPoki.Health -= 10;

                        if (currPoki.Health <= 0)
                        {
                            currTrainer.CollectionOfPokemons.Remove(currPoki);
                        }
                    }
                }
            }
        }


    }
}

