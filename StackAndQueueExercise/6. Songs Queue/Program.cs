using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string currSong = command.Substring(4); //currSong = command.Split("Add ")[1];
                    if (queue.Contains(currSong))
                    {
                        Console.WriteLine($"{currSong} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(currSong);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine($"{string.Join(", ", queue)}");
                }
            }

            Console.WriteLine($"No more songs!");

        }
    }
}
