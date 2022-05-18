using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reading Jagged Array
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rowsCount][];

            for (int row = 0; row < jagged.Length; row++)
            {
               jagged[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();  
            }


            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0];

                if (action == "END")
                {
                    break;
                }
                else if(action == "Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);
                    if (row >= 0 && row < jagged.Length && col>= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (action == "Subtract")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);
                    if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            //Printing Jagged Array
            foreach (int[] row in jagged)
            {
                Console.WriteLine($"{string.Join(" ", row)}");
            }

        }
    }
}
