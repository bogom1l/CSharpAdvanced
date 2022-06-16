using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.BeaveratWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] colElements = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }




            string command = Console.ReadLine();

            while (true)
            {
                if (command == "end")
                {
                    break;
                }





                command = Console.ReadLine();
            }



        }
    }
}
