using System;
using System.Collections.Generic;
using System.Linq;


namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TrafficJam
            
            Queue<string> queue = new Queue<string>();

            int N = int.Parse(Console.ReadLine());
            int cnt = 0;

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            cnt++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{cnt} cars passed the crossroads.");
        }
    }
}
